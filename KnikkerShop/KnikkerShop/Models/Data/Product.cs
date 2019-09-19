using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Models.Data
{
    public class Product
    {
        int ProductId { get; set; }
        string Naam { get; set; }
        int Prijs { get; set; }
        string Grootte { get; set; }
        string Kleur { get; set; }
        string Beschrijving { get; set; }
        byte[] Plaatje { get; set; }
        int Voorraad { get; set; }
    }
}
