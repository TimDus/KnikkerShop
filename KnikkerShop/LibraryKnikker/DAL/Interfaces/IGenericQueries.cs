using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Interfaces
{
    public interface IGenericQueries<T>
    {
        List<T> GetAll();
        T GetById(long id);

        long Insert(T obj);
        bool Update(T obj);
        bool Activation(long id, bool active);
    }
}
