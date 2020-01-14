using KnikkerShop.Interfaces;
using KnikkerShop.Models;
using KnikkerShop.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Converters
{
    public class BaseAccountViewModelConverter : IViewModelConverter<BaseAccount, BaseAccountDetailViewmodel>
    {
        public List<BaseAccountDetailViewmodel> ModelsToViewModels(List<BaseAccount> models)
        {
            throw new NotImplementedException();
        }

        public BaseAccountDetailViewmodel ModelToViewModel(BaseAccount model)
        {
            BaseAccountDetailViewmodel vm = new BaseAccountDetailViewmodel()
            {
                Id = model.Id,
                UserName = model.UserName,
                Email = model.Email,
            };

            return vm;
        }

        public BaseAccount ViewModelToModel(BaseAccountDetailViewmodel viewModel)
        {
            BaseAccount model = new BaseAccount()
            {
                Id = viewModel.Id,
                UserName = viewModel.UserName,
                Email = viewModel.Email,
            };

            return model;
        }
    }
}
