using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnikkerShop.Converters;
using KnikkerShop.Models;
using KnikkerShop.Models.Data;
using KnikkerShop.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KnikkerShop.Controllers
{
    public class CategorieController : BaseController
    {
        // Repos
        private readonly CategorieRepository categorieRepository;

        // Converter
        private readonly CategorieViewModelConverter converter = new CategorieViewModelConverter();

        public CategorieController
            (
                CategorieRepository categorieRepository
            )
        {
            this.categorieRepository = categorieRepository;
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
        public IActionResult Create(CategorieDetailViewModel vm)
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