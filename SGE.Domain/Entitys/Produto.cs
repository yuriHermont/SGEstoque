﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.Domain.Entitys
{
    public class Produto
    {
        public long Id { get; set; }
        public string NomeProduto { get; set; }
        public long QtdeProduto { get; set; }
        public float ValorUnitario { get; set; }
    }
}
