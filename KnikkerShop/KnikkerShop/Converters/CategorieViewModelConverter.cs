using KnikkerShop.Interfaces;
using KnikkerShop.Models;
using KnikkerShop.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Converters
{
    public class CategorieViewModelConverter : IViewModelConverter<Categorie, CategorieDetailViewModel>
    {
        public List<CategorieDetailViewModel> ModelsToViewModels(List<Categorie> models)
        {
            List<CategorieDetailViewModel> result = new List<CategorieDetailViewModel>();

            foreach (Categorie d in models)
            {
                result.Add(ModelToViewModel(d));
            }

            return result;
        }

        public CategorieDetailViewModel ModelToViewModel(Categorie model)
        {
            CategorieDetailViewModel vm = new CategorieDetailViewModel()
            {
                Id = model.Id,
                Naam = model.Naam,
                Actief = model.Actief
            };

            return vm;
        }

        public Categorie ViewModelToModel(CategorieDetailViewModel viewModel)
        {
            Categorie c = new Categorie()
            {
                Naam = viewModel.Naam,
                Id = viewModel.Id,
                Actief = viewModel.Actief
            };

            return c;
        }
    }
}
