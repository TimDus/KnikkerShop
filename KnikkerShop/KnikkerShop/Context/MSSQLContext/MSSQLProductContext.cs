using KnikkerShop.Context.IContext;
using KnikkerShop.Interfaces;
using KnikkerShop.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Context.MSSQLContext
{
    public class MSSQLProductContext : BaseMSSQLContext, IProductContext
    {
        public MSSQLProductContext(IConfiguration config) : base(config)
        {
        }

        public bool Activation(int id)
        {
            throw new NotImplementedException();
        }

        public bool AddStock(int Aantal)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(long id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Product product)
        {
            try
            {
                string sql = "INSERT INTO Product(Naam, Prijs, Grootte, Kleur, Beschrijving, CategorieId) VALUES(@naam, @prijs, @grootte, @kleur, @beschrijving, @categorieId)";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("naam", product.Naam),
                    new KeyValuePair<string, string>("prijs", product.Prijs),
                    new KeyValuePair<string, string>("grootte", product.Grootte),
                    new KeyValuePair<string, string>("kleur", product.Kleur),
                    new KeyValuePair<string, string>("beschrijving", product.Beschrijving),
                    new KeyValuePair<string, string>("categorieId", Convert.ToString(product.CategorieId))
                };

                ExecuteSql(sql, parameters);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool RemoveStock(int Aantal)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
