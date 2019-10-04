using KnikkerShop.Context.IContext;
using KnikkerShop.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Repositories
{
    public class ProductRepository
    {
        private readonly IProductContext context;

        public ProductRepository(IProductContext context)
        {
            this.context = context;
        }

        public bool Insert(Product product)
        {
            if (product == null)
            {
                throw new NullReferenceException("Geen product.");
            }
            return context.Insert(product);
        }
    }
}
