using CL.Core.Shared.ModelViews.Endereco;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Core.Shared.ModelViews
{
    public class NovoEndereco
    {
        ///<example>49000000</example>
        public int CEP { get; set; }
        public EstadoView Estado { get; set; }
        ///<example>Franca</example>
        public string Cidade { get; set; }
        ///<example>Rua A</example>
        public string Logradouro { get; set; }
        ///<example>15</example>
        public string Numero { get; set; }
        ///<example>Na rua de cima do posto de combustível</example>
        public string Complemento { get; set; }

    }
}
