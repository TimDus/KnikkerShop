using LibraryKnikker.Core.DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestKnikkerShop
{
    public class TestBaseAccount
    {
        [Fact]
        public void BaseAccountConstructor()
        {
            int id = 1;
            string username = "klant";
            string email = "mail@mail.mail";
            string password = "wachtwoord";

            BaseAccount baseAccount = new BaseAccount(id, username, email, password, 1)
            {
                NormalizedEmail = email.ToUpper(),
            };

            Assert.Equal(1, baseAccount.Id);
            Assert.Equal(username, baseAccount.UserName);
            Assert.Equal(email, baseAccount.Email);
            Assert.Equal(password, baseAccount.Password);
            Assert.Equal(baseAccount.NormalizedEmail, email.ToUpper());
        }
    }
}
