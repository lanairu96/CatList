using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IRepository<T, TKey>
    {
        IList<T> GetAll();
        IList<T> GetRandom(int count);
        T GetById(TKey id);
        T Add(T entity);
        bool Exists(TKey id);
        bool Update(T entity);
        bool Delete(TKey id);
    }
}
