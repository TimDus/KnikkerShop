using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KnikkerShop.Models;
using Microsoft.AspNetCore.Authorization;
using KnikkerShop.Models.Data;
using KnikkerShop.Converters;
using KnikkerShop.Repositories;

namespace KnikkerShop.Controllers
{
    public class ProductController : BaseController
    {
        // Repos
        private readonly ProductRepository productRepository;

        // Converter
        private readonly ProductViewModelConverter converter = new ProductViewModelConverter();

        public ProductController
            (
                ProductRepository productRepository
            )
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ProductViewModel vm = new ProductViewModel();

            return View(vm);
        }

        [HttpGet]
        public IActionResult Creëer()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Aanpassen()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Info()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "beheerder")]
        public IActionResult Create(ProductDetailViewModel vm)
        {
            // Check if model is valid
            if (ModelState.IsValid)
            {
                Product product = converter.ViewModelToModel(vm);
                bool created = productRepository.Insert(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View(vm);
            }
        }
    }
}
