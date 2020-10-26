using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Domain.Repository
{
    public interface IRepository<T>
    {
        Task<IList<T>> GetAll();
        Task<T> Get(long id);
        Task Add(T item);
        Task Edit(T item);
        Task Delete(long id);
    }

}
