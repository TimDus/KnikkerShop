using KnikkerShop.Context.IContext;
using KnikkerShop.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Context.MSSQLContext
{
    public class MSSQLBestellingContext : IBestellingContext
    {
        public bool Activation(long id, bool active)
        {
            throw new NotImplementedException();
        }

        public List<Bestelling> GetAll()
        {
            throw new NotImplementedException();
        }

        public Bestelling GetById(long id)
        {
            throw new NotImplementedException();
        }

        public long Insert(Bestelling obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Bestelling obj)
        {
            throw new NotImplementedException();
        }
    }
}
