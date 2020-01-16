using KnikkerShop.Interfaces;
using KnikkerShop.Models;
using LibraryKnikker.Core.DAL.Data;
using System.Collections.Generic;

namespace KnikkerShop.Converters
{
    public class ProductViewModelConverter : IViewModelConverter<Product, ProductDetailViewModel>
    {
        public List<ProductDetailViewModel> ModelsToViewModels(List<Product> models)
        {
            List<ProductDetailViewModel> result = new List<ProductDetailViewModel>();

            foreach (Product p in models)
            {
                result.Add(ModelToViewModel(p));
            }

            return result;
        }

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
                Categorie = model.Categorie,
                Actief = model.Actief
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
                CategorieId = vm.CategorieId,
                Actief = vm.Actief,
            };
        }
    }
}
