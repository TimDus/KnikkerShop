using System.ComponentModel.DataAnnotations;

namespace KnikkerShop.Models
{
    public class BaseAccountDetailViewmodel
    {
        [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }

        public long Id { get; set; }
    }
}
