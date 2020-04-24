using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravisComms.Api.Dto;

namespace TravisComms.Api.Middleware
{
    public static class ExceptionMiddleware
    {
        public static void UseGlobalException(this IApplicationBuilder app)
        {
           
            app.UseExceptionHandler(appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                });
            });
        }
    }
}
