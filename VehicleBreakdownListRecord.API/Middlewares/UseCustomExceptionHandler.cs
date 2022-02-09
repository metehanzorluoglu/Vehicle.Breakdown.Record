using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using VehicleBreakdownRecor.Business.Exceptions;
using VehicleBreakdownRecord.Entity.DTOs;

namespace VehicleBreakdownListRecord.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var statusCode = error.Error switch
                        {
                            ClientSideException clientSideException => 400,
                            NotFoundException notFoundException => 404,
                            _ => 500
                        };
                        context.Response.StatusCode = statusCode;
                        var response = CustomResultDto<NoContentDto>.Fail(statusCode, error.Error.Message);

                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                });
            });
        }
    }
}
