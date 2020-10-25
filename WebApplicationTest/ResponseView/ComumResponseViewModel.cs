using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGE.API.ResponseView
{
    public class ComumResponseViewModel
    {
        public ComumResponseViewModel(bool sucesso, string mensagem = null)
        {
            this.Sucesso = sucesso;
            this.Mensagem = mensagem;
        }

        public string Mensagem { get; }

        public bool Sucesso { get; }
    }
}
