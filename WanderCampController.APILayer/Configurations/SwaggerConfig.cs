using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


namespace WanderCampController.APILayer.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WanderCamp API",
                    Version = "v1",
                    Description = "API documentation for WanderCamp application"
                });

                //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.Http,
                //    Scheme = "Bearer",
                //    BearerFormat = "JWT",
                //    In = ParameterLocation.Header,
                //    Description = "Enter 'Bearer' followed by a space and your JWT token."
                //});

               // options.OperationFilter<BasicAuthOperationFilter>();

            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "WanderCamp API v1");
                options.ConfigObject.AdditionalItems["tryItOutEnabled"] = true; // Enable "Execute" without Try It Out
                options.DefaultModelsExpandDepth(-1); // Disables the "Schemas" section
                options.RoutePrefix = string.Empty; 
            });
            return app;
        }
    }
}
