namespace CL.Core.Domain
{
    public class Telefone
    {
        public int ClienteId { get; set; } // Chave composta
        public string Numero { get; set; } // Chave composta
        
        public Cliente Cliente { get; set; } // O telefone pertence a um cliente
    }
}