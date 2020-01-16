using LibraryKnikker.Core.DAL.Data;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestKnikkerShop
{
    public class TestBestelling
    {
        [Fact]
        public void TestBestellingConstructor()
        {
            int id = 1;
            int klantid = 3;
            DateTime besteldatum = DateTime.Today;
            DateTime leverdatum = DateTime.Today;
            string totaalprijs = "10,99";
            string postcode = "5151";
            string huisnummer = "5E";
            bool actief = true;
            List<Product> products = new List<Product>();

            Bestelling testBestelling = new Bestelling()
            {
                Id = id,
                KlantId = klantid,
                Besteldatum = besteldatum,
                Leverdatum = leverdatum,
                Totaalprijs = totaalprijs,
                Postcode = postcode,
                Huisnummer = huisnummer,
                Actief = actief,
                Products = products
            };

            Assert.Equal(1, testBestelling.Id);
            Assert.Equal(3, testBestelling.KlantId);
            Assert.Equal(besteldatum, testBestelling.Besteldatum);
            Assert.Equal(leverdatum, testBestelling.Leverdatum);
            Assert.Equal(totaalprijs, testBestelling.Totaalprijs);
            Assert.Equal(postcode, testBestelling.Postcode);
            Assert.Equal(huisnummer, testBestelling.Huisnummer);
            Assert.Equal(actief, testBestelling.Actief);
            Assert.Equal(products, testBestelling.Products);
        }
    }
}
