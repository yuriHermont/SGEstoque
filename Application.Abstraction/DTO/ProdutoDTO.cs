﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Application.Abstraction.DTO
{
    public class ProdutoDTO
    {
        public long Id { get; set; }
        public string NomeProduto { get; set; }
        public long QtdeProduto { get; set; }
        public float ValorUnitario { get; set; }
    }
}
