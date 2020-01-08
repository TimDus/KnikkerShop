using KnikkerShop.Interfaces;
using KnikkerShop.Models;
using KnikkerShop.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Converters
{
    public class BestellingViewModelConverter : IViewModelConverter<Bestelling, BestellingDetailViewModel>
    {
        public List<BestellingDetailViewModel> ModelsToViewModels(List<Bestelling> models)
        {
            throw new NotImplementedException();
        }

        public BestellingDetailViewModel ModelToViewModel(Bestelling model)
        {
            return new BestellingDetailViewModel
            {
                Id = model.Id,
                KlantId = model.KlantId,
                ProductIds = model.ProductIds,
                Besteldatum = model.Besteldatum,
                Leverdatum = model.Leverdatum,
                Prijs = model.Prijs,
                Postcode = model.Postcode,
                Huisnummer = model.Huisnummer,
                Actief = model.Actief
            };
        }

        public Bestelling ViewModelToModel(BestellingDetailViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}