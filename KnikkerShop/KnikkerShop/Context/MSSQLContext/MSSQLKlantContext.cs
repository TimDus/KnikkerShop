using KnikkerShop.Context.IContext;
using KnikkerShop.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Context.MSSQLContext
{
    public class MSSQLKlantContext : BaseMSSQLContext, ICategorieContext
    {
        public MSSQLKlantContext(IConfiguration config) : base(config)
        {
        }

        public bool Activation(long id, bool active)
        {
            throw new NotImplementedException();
        }

        public List<Categorie> GetAll()
        {
            throw new NotImplementedException();
        }

        public Categorie GetById(long id)
        {
            throw new NotImplementedException();
        }

        public long Insert(Categorie obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Categorie obj)
        {
            throw new NotImplementedException();
        }
    }
}
