﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Models
{
    public class ProductViewModel
    {
        public List<ProductDetailViewModel> ProductDetailViewModels { get; set; } = new List<ProductDetailViewModel>();
    }
}
