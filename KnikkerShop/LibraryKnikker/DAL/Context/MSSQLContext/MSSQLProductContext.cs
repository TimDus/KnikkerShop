using KnikkerShop.Context.IContext;
using KnikkerShop.Interfaces;
using KnikkerShop.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using KnikkerShop.Parsers;

namespace KnikkerShop.Context.MSSQLContext
{
    public class MSSQLProductContext : BaseMSSQLContext, IProductContext
    {
        public MSSQLProductContext(IConfiguration config) : base(config)
        {
        }

        public bool Activation(long id, bool active)
        {
            if(active == true)
            {
                string sql = "UPDATE Product SET Actief = 0 WHERE id = @id";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("id", id.ToString()),
                };

                ExecuteSql(sql, parameters);

                return true;
            }
            else if(active == false)
            {
                string sql = "UPDATE Product SET Actief = 1 WHERE id = @id";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("id", id.ToString()),
                };

                ExecuteSql(sql, parameters);

                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Product> GetAll()
        {
            try
            {
                string sql = "SELECT P.Id, P.Naam, P.Prijs, P.Grootte, P.Kleur, P.Beschrijving, P.Voorraad, C.Naam, P.CategorieId, P.Actief FROM Product as P INNER JOIN Categorie as C ON P.CategorieId = C.Id";
                List<Product> producten = new List<Product>();

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                };

                ExecuteSql(sql, parameters);

                DataSet result = ExecuteSql(sql, parameters);

                if (result != null && result.Tables[0].Rows.Count > 0)
                {
                    for (int x = 0; x < result.Tables[0].Rows.Count; x++)
                    {
                        Product p = DataSetParser.DataSetToProduct(result, x);
                        producten.Add(p);
                    }
                }

                return producten;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Product GetById(long id)
        {
            try
            {
                string sql = "SELECT P.Id, P.Naam, P.Prijs, P.Grootte, P.Kleur, P.Beschrijving, P.Voorraad, C.Naam, P.CategorieId, P.Actief FROM Product as P INNER JOIN Categorie as C ON P.CategorieId = C.Id WHERE P.Id = @Id";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Id", id.ToString()),
                };

                DataSet results = ExecuteSql(sql, parameters);
                Product p = DataSetParser.DataSetToProduct(results, 0);
                return p;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public long Insert(Product product)
        {
            try
            {
                string sql = "INSERT INTO Product(Naam, Prijs, Grootte, Kleur, Beschrijving, Voorraad, CategorieId , Actief) OUTPUT Inserted.Id VALUES(@naam, @prijs, @grootte, @kleur, @beschrijving, 1,@categorieId, 1)";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("naam", product.Naam),
                    new KeyValuePair<string, string>("prijs", product.Prijs),
                    new KeyValuePair<string, string>("grootte", product.Grootte),
                    new KeyValuePair<string, string>("kleur", product.Kleur),
                    new KeyValuePair<string, string>("beschrijving", product.Beschrijving),
                    new KeyValuePair<string, string>("categorieId", Convert.ToString(product.CategorieId))
                };

                long result = ExecuteInsert(sql, parameters);

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(Product product)
        {
            try
            {
                string sql = "UPDATE Product SET naam = @naam, categorieId = @categorieId, beschrijving = @beschrijving, prijs = @prijs, grootte = @grootte, kleur = @kleur WHERE id = @id";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("naam", product.Naam),
                    new KeyValuePair<string, string>("categorieId", product.CategorieId.ToString()),
                    new KeyValuePair<string, string>("beschrijving", product.Beschrijving),
                    new KeyValuePair<string, string>("prijs", product.Prijs.ToString()),
                    new KeyValuePair<string, string>("grootte", product.Grootte),
                    new KeyValuePair<string, string>("kleur", product.Kleur),
                    new KeyValuePair<string, string>("id", product.Id.ToString()),
                };

                ExecuteSql(sql, parameters);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }   
        }

        public bool VeranderVoorraad(int Aantal)
        {
            throw new NotImplementedException();
        }
    }
}
