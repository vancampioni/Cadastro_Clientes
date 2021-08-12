using CL.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Data.Configuration
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            //builder.HasOne(p => p.Cliente) // O telefone pertence a um cliente
            //    .WithMany(p => p.Telefones) // O cliente tem vários telefones
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade); // Quando deletar um cliente também vai deletar um telefone
            builder.HasKey(p => new { p.ClienteId, p.Numero }); // Chave composta com obj anonimo (o cliente não pode cadastrar o mesmo nº mais de uma vez)
        }
    }
}
