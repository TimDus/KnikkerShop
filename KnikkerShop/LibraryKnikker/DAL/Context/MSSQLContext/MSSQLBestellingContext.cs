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

        public List<Bestelling> GetAllFromUser(long Id)
        {
            try
            {
                string sql = "SELECT Besteldatum, Leverdatum, TotaalPrijs From Bestelling WHERE Accountid = @id";
                List<Bestelling> bestellingen = new List<Bestelling>();

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Id", Id.ToString()),
                };

                ExecuteSql(sql, parameters);

                DataSet result = ExecuteSql(sql, parameters);

                if (result != null && result.Tables[0].Rows.Count > 0)
                {
                    for (int x = 0; x < result.Tables[0].Rows.Count; x++)
                    {
                        Bestelling b = DataSetParser.DataSetToBestelling(result, x);
                        bestellingen.Add(b);
                    }
                }

                return bestellingen;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Bestelling GetById(long id)
        {
            throw new NotImplementedException();
        }

        public long Insert(Bestelling obj)
        {
            long result = 0;

            try
            {
                string sql = "INSERT INTO Bestelling(Accountid, BestelDatum, LeverDatum, TotaalPrijs, Postcode, Huisnummer) OUTPUT Inserted.Id VALUES(@accountid, @besteldatum, @leverdatum, @totaalprijs, @postcode, @huisnummer)";
                 
                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("accountid", obj.KlantId.ToString()),
                    new KeyValuePair<string, string>("besteldatum", DateTime.Now.ToString("yyyy-MM-dd")),
                    new KeyValuePair<string, string>("leverdatum", obj.Leverdatum.ToString("yyyy-MM-dd")),
                    new KeyValuePair<string, string>("totaalprijs", obj.Totaalprijs),
                    new KeyValuePair<string, string>("postcode", obj.Postcode),
                    new KeyValuePair<string, string>("huisnummer", obj.Huisnummer),
                };

                result = ExecuteInsert(sql, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }

            foreach(Product p in obj.Products)
            {
                try
                {
                    string sql = "INSERT INTO ProductBestelling(ProductId, BestellingId, Aantal) VALUES(@productId, @bestellingId, @aantal)";

                    List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("productId", p.Id.ToString()),
                    new KeyValuePair<string, string>("bestellingId", result.ToString()),
                    new KeyValuePair<string, string>("aantal", p.Aantal.ToString()),
                };

                ExecuteSql(sql, parameters);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return result;
        }

        public bool Update(Bestelling obj)
        {
            throw new NotImplementedException();
        }
    }
}
