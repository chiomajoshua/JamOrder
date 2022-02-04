using Microsoft.OpenApi.Models;

namespace JamOrder.Core.Middleware
{
    public class SwaggerOptions
    {
        public string Title { get; set; }
        public string Version { get; set; }
    }

    public static class Extensions
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            _ = services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JamOrder Web API V1", Version = $"1.0" });
                c.CustomSchemaIds(x => x.FullName);
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerService(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "House 4 MS API V1");
            });
            return app;
        }
    }
}