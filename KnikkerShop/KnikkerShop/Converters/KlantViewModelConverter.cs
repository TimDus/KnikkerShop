using KnikkerShop.Interfaces;
using KnikkerShop.Models;
using LibraryKnikker.Core.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Converters
{
    public class KlantViewModelConverter : IViewModelConverter<Klant, KlantDetailViewmodel>
    {
        public List<KlantDetailViewmodel> ModelsToViewModels(List<Klant> models)
        {
            throw new NotImplementedException();
        }

        public KlantDetailViewmodel ModelToViewModel(Klant model)
        {
            KlantDetailViewmodel vm = new KlantDetailViewmodel()
            {
                Id = model.Id,
                Huisnummer = model.Huisnummer,
                Postcode = model.Postcode,
                UserName = model.UserName,
                Email = model.Email,
                KlantId = model.KlantId,
            };

            return vm;
        }

        public Klant ViewModelToModel(KlantDetailViewmodel viewModel)
        {
            Klant vm = new Klant()
            {
                Id = viewModel.Id,
                Huisnummer = viewModel.Huisnummer,
                Postcode = viewModel.Postcode,
                UserName = viewModel.UserName,
                Email = viewModel.Email,
                KlantId = viewModel.KlantId,
            };

            return vm;
        }
    }
}
