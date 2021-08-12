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
        public int ClienteId { get; set; }
        [Required]
        public string Nome_Cliente { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
       
        public Sexo Sexo { get; set; }
        
        public ICollection<Telefone> Telefones { get; set; } // O cliente tem vários telefones
        
        public string Documento { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }

        public Endereco Endereco { get; set; } // Relacionamento 1 pra 1
    }
}
