using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
