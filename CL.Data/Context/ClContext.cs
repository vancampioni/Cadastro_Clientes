﻿using CL.Core.Domain;
using CL.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CL.Data.Context
{
    public class ClContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        public ClContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Configurando o modelo via EFCode
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new TelefoneConfiguration());
        }
    }
}
