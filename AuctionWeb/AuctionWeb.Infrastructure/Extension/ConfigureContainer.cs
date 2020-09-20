using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using AuctionWeb.Infrastructure.Middleware;
using Serilog;

namespace AuctionWeb.Infrastructure.Extension
{
    public static class ConfigureContainer
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(o=> {
                o.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.DisplayOperationId();

                setupAction.SwaggerEndpoint("/swagger/OpenAPISpecification/swagger.json", "Auction");
                setupAction.RoutePrefix = "OpenAPI";


            });
        }

        public static void ConfigureSwagger(this ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();
        }

    }
}
