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
        public List<ProductDetailViewModel> ModelsToViewModels(List<Product> models)
        {
            List<ProductDetailViewModel> productDetailViewModels = new List<ProductDetailViewModel>();

            foreach (Product p in models)
            {
                ProductDetailViewModel vm = new ProductDetailViewModel()
                {
                    Id = p.Id,
                    Voorraad = p.Voorraad,
                    CategorieId = p.CategorieId,
                    Prijs = p.Prijs,
                    Naam = p.Naam,
                    Kleur = p.Kleur,
                    Grootte = p.Grootte,
                    Beschrijving = p.Beschrijving,
                    Categorie = p.Categorie,
                    Actief = p.Actief,
                };
                productDetailViewModels.Add(vm);
            }

            return productDetailViewModels;
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

        public List<Product> ViewModelsToModels(List<ProductDetailViewModel> viewModels)
        {
            throw new NotImplementedException();
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
