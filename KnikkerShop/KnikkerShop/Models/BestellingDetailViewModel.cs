using LibraryKnikker.Core.DAL.Data;
using System;
using System.Collections.Generic;

namespace KnikkerShop.Models
{
    public class BestellingDetailViewModel
    {
        public long Id { get; set; }
        public long KlantId { get; set; }
        public List<Product> Products { get; set; }
        public int Aantal { get; set; }
        public DateTime Besteldatum { get; set; }
        public DateTime Leverdatum { get; set; }
        public string Prijs { get; set; }
        public string Postcode { get; set; }
        public string Huisnummer { get; set; }
        public bool Actief { get; set; }
    }
}
