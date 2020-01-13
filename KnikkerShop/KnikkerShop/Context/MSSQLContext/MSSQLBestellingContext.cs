using KnikkerShop.Context.IContext;
using KnikkerShop.Models.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Context.MSSQLContext
{
    public class MSSQLBestellingContext : BaseMSSQLContext, IBestellingContext
    {
        public MSSQLBestellingContext(IConfiguration config) : base(config)
        {
        }

        public bool Activation(long id, bool active)
        {
            throw new NotImplementedException();
        }

        public List<Bestelling> GetAll()
        {
            throw new NotImplementedException();
        }

        public Bestelling GetById(long id)
        {
            throw new NotImplementedException();
        }

        public long Insert(Bestelling obj)
        {
            try
            {
                string sql = "INSERT INTO Bestelling(KlantId, BestelDatum, LeverDatum, TotaalPrijs, Postcode, Huisnummer) OUTPUT Inserted.Id VALUES(@klantid, @besteldatum, @leverdatum, @totaalprijs, @postcode, @huisnummer)";
                 
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("klantid", obj.KlantId.ToString()),
                    new KeyValuePair<string, string>("besteldatum", DateTime.Now.ToString("yyyy-MM-dd")),
                    new KeyValuePair<string, string>("leverdatum", obj.Leverdatum.ToString("yyyy-MM-dd")),
                    new KeyValuePair<string, string>("totaalprijs", obj.Totaalprijs),
                    new KeyValuePair<string, string>("postcode", obj.Postcode),
                    new KeyValuePair<string, string>("huisnummer", obj.Huisnummer),
                };

                long result = ExecuteInsert(sql, parameters);

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(Bestelling obj)
        {
            throw new NotImplementedException();
        }
    }
}
