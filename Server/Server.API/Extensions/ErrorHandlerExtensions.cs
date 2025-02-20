using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Server.Application.Common.Exceptions;

namespace Server.API.Extensions;

public static class ErrorHandlerExtensions
{
    public static void UseErrorHandler(this IApplicationBuilder app) => 
        app.UseExceptionHandler(error => 
        {
            error.Run(async context => 
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if(contextFeature is null) return;

                var statusCode = contextFeature.Error switch
                {
                    AppException appError => appError.StatusCode,
                    _ => 500
                };

                var message = contextFeature.Error switch
                {
                    AppException appError => appError.Message,
                    _ => "Internal Server Error"
                };

                context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;

                var errorResponse = new { statusCode, message };

                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            });
        });
}