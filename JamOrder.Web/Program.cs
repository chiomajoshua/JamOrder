using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using JamOrder.Core.Helpers.Autofac;
using JamOrder.Core.Middleware;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Localization;
using Serilog;
using System.Globalization;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Host.UseSerilog((ctx, lc) => lc
       .WriteTo.Console()
       .ReadFrom.Configuration(ctx.Configuration));

    builder.Services.AddControllers()
            .AddFluentValidation(s =>
            {
                s.RegisterValidatorsFromAssemblyContaining<Program>();
            });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerService();

    builder.Services.AddResponseCaching();
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("pol",
        builder =>
        {
            // Not a permanent solution, but just trying to isolate the problem
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
    });
    builder.Services.AddRouting(opt => opt.LowercaseUrls = true);
    builder.Services.AddHealthChecks();

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureContainer<ContainerBuilder>(builder =>
        {
            builder.RegisterModule(new AutofacContainerModule());
        });



    var app = builder.Build();
    app.ConfigureExceptionHandler();
    app.UseSerilogRequestLogging();

    var supportedCultures = new[] { new CultureInfo("en-GB"), new CultureInfo("en-US") };
    app.UseRequestLocalization(new RequestLocalizationOptions
    {
        DefaultRequestCulture = new RequestCulture("en-GB"),
        SupportedCultures = supportedCultures,
        SupportedUICultures = supportedCultures
    });

    app.UseSwaggerService();
    app.UseRouting();
    app.UseCors("pol");
    app.UseHttpsRedirection();
    app.UseResponseCaching();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapHealthChecks("/health", new HealthCheckOptions
        {
            AllowCachingResponses = false,
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        endpoints.MapControllers();
    });

    app.Run();
}
catch (Exception ex)
{
    string type = ex.GetType().Name;
    if (type.Equals("StopTheHostException", StringComparison.Ordinal))
    {
        throw;
    }
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}