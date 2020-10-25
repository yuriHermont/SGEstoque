using MediatR;
using SGE.Application.Abstraction.DTO;
using SGE.Application.Abstraction.Query;
using SGE.Domain.Entitys;
using SGE.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SGE.Application.Mapping;
using AutoMapper;

namespace SGE.Application.QueryHandler
{
    public class ListarProdutosQueryHandler : IRequestHandler<ListarProdutosQuery, List<ProdutoDTO>>
    {
        
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public ListarProdutosQueryHandler (IMediator mediator, IMapper mapper)
        {
            this._mapper = mapper;
        }
        public async Task<List<ProdutoDTO>> Handle(ListarProdutosQuery query, CancellationToken cancellationToken)
        {
            try {

                List<Produto> result = (await _produtoRepository.GetAll()).ToList();
                List<ProdutoDTO> responseData = _mapper.Map<List<ProdutoDTO>>(result);
                return responseData;
            } catch { }

            throw new NotImplementedException();
        }
    }
}
