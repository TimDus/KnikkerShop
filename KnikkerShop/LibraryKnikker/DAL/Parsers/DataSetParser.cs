using LibraryKnikker.Core.DAL.Data;
using System;
using System.Data;

namespace LibraryKnikker.Core.DAL.Parsers
{
    public static class DataSetParser
    {
        public static Product DataSetToProduct(DataSet set, int rowIndex)
        {
            return new Product()
            {
                Id = (long)set.Tables[0].Rows[rowIndex][0],
                Naam = (string)set.Tables[0].Rows[rowIndex][1],
                Prijs = (string)set.Tables[0].Rows[rowIndex][2],
                Grootte = (string)set.Tables[0].Rows[rowIndex][3],
                Kleur = (string)set.Tables[0].Rows[rowIndex][4],
                Beschrijving = (string)set.Tables[0].Rows[rowIndex][5],
                Voorraad = (int)set.Tables[0].Rows[rowIndex][6],
                Categorie = (string)set.Tables[0].Rows[rowIndex][7],
                CategorieId = (int)set.Tables[0].Rows[rowIndex][8],
                Actief = (bool)set.Tables[0].Rows[rowIndex][9],
            };
        }

        public static Categorie DataSetToCategorie(DataSet set, int rowIndex)
        {
            return new Categorie()
            {
                Id = (int)set.Tables[0].Rows[rowIndex][0],
                Naam = (string)set.Tables[0].Rows[rowIndex][1],
                Actief = (bool)set.Tables[0].Rows[rowIndex][2],
                Aantal = (int)set.Tables[0].Rows[rowIndex][3],
            };
        }

        public static Klant DataSetToKlant(DataSet set, int rowIndex)
        {
            return new Klant()
            {
                Id = (long)set.Tables[0].Rows[rowIndex][0],
                UserName = (string)set.Tables[0].Rows[rowIndex][1],
                Email = (string)set.Tables[0].Rows[rowIndex][2],
                KlantId = (long)set.Tables[0].Rows[rowIndex][3],
                Postcode = (string)set.Tables[0].Rows[rowIndex][4],
                Huisnummer = (string)set.Tables[0].Rows[rowIndex][5],
            };
        }

        public static Bestelling DataSetToBestelling(DataSet set, int rowIndex)
        {
            return new Bestelling()
            {
                Besteldatum = (DateTime)set.Tables[0].Rows[rowIndex][0],
                Leverdatum = (DateTime)set.Tables[0].Rows[rowIndex][1],
                Totaalprijs = (string)set.Tables[0].Rows[rowIndex][2],
            };
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
