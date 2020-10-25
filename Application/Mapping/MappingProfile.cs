using AutoMapper;
using SGE.Application.Abstraction.Command;
using SGE.Application.Abstraction.DTO;
using SGE.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
            : base("SGE.Application.Mapping.MappingProfile")
        {
            this.CreateMap<Produto, ProdutoDTO>().ReverseMap();
            this.CreateMap<CriarProdutoCommand, Produto>().ReverseMap();
        }
    }
}
