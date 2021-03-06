﻿using System.Collections.Generic;

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
