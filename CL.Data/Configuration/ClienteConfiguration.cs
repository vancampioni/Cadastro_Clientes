using CL.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Data.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente> // Utilizando FluentAPI
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(p => p.Nome_Cliente).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Sexo).HasConversion( // Salvar o valor do enum na database
                p => p.ToString(),
                p => (Sexo)Enum.Parse(typeof(Sexo), p));
        }
    }
}
