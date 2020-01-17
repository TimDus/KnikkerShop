using System.Collections.Generic;

namespace KnikkerShop.Models
{
    public class ProductViewModel : ZoekViewModel
    {
        public List<ProductDetailViewModel> ProductDetailViewModels { get; set; } = new List<ProductDetailViewModel>();
    }
}
