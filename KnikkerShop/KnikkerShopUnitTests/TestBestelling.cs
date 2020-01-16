using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KnikkerShopUnitTests
{
    [TestClass]
    public class TestBestelling
    {
        [Fact]
        public void BestellingConstructor()
        {
            int Id = 1;
            long KlantId = 1;
            DateTime Besteldatum = DateTime.Today;
        public DateTime Leverdatum { get; set; }
        public string Totaalprijs { get; set; }
        public string Postcode { get; set; }
        public string Huisnummer { get; set; }
        public bool Actief { get; set; }
        public List<Product> Products { get; set; }

        Admin admin = new Admin()
            {
                Id = id,
                AdminId = adminid,
                UserName = username,
                Email = email,
                Password = password,
                NormalizedUserName = username.ToUpper(),
                NormalizedEmail = email.ToUpper(),
            };

            Assert.Equal(1, admin.Id);
            Assert.Equal(1, admin.AdminId);
            Assert.Equal(username, admin.UserName);
            Assert.Equal(email, admin.Email);
            Assert.Equal(password, admin.Password);
            Assert.Equal(admin.NormalizedUserName, username.ToUpper());
            Assert.Equal(admin.NormalizedEmail, email.ToUpper());
        }
}
