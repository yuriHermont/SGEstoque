
using SGE.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;
using System.Globalization;

namespace SGE.Infrastructure.Repository.Context
{
    public class ProdutoDbContext
    {
        private readonly DataTable _dt;
        private readonly DBContext _context;
        private readonly List<Produto> _produtos;
        public ProdutoDbContext(DBContext context)
            : base()
        {
            this._context = context;
            _produtos = new List<Produto>();
        }

        public async Task<List<Produto>> ListarProdutos()
        {
            DataTable retorno = _context.Consulta("select * from TBProduto");
            _produtos.Clear();
            foreach (DataRow linha in retorno.Rows)
            {
                _produtos.Add(new Produto
                {
                    Id = (long)linha["Id"],
                    NomeProduto = linha["NomeProduto"].ToString(),
                    ValorUnitario = (float)Convert.ToDouble(linha["ValorUnitario"]),
                    QtdeProduto = (long)linha["QtdeProduto"]
                });
            }
            return _produtos;
        }
        public async void InserirProduto(Produto produto)
        {
            var ptbr = new CultureInfo("pt-br");
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat(@"INSERT INTO TBProduto ( Id, NomeProduto, QtdeProduto, ValorUnitario ) VALUES ( null ,'{0}',{1} ,{2} )",
                produto.NomeProduto, produto.QtdeProduto, produto.ValorUnitario.ToString().Replace(",","") );
            _context.Alterar(sql.ToString());
        }

        public async void AtualizarProduto(Produto produto)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("UPDATE INTO TBProduto ( NomeProduto, QtdeProduto, ValorUnitario ) VALUES ( '{0}',{1} ,{2} )",
                produto.NomeProduto, produto.QtdeProduto, produto.ValorUnitario.ToString().Replace(",", ""));
            sql.AppendFormat("WHERE Id = {0}", produto.Id);
            _context.Alterar(sql.ToString());
        }

        public async void DeletarProduto(Produto produto)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("DELETE FROM TBProduto WHERE Id = {0} ", produto.Id);
            _context.Alterar(sql.ToString());
        }
    }
}
