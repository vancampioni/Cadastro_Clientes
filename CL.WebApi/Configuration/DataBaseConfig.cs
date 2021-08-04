using CL.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CL.WebApi.Configuration
{
    public static class DataBaseConfig
    {
        public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ClContext>(options => options.UseSqlServer(configuration.GetConnectionString("ClConnection")));
        }

        public static void UseDataBaseConfiguration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ClContext>();
            context.Database.Migrate(); // Mantém a DB condizente com a aplicação
            context.Database.EnsureCreated(); // Garante que tenha uma DB criada para executar a aplicação
        }
    }
}
