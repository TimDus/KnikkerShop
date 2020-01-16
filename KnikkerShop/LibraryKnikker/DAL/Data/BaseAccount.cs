namespace LibraryKnikker.Core.DAL.Data
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

        public BaseAccount(long id, string userName, string email)
        {
            Id = id;
            UserName = userName;
            Email = email;
            NormalizedEmail = email.ToUpper();
        }

        public BaseAccount(long id, string userName, string email, string password, int roleid)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Password = password;
            RoleId = roleid;
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