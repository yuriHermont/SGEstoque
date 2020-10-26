
using SGE.Domain.Entitys;
using SGE.Domain.Repository;
using SGE.Infrastructure.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGE.Infrastructure.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private static Dictionary<int, Produto> produtos = new Dictionary<int, Produto>();

        private readonly ProdutoDbContext _context;
      
        public ProdutoRepository(ProdutoDbContext context) {
            this._context = context;
        }

        public async Task<IList<Produto>> GetAll()
        {
            return this._context.Produto.ToList();
        }
        public async Task<Produto> Get(long id)
        {
            return this._context.Produto.Find(id);
        }
        public async Task Add(Produto produto)
        {
            await _context.Produto.AddAsync(produto);
        }
        public async Task Edit(Produto produto)
        {
            var aux2 = _context.Produto;
            aux2.Add(new Produto{
                NomeProduto = produto.NomeProduto,
                ValorUnitario = produto.ValorUnitario,
                QtdeProduto = produto.QtdeProduto
            });
            _context.SaveChanges();
        }
        public async Task Delete(long id)
        {
            Produto produto =  this._context.Produto.Find(id);
            _context.Remove(produto);
        }
    }
}
