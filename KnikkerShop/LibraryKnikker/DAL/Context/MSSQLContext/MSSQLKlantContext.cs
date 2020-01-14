using LibraryKnikker.Core.DAL.Context.IContext;
using LibraryKnikker.Core.DAL.Data;
using LibraryKnikker.Core.DAL.Parsers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryKnikker.Core.DAL.Context.MSSQLContext
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
            try
            {
                string sql = "UPDATE Klant set @fields where AccountId = @id";

                string fields = "";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("id", obj.Id.ToString())
                };

                if (obj.Postcode != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[Postcode] = @postcode";
                    parameters.Add(new KeyValuePair<string, string>("postcode", obj.Postcode.ToString()));
                }
                if (obj.Huisnummer != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[Huisnummer] = @huisnummer";
                    parameters.Add(new KeyValuePair<string, string>("huisnummer", obj.Huisnummer.ToString()));
                }
                sql = sql.Replace("@fields", fields);

                ExecuteSql(sql, parameters);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
