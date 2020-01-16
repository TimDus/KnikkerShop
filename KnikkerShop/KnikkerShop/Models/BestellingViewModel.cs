using System.Collections.Generic;

namespace KnikkerShop.Models
{
    public class BestellingViewModel
    {
        public List<BestellingDetailViewModel> bestellingDetailViewModels { get; set; } = new List<BestellingDetailViewModel>();
    }
}
