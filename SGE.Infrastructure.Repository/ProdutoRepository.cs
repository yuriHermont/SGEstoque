
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

        public async Task<List<Produto>> GetAll()
        {
            return await this._context.ListarProdutos();
        }
        public async Task<Produto> Get(long id)
        {
            return (await this._context.ListarProdutos()).Where(p=>p.Id==id).FirstOrDefault();
        }
        public void Add(Produto produto)
        {
           this._context.InserirProduto(produto);
        }
        public void Edit(Produto produto)
        {
            this._context.AtualizarProduto(produto);
        }
        public void Delete(Produto produto)
        {
            this._context.DeletarProduto(produto);

        }
    }
}
