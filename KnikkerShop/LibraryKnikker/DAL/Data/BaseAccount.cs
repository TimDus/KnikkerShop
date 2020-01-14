using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Models.Data
{
    public class BaseAccount : Entity
    {
        public BaseAccount()
        { }

        public long RoleId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NormalizedEmail { get; set; }
        public string Postcode { get; set; }
        public string Huisnummer { get; set; }

        public string NormalizedUserName { get { return UserName.ToUpper(); } set { UserName = value.ToUpper(); } }

        public BaseAccount(long id, string userName, string email)
        {
            Id = id;
            UserName = userName;
            Email = email;
            NormalizedUserName = userName.ToUpper();
            NormalizedEmail = email.ToUpper();
        }

        public BaseAccount(long id, string userName, string email, string password, int roleid)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Password = password;
            RoleId = roleid;
            if (userName != null)
            {
                NormalizedUserName = userName.ToUpper();
            }
            NormalizedEmail = email.ToUpper();
        }

        public string GetRole()
        {
            string role = "";
            switch (RoleId)
            {
                case 1:
                    role = "Beheerder";
                    break;
                case 2:
                    role = "Klant";
                    break;
                default:
                    break;
            }
            return role;
        }
    }
}