using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Models
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Prijs { get; set; }
        public string Grootte { get; set; }
        public string Kleur { get; set; }
        public string Beschrijving { get; set; }
        public byte[] Plaatje { get; set; }
        public int Voorraad { get; set; }
        public int CategorieId { get; set; }
    }
}
