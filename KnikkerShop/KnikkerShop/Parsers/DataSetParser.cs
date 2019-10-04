using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using KnikkerShop.Models.Data;

namespace KnikkerShop.Parsers
{
    public static class DataSetParser
    {
        public static List<Categorie> DataSetToList(DataSet set, int rowindex)
        {
            List<Categorie> list = new List<Categorie>();
            return list;
        }

        private static T TryParse<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return default(T); // returns the default value for the type
            }
            else
            {
                return (T)obj;
            }
        }
    }
}
