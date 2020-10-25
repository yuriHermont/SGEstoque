using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Domain.Repository
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Add(T item);
        Task Edit(T item);
        Task Delete(int id);
    }

}
