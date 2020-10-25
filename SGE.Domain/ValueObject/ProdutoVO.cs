using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.ValueObject
{
    public class ProdutoVO
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public int QtdeProduto { get; set; }
        public float ValorUnitario { get; set; }
    }
}
