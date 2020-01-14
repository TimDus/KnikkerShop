using KnikkerShop.Converters;
using KnikkerShop.Helper;
using KnikkerShop.Models;
using KnikkerShop.Models.Data;
using KnikkerShop.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        private readonly BestellingRepository bestellingRepository;
        private readonly KlantRepository klantRepository;

        // Converter 
        private readonly ProductViewModelConverter productconverter = new ProductViewModelConverter();
        private readonly BestellingViewModelConverter bestellingconverter = new BestellingViewModelConverter();

        public BestellingController
            (
                ProductRepository productRepository,
                BestellingRepository bestellingRepository,
                KlantRepository klantRepository
            )
        {
            this.productRepository = productRepository;
            this.bestellingRepository = bestellingRepository;
            this.klantRepository = klantRepository;
        }

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

        [Authorize(Roles = "Klant")]
        [HttpPost]
        public IActionResult Index(WinkelwagenViewModel vm)
        {
            decimal subtotaal = 0;
            List<Product> cart = new List<Product>();
            Bestelling bestelling = new Bestelling
            {
                KlantId = GetUserId()
            };
            foreach (Product p in SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart"))
            {
                cart.Add(p);
            }
            bestelling.Products = cart;
            foreach(Product p in bestelling.Products)
            {
                subtotaal += Convert.ToDecimal(p.Prijs);
            }
            bestelling.Totaalprijs = subtotaal.ToString();
            Klant klant = klantRepository.GetById(bestelling.KlantId);
            bestelling.Huisnummer = klant.Huisnummer;
            bestelling.Postcode = klant.Postcode;
            bestelling.Leverdatum = vm.Leverdatum;
            long result = bestellingRepository.Insert(bestelling);
            if (result != -1)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Geplaatst");
            }
            return RedirectToAction("Mislukt");
        }

        public IActionResult Geplaatst()
        {
            return View();
        }

        public IActionResult Mislukt()
        {
            return View();
        }
    }

}
