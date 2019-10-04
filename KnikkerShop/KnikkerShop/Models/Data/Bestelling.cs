using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Models.Data
{
    public class Bestelling : Entity
    {
        int KlantId { get; set; }
        int ProductId { get; set; }
        int Aantal { get; set; }
        DateTime Besteldatum { get; set; }
        DateTime Leverdatum { get; set; }
        string Prijs { get; set; }
        string Postcode { get; set; }
        string Huisnummer { get; set; }
    }
}
