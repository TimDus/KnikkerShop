using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnikkerShop.Converters;
using KnikkerShop.Helper;
using KnikkerShop.Models;
using KnikkerShop.Models.Data;
using KnikkerShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KnikkerShop.Controllers
{
    public class WebShopController : Controller
    {
        // Repos
        private readonly ProductRepository productRepository;

        // Converter 
        private readonly ProductViewModelConverter converter = new ProductViewModelConverter();

        public WebShopController
            (
                ProductRepository productRepository
            )
        {
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            ProductViewModel vm = new ProductViewModel();
            vm.ProductDetailViewModels = converter.ModelsToViewModels(productRepository.GetAll());

            return View(vm);
        }

        [HttpGet]
        public IActionResult Detail(long id)
        {
            ProductDetailViewModel vm = new ProductDetailViewModel();
            Product product = productRepository.GetById(id);
            vm = converter.ModelToViewModel(product);
            return View(vm);
        }
    }
}