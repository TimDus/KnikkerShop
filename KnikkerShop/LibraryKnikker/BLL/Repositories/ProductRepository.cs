using LibraryKnikker.Core.DAL.Context.IContext;
using LibraryKnikker.Core.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryKnikker.Core.BLL.Repositories
{
    public class ProductRepository
    {
        private readonly IProductContext context;

        public ProductRepository(IProductContext context)
        {
            this.context = context;
        }

        public long Insert(Product product)
        {
            if (product == null)
            {
                throw new NullReferenceException("Geen product.");
            }
            return context.Insert(product);
        }

        public List<Product> GetAll()
        {
            return context.GetAll();
        }

        public bool Update(Product obj)
        {
            return context.Update(obj);
        }

        public Product GetById(long id)
        {
            return context.GetById(id);
        }

        public bool Activation(long id, bool active)
        {
            return context.Activation(id, active);
        }
    }
}
