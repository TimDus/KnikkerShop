using KnikkerShop.Context.IContext;
using KnikkerShop.Interfaces;
using KnikkerShop.Models.Data;
using KnikkerShop.Parsers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Context.MSSQLContext
{
    public class MSSQLCategorieContext : BaseMSSQLContext, ICategorieContext
    {
        public MSSQLCategorieContext(IConfiguration config) : base(config)
        {
        }

        public bool Activation(long id, bool active)
        {
            if (active == true)
            {
                string sql = "UPDATE Categorie SET Actief = 0 WHERE id = @id";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("id", id.ToString()),
                };

                ExecuteSql(sql, parameters);

                return true;
            }
            else if (active == false)
            {
                string sql = "UPDATE Categorie SET Actief = 1 WHERE id = @id";

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

        public long Insert(Categorie obj)
        {
            try
            {
                string sql = "INSERT INTO Categorie (Naam, Actief) VALUES (@naam, 1) ";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("naam", obj.Naam)

                };

                ExecuteSql(sql, parameters);

                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(Categorie obj)
        {
            try
            {
                string sql = "UPDATE Categorie SET Naam = @naam WHERE Id = @Id";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("naam", obj.Naam),
                    new KeyValuePair<string, string>("id", Convert.ToString(obj.Id)),
                };

                ExecuteSql(sql, parameters);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Categorie> GetAll()
        {
            try
            {
                string sql = "SELECT Id, Naam, Actief From Categorie";
                List<Categorie> categorien = new List<Categorie>();

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                };

                ExecuteSql(sql, parameters);

                DataSet result = ExecuteSql(sql, parameters);

                if (result != null && result.Tables[0].Rows.Count > 0)
                {
                    for (int x = 0; x < result.Tables[0].Rows.Count; x++)
                    {
                        Categorie c = DataSetParser.DataSetToCategorie(result, x);
                        categorien.Add(c);
                    }
                }

                return categorien;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Categorie GetById(long id)
        {
            try
            {
                string sql = "SELECT Id, Naam, Actief FROM Categorie WHERE Id = @Id";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Id", id.ToString()),
                };

                DataSet results = ExecuteSql(sql, parameters);
                Categorie c = DataSetParser.DataSetToCategorie(results, 0);
                return c;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
