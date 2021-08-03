using AutoMapper;
using CL.Core.Domain;
using CL.Core.Shared.ModelViews;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Manager.Mappings
{
    public class AlteraClienteMappingProfile : Profile
    {
        public AlteraClienteMappingProfile()
        {
            CreateMap<AlteraCliente, Cliente>() // Parâmetros: objeto de oriegm - objeto de destino
                .ForMember(d => d.UltimaAtualizacao, o => o.MapFrom(x => DateTime.Now)) // Add data da criação
                .ForMember(d => d.DataNascimento, o => o.MapFrom(x => x.DataNascimento.Date)); // Pegar a data sem a hora
                                                                                              
        }
    }
}
