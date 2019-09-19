using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Models.Data
{
    public class BaseAccount
    {
        public BaseAccount()
        { }

        public BaseAccount(int id, string username, string email)
        {
            this.Id = id;
            this.Naam = username;
            this.Email = email;

            NormalizedNaam = Naam.ToUpper();
            NormalizedEmail = email.ToUpper();
        }

        public BaseAccount(int id, string username, string email, string password)
        {
            this.Id = id;
            this.Naam = username;
            this.Email = email;
            this.Password = password;

            NormalizedNaam = Naam.ToUpper();
            NormalizedEmail = email.ToUpper();
        }

        public BaseAccount(string username, string email)
        {
            this.Naam = username;
            this.Email = email;
        }

        public long Id { get; set; }
        public string Naam { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string NormalizedNaam { get; set; }
        public string NormalizedEmail { get; set; }
    }
}
