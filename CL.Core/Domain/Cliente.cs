using CL.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CL.Core.Domain
{
    public class Cliente
    {
        [Key]
        public int Id_Cliente { get; set; }
        public string Nome_Cliente { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public string Telefone { get; set; }
        public string Documento { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }
    }
}
