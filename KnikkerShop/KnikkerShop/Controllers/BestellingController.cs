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
        private readonly ProductRepository  productRepository;
        private readonly BestellingRepository bestellingRepository;

        // Converter 
        private readonly ProductViewModelConverter productconverter = new ProductViewModelConverter();
        private readonly BestellingViewModelConverter bestellingconverter = new BestellingViewModelConverter();

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

        public IActionResult Bestellen()
        {
            List<Product> cart = new List<Product>();
            foreach (Product p in SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart"))
            {
                cart.Add(p);
            }
            return View(cart);
        }

        [HttpPost]
        public IActionResult Plaatsen()
        {
            Bestelling bestelling = new Bestelling();
            List<Product> cart = new List<Product>();
            foreach (Product p in SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart"))
            {
                cart.Add(p);
            }
            foreach(Product product in cart)
            {
                bestelling.ProductIds.Add(product.Id);
            }
            bestellingRepository.Insert(bestelling);
            HttpContext.Session.Clear();
            return RedirectToAction("Geplaatst");
        }
    }

}
