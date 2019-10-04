using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Models
{
    public class CategorieViewModel
    {
        public List<CategorieDetailViewModel> Categorien { get; set; } = new List<CategorieDetailViewModel>();
    }
}
