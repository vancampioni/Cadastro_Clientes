using CL.Core.Shared.ModelViews.Endereco;
using CL.Core.Shared.ModelViews.Telefone;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CL.Core.Shared.ModelViews.Cliente
{
    public class ClienteView 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public SexoView Sexo { get; set; }
        public ICollection<TelefoneView> Telefones { get; set; }

        public string Documento { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }

        public EnderecoView Endereco { get; set; }
    }
}