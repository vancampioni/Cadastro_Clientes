using CL.Core.Shared.ModelViews.Endereco;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Core.Shared.ModelViews.Cliente
{
    public class Create
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Documento { get; set; }
        public DateTime Criacao { get; set; }
        // Endereço
        public int CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        // Telefone
        public string NumeroTel { get; set; }
    }
}
