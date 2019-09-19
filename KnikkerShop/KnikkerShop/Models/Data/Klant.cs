using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Models.Data
{
    public class Klant : BaseAccount
    {
        int KlantId { get; set; }
        string Postcode { get; set; }
        string Huisnummer { get; set; }
    }
}
