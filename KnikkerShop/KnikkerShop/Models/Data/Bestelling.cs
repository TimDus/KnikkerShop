using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Models.Data
{
    public class Bestelling : Entity
    {
        public long KlantId { get; set; }
        public DateTime Besteldatum { get; set; }
        public DateTime Leverdatum { get; set; }    
        public string Totaalprijs { get; set; }
        public string Postcode { get; set; }
        public string Huisnummer { get; set; }
        public  bool Actief { get; set; }
        public List<Product> Products { get; set; }
        public string Prijs { get; set; }
    }
}
