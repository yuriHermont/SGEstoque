using MediatR;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SGE.Application.Abstraction.Command
{
    public class CriarProdutoCommand : IRequest<string>
    {
        public string NomeProduto { get; set; }
        public int QtdeProduto { get; set; }
        public float ValorUnitario { get; set; }

    }
}
