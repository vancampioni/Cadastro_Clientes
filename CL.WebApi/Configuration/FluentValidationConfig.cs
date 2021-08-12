﻿using CL.Manager.Validator;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CL.WebApi.Configuration
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(x => {
                    x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.Converters.Add(new StringEnumConverter());
                })
                .AddJsonOptions(p => {
                    p.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
                    .AddFluentValidation(p => {
                        p.RegisterValidatorsFromAssemblyContaining<NovoClienteValidator>();
                        p.RegisterValidatorsFromAssemblyContaining<AlteraClienteValidator>();
                        p.RegisterValidatorsFromAssemblyContaining<NovoEnderecoValidator>();
                        p.RegisterValidatorsFromAssemblyContaining<NovoTelefoneValidator>();
                        p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                    });
        }
    }
}

