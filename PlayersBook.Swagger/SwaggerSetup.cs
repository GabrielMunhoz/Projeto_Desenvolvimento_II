using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace PlayersBook.Swagger
{
    public static class SwaggerSetup
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            return services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "Template .Net Core",
                        Version = "v1",
                        Description = "Tutorial de desenvolvimento",
                        Contact = new OpenApiContact
                        {
                            Name = "Gabriel Munhoz",
                            Email = "gabrielmunhoz0204@gmail.com"
                        }
                    });
                string? xmlPath = Path.Combine("wwwroot", "apiDoc.xml");
                opt.IncludeXmlComments(xmlPath);
            });
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            return app.UseSwagger().UseSwaggerUI(c =>
            {
                c.RoutePrefix = "doc";
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Api v1");
            });
        }

    }
}