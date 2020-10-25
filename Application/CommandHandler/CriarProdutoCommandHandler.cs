﻿using MediatR;
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
        }
        public async Task<string> Handle(CriarProdutoCommand command, CancellationToken cancellationToken)
        {
            Produto produto = new Produto()
            {
                NomeProduto = command.NomeProduto,
                QtdeProduto = command.QtdeProduto,
                ValorUnitario = command.ValorUnitario
            };
            try {
                await _produtoRepository.Add(produto);
            } catch { }

            throw new NotImplementedException();
        } 
    }
    
}
