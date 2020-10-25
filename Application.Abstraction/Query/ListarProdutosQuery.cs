using MediatR;
using SGE.Application.Abstraction.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Application.Abstraction.Query
{
    public class ListarProdutosQuery : IRequest<List<ProdutoDTO>> 
    {
    }
}
