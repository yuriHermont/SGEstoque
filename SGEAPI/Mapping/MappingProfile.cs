using AutoMapper;
using SGE.Application.Abstraction.Command;
using SGE.Application.Abstraction.DTO;
using SGE.Application.Abstraction.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGE.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() : base("SGE.API.Mapping.MappingProfile")
        {
            //Command
            this.CreateMap<ProdutoDTO,CriarProdutoCommand>();

        }
    }
}
