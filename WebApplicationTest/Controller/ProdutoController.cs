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

        [HttpGet, Route("ListarProdutos"), ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ComumResponseViewModel<List<ProdutoDTO>>)),
         ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<ValidationFailure>))]
        public async Task<IActionResult> ListarProdutos()
        {
            ListarProdutosQuery query = new ListarProdutosQuery();
            List<ProdutoDTO> response = await this._mediator.Send(query);
            return CreatedAtAction("ListarProdutos", response);
        }

        [HttpGet, Route("ConsultarProduto"), ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ComumResponseViewModel<ProdutoDTO>)),
         ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<ValidationFailure>))]
        public async Task<IActionResult> ConsultarProduto(long id)
        {
            ConsultarProdutoQuery query = new ConsultarProdutoQuery() { Id = id };
            ProdutoDTO response = await this._mediator.Send(query);
            return CreatedAtAction("ConsultarProduto", response);
        }
        [HttpGet, Route("CadastrarProduto"), ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ComumResponseViewModel<>)),
         ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<ValidationFailure>))]
        public async Task<IActionResult> CadastrarProdutos([FromQuery] ProdutoDTO dto)
        {
            CriarProdutoCommand command = _mapper.Map<CriarProdutoCommand>(dto);
            string response = await this._mediator.Send(command);
            return CreatedAtAction("CadastrarProduto", response);
        }

        [HttpDelete, Route("DeletarProduto"), ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ComumResponseViewModel<>)),
         ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<ValidationFailure>))]
        public async Task<IActionResult> DeletarProduto(int id)
        {
            DeletarProdutoCommand command =new DeletarProdutoCommand() { Id = id};
            string response = await this._mediator.Send(command);
            return CreatedAtAction("DeleterProduto",response);
        }

        [HttpPut, Route("AtualizarProduto"), ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ComumResponseViewModel<>)),
         ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<ValidationFailure>))]
        public async Task<IActionResult> AtualizarProduto([FromQuery] ProdutoDTO dto)
        {
            AtualizarProdutoCommand command = _mapper.Map<AtualizarProdutoCommand>(dto);
            string response = await this._mediator.Send(command);
            return CreatedAtAction("AtualizarProduto", (object)response);
        }
    }
}
