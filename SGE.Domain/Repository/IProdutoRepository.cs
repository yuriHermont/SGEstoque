using SGE.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Domain.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetAll();

        Task<Produto> Get(int id);

        Task Add(Produto produto);

        Task Edit(Produto produto);

        Task Delete(int id);
        
    }
}
