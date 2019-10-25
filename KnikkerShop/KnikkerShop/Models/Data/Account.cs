using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Models.Data
{
    public class Account : Entity
    {
        public Account()
        { }

        public Account(int id, string username, string email)
        {
            this.Id = id;
            this.UserName = username;
            this.Email = email;

            NormalizedUserName = UserName.ToUpper();
            NormalizedEmail = email.ToUpper();
        }

        public Account(int id, string username, string email, string password)
        {
            this.Id = id;
            this.UserName = username;
            this.Email = email;
            this.Password = password;

            NormalizedUserName = UserName.ToUpper();
            NormalizedEmail = email.ToUpper();
        }

        public Account(string username, string email)
        {
            this.UserName = username;
            this.Email = email;
        }

        public bool IsInRole(string roleName)
        {
            bool isInRole = false;

            if (roleName == "Klant")
                isInRole = true;
            else if (roleName == "beheerder")
                isInRole = true;

            return isInRole;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string NormalizedUserName { get; set; }
        public string NormalizedEmail { get; set; }
    }
}
