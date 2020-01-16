using KnikkerShop.Converters;
using KnikkerShop.Models;
using LibraryKnikker.Core.BLL.Repositories;
using LibraryKnikker.Core.DAL.Data;
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
            ProductViewModel vm = new ProductViewModel
            {
                ProductDetailViewModels = converter.ModelsToViewModels(productRepository.GetAll())
            };

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