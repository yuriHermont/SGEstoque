using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using SGE.Domain.Entitys;
using SGE.Application.Abstraction.Command;
using SGE.Domain.Repository;
using AutoMapper;

namespace SGE.Application.Command
{
    public class CriarProdutoCommandHandler : IRequestHandler<CriarProdutoCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public CriarProdutoCommandHandler(
            IMediator mediator, 
            IMapper mapper, 
            IProdutoRepository produtoRepository
            )
        {
            this._mediator = mediator;
            this._produtoRepository = produtoRepository;
            this._mapper = mapper;
        }
        public async Task<string> Handle(CriarProdutoCommand command, CancellationToken cancellationToken)
        {
            Produto produto = _mapper.Map<Produto>(command);
            try {
                _produtoRepository.Add(produto);
                return "ok";
            } catch {
                return "falha";
            }
        } 
    }
    
}

