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
            List<BestellingDetailViewModel> result = new List<BestellingDetailViewModel>();

            foreach (Bestelling b in models)
            {
                result.Add(ModelToViewModel(b));
            }

            return result;
        }

        public BestellingDetailViewModel ModelToViewModel(Bestelling model)
        {
            return new BestellingDetailViewModel
            {
                Id = model.Id,
                KlantId = model.KlantId,
                Products = model.Products,
                Besteldatum = model.Besteldatum,
                Leverdatum = model.Leverdatum,
                Prijs = model.Totaalprijs,
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