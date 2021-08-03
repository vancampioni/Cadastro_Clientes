using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.WebApi.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Consultório Legal", Version = "v1" }); // Pipeline
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.RoutePrefix = string.Empty; // Abre diretamente na página que for definida
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "CL V1"); // Endpoint: onde será disponibilizada a página (rota/nome doc)
            });
        }
    }
}
