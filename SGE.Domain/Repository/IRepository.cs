using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SGE.Domain.Repository
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> Get(long id);
        void Add(T item);
        void Edit(T item);
        void Delete(T id);
    }

}
