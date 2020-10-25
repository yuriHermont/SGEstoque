
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

        public async Task<IEnumerable<Produto>> GetAll()
        {
           throw new NotImplementedException();//await _context.Produto.ToListAsync();  
        }
        public async Task<Produto> Get(int id)
        {
            return await Task.Run(() => produtos[id]);
        }
        public async Task Add(Produto produto)
        {
            //await _context.Produto.AddAsync(produto);
        }
        public async Task Edit(Produto produto)
        {
            //await Task.Run(() =>
            //{
            //    produtos.Remove(produto.Id);
            //    produtos.Add(produto.Id, produto);
            //});
            throw new NotImplementedException();
        }
        public async Task Delete(int id)
        {
            await Task.Run(() => produtos.Remove(id));
        }
    }
}
