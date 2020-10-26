using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGE.API.ResponseView;
using SGE.Application.Abstraction;
using SGE.Application.Abstraction.Command;
using SGE.Application.Abstraction.DTO;
using SGE.Application.Abstraction.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGE.API.Controller
{
    [ApiController, Route("Api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProdutoController(IMediator mediator,IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;

        }

        [HttpGet, Route("ListarProdutos"), ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ComumResponseViewModel<>)),
         ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<ValidationFailure>))]
        public async Task<IActionResult> ListarProdutos()
        {
            ListarProdutosQuery query = new ListarProdutosQuery();
            List<ProdutoDTO> response = await this._mediator.Send(query);
            return CreatedAtAction("ListarProdutos", response);
        }
        [HttpPost, Route("CadastrarProduto"), ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ComumResponseViewModel<>)),
         ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<ValidationFailure>))]
        public async Task<IActionResult> CadastrarProdutos([FromBody] ProdutoDTO dto)
        {
            CriarProdutoCommand command = _mapper.Map<CriarProdutoCommand>(dto);
            string response = await this._mediator.Send(command);
            return CreatedAtAction("CadastrarProdutos", response);
        }
    }
}
