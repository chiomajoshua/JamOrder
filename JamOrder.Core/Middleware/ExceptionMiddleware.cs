using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;
using System.Net;

namespace JamOrder.Core.Middleware
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    if (contextFeature != null)
                    {
                        Log.Warning($"ExceptionFailure: {JsonConvert.SerializeObject(contextFeature.Error)}.");
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        {
                            IsSuccessful = false,
                            Message = "Sorry, something went wrong",
                            StatusCode = Helpers.StatusCodes.GeneralError
                        }));
                    }
                });
            });
        }
    }
}