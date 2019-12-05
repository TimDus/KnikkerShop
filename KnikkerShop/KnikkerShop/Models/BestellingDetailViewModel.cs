using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Models
{
    public class BestellingDetailViewModel
    {
        public long id { get; set; }
        public long KlantId { get; set; }
        public long ProductId { get; set; }
        public int Aantal { get; set; }
        public DateTime Besteldatum { get; set; }
        public DateTime Leverdatum { get; set; }
        public string Prijs { get; set; }
        public string Postcode { get; set; }
        public string Huisnummer { get; set; }
    }
}
