using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CL.WebApi.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", 
                    new OpenApiInfo {
                        Title = "Consultório Legal", 
                        Version = "v1",
                        Description = "API da aplicação consultório legal.",
                        Contact = new OpenApiContact //Informações de contato
                        {
                            Name = "Vanessa Campioni",
                            Email = "vanessacrtsilva@gmail.com",
                            Url = new Uri("https://github.com/vancampioni")
                        },
                        License = new OpenApiLicense //Informações licença OpenSource da aplicação
                        {
                            Name = "OSD",
                            Url = new Uri("https://opensource.org/osd")
                        },
                        TermsOfService = new Uri("https://opensource.org/osd") //Os termos de uso que a empresa define para uso da aplicação
                    }); // Pipeline

                //c.AddFluentValidationRules(); //Adicionar o FluentValidation

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                xmlPath = Path.Combine(AppContext.BaseDirectory, "CL.Core.Shared.xml"); // Fazer o swagger ler o projeto Core.Shared
                c.IncludeXmlComments(xmlPath);
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
