using KnikkerShop.Context.IContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Repositories
{
    public class CategorieRepository
    {
        private readonly ICategorieContext context;

        public CategorieRepository(ICategorieContext context)
        {
            this.context = context;
        }

        public bool Insert(string obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException("Geen categorie.");
            }
            return context.Insert(obj);
        }
    }
}
