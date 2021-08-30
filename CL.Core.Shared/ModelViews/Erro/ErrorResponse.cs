using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CL.Core.Shared.ModelViews
{
    public class ErrorResponse
    {
        [Key]
        public string Id { get; set; }
        public DateTime Data { get; set; }
        public string Mensagem { get; set; }

        public ErrorResponse(string id)
        {
            Id = id;
            Data = DateTime.Now;
            Mensagem = "Erro Inesperado";
        }
    }
}
