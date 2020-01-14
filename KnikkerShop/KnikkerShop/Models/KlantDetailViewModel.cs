using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Models
{
    public class KlantDetailViewmodel : BaseAccountDetailViewmodel
    {
        public long KlantId { get; set; }
        public string Postcode { get; set; }
        public string Huisnummer { get; set; }
    }
}
