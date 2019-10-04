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

        public bool Activation(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Categorie obj)
        {
            try
            {
                string sql = "INSERT INTO Categorie(Naam) VALUES(@naam)";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("naam", obj.Naam)

                };

                ExecuteSql(sql, parameters);

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(Categorie obj)
        {
            throw new NotImplementedException();
        }

        public List<Categorie> GetAll()
        {
            try
            {
                string sql = "SELECT Naam From Categorie";
                List<Categorie> categorien = new List<Categorie>();

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                };

                ExecuteSql(sql, parameters);

                DataSet result = ExecuteSql(sql, parameters);
                if (result != null && result.Tables[0].Rows.Count > 0)
                {
                    categorien = DataSetParser.DataSetToList(result, 0);
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
            throw new NotImplementedException();
        }
    }
}
