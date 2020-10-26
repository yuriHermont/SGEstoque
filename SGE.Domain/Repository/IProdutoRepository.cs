using SGE.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Domain.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<List<Produto>> GetAll();

        Task<Produto> Get(long id);

        void Add(Produto produto);

        void Edit(Produto produto);

        void Delete(Produto produto);
        
    }
}
