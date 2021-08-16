
using System;

namespace CL.Core.Shared.ModelViews.Endereco
{
    public class EnderecoView
    {
        public int CEP { get; set; }
        public EstadoView Estado { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
    }
}