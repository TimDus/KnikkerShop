﻿using System.Collections.Generic;

namespace KnikkerShop.Models
{
    public class ProductDetailViewModel
    {
        public long Id { get; set; }
        public string Naam { get; set; }
        public string Prijs { get; set; }
        public string Grootte { get; set; }
        public string Kleur { get; set; }
        public string Beschrijving { get; set; }
        public byte[] Plaatje { get; set; }
        public int Voorraad { get; set; }
        public long CategorieId { get; set; }
        public string Categorie { get; set; }
        public bool Actief { get; set; }
        public List<CategorieDetailViewModel> CategorieList { get; set; }
    }
}
