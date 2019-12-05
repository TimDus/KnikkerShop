using KnikkerShop.Converters;
using KnikkerShop.Helper;
using KnikkerShop.Models;
using KnikkerShop.Models.Data;
using KnikkerShop.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnikkerShop.Controllers
{
    public class BestellingController : BaseController
    {
        // Repos
        private readonly ProductRepository productRepository;

        // Converter 
        private readonly ProductViewModelConverter converter = new ProductViewModelConverter();

        public IActionResult Index()
        {
            WinkelwagenViewModel cart = new WinkelwagenViewModel();
            try
            {
                foreach (Product p in SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart"))
                {
                    cart.Producten.Add(p);
                }
            }
            catch
            {
                return View();
            }
            return View(cart);
        }
    }
}
