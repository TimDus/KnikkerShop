using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using KnikkerShop.Models;
using Microsoft.AspNetCore.Authorization;
using KnikkerShop.Converters;
using LibraryKnikker.Core.BLL.Repositories;
using LibraryKnikker.Core.DAL.Data;

namespace KnikkerShop.Controllers
{
    [Authorize(Roles = "Beheerder")]
    public class ProductController : BaseController
    {
        // Repos
        private readonly ProductRepository productRepository;
        private readonly CategorieRepository categorieRepository;

        // Converter
        private readonly ProductViewModelConverter productConverter = new ProductViewModelConverter();
        private readonly CategorieViewModelConverter categorieConverter = new CategorieViewModelConverter();

        public ProductController
            (
                ProductRepository productRepository,
                CategorieRepository categorieRepository
            )
        {
            this.productRepository = productRepository;
            this.categorieRepository = categorieRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ProductViewModel vm = new ProductViewModel();
            List<Product> products = new List<Product>();
            products = productRepository.GetAll();
            vm.ProductDetailViewModels = productConverter.ModelsToViewModels(products);

            return View(vm);
        }

        [HttpGet]
        public IActionResult Creëer()
        {
            ProductDetailViewModel vm = new ProductDetailViewModel
            {
                CategorieList = categorieConverter.ModelsToViewModels(categorieRepository.GetAll())
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Aanpassen(long id)
        {
            ProductDetailViewModel vm = new ProductDetailViewModel();
            Product product = productRepository.GetById(id);
            vm = productConverter.ModelToViewModel(product);
            vm.CategorieList = categorieConverter.ModelsToViewModels(categorieRepository.GetAll());
            return View(vm);
        }

        [HttpGet]
        public IActionResult Detail(long id)
        {
            ProductDetailViewModel vm = new ProductDetailViewModel();
            Product product = productRepository.GetById(id);
            vm = productConverter.ModelToViewModel(product);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Activeren(long id)
        {
            ProductDetailViewModel vm = new ProductDetailViewModel();
            Product product = productRepository.GetById(id);
            vm = productConverter.ModelToViewModel(product);
            productRepository.Activation(id, product.Actief);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Creëer(ProductDetailViewModel vm)
        {
            // Check if model is valid
            if (ModelState.IsValid)
            {
                Product product = productConverter.ViewModelToModel(vm);
                long Id = productRepository.Insert(product);
                return RedirectToAction("Aanpassen", new { Id });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Aanpassen(ProductDetailViewModel vm)
        {
            Product product = productConverter.ViewModelToModel(vm);
            bool result = productRepository.Update(product);
            return RedirectToAction("Index");
        }
    }
}
