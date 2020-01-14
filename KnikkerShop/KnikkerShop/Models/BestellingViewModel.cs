using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Models
{
    public class BestellingViewModel
    {
        public List<BestellingDetailViewModel> bestellingDetailViewModels { get; set; } = new List<BestellingDetailViewModel>();
    }
}
