using KnikkerShop.Interfaces;
using KnikkerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Converters
{
    public class CategorieViewModelConverter : IViewModelConverter<string, CategorieDetailViewModel>
    {
        public CategorieDetailViewModel ModelToViewModel(string model)
        {
            throw new NotImplementedException();
        }

        public string ViewModelToModel(CategorieDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
