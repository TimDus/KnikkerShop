using KnikkerShop.Interfaces;
using KnikkerShop.Models;
using KnikkerShop.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Converters
{
    public class ProductViewModelConverter : IViewModelConverter<Product, ProductDetailViewModel>
    {
        public ProductDetailViewModel ModelToViewModel(Product model)
        {
            return new ProductDetailViewModel
            {
                Id = model.Id,
                Naam = model.Naam,
                Prijs = model.Prijs,
                Grootte = model.Grootte,
                Kleur = model.Kleur,
                Beschrijving = model.Beschrijving,
                Plaatje = model.Plaatje,
                Voorraad = model.Voorraad,
                CategorieId = model.CategorieId
            };
        }

        public Product ViewModelToModel(ProductDetailViewModel vm)
        {
            return new Product()
            {
                Id = vm.Id,
                Naam = vm.Naam,
                Prijs = vm.Prijs,
                Grootte = vm.Grootte,
                Kleur = vm.Kleur,
                Beschrijving = vm.Beschrijving,
                Plaatje = vm.Plaatje,
                Voorraad = vm.Voorraad,
                CategorieId = vm.CategorieId
            };
        }
    }
}
