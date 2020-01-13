using KnikkerShop.Context.IContext;
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
    public class MSSQLKlantContext : BaseMSSQLContext, IKlantContext
    {
        public MSSQLKlantContext(IConfiguration config) : base(config)
        {
        }

        public bool Activation(long id, bool active)
        {
            throw new NotImplementedException();
        }

        public List<Klant> GetAll()
        {
            throw new NotImplementedException();
        }

        public Klant GetById(long id)
        {
            try
            {
                string sql = "SELECT A.Id, A.UserName, A.Email, K.Id, K.Postcode, K.Huisnummer FROM Account as A INNER JOIN Klant as K ON A.Id = K.AccountId WHERE A.Id = @Id";

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Id", id.ToString()),
                };

                DataSet results = ExecuteSql(sql, parameters);
                Klant k = DataSetParser.DataSetToKlant(results, 0);
                return k;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public long Insert(Klant obj)
        {
            //will never be implemented because of the usercontect which handles this function
            throw new NotImplementedException();
        }

        public bool Update(Klant obj)
        {
            throw new NotImplementedException();
        }
    }
}
