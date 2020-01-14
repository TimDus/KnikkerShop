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
    public class MSSQLAccountContext : BaseMSSQLContext, IAccountContext
    {
        public MSSQLAccountContext(IConfiguration config) : base(config)
        {
        }

        public bool Activation(long id, bool active)
        {
            throw new NotImplementedException();
        }

        public List<BaseAccount> GetAll()
        {
            throw new NotImplementedException();
        }

        public BaseAccount GetById(long id)
        {
            throw new NotImplementedException();
        }

        public long Insert(BaseAccount obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(BaseAccount obj)
        {
            try
            {
                string sql = "UPDATE Account set @fields where Id = @id";

                string fields = "";
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("id", obj.Id.ToString())
                };

                if (obj.Email != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[Email] = @email";
                    parameters.Add(new KeyValuePair<string, string>("email", obj.Email.ToString()));
                }
                if (obj.UserName != null)
                {
                    if (!string.IsNullOrWhiteSpace(fields))
                        fields += ",";
                    fields += "[UserName] = @username";
                    parameters.Add(new KeyValuePair<string, string>("username", obj.UserName.ToString()));
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
