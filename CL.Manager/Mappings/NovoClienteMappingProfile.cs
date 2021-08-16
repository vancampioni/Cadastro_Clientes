using AutoMapper;
using CL.Core.Domain;
using CL.Core.Shared.ModelViews;
using CL.Core.Shared.ModelViews.Cliente;
using CL.Core.Shared.ModelViews.Endereco;
using CL.Core.Shared.ModelViews.Telefone;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Manager.Mappings
{
    public class NovoClienteMappingProfile : Profile
    {
        public NovoClienteMappingProfile()
        {
            CreateMap<NovoCliente, Cliente>() // Parâmetros: objeto de oriegm - objeto de destino
                .ForMember(d => d.Criacao, o => o.MapFrom(x => DateTime.Now)) // Add data da criação
                .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date)); // Pegar a data sem a hora
                                                                                               //ReverseMap(); quando quiser fazer de Cliente para NovoCliente

            CreateMap<NovoEndereco, Endereco>();
            CreateMap<NovoTelefone, Telefone>();
            CreateMap<Cliente, ClienteView>();
            CreateMap<Endereco, EnderecoView>();
            CreateMap<Telefone, TelefoneView>();
        }
    }
}
