﻿using KnikkerShop.Converters;
using KnikkerShop.Helper;
using KnikkerShop.Models;
using LibraryKnikker.Core.BLL.Repositories;
using LibraryKnikker.Core.DAL.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace KnikkerShop.Controllers
{
    [Authorize(Roles = "Klant")]
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

        [AllowAnonymous]
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
            Bestelling bestelling = new Bestelling
            {
                KlantId = GetUserId()
            };
            bestelling = ConstructBestelling(bestelling);
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

        public Bestelling ConstructBestelling(Bestelling bestelling)
        {
            Klant klant = klantRepository.GetById(bestelling.KlantId);
            //Product lijst
            List<Product> cart = new List<Product>();
            foreach (Product p in SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart"))
            {
                cart.Add(p);
            }
            bestelling.Products = cart;

            //Prijs gedeelte
            decimal subtotaal = 0;
            foreach (Product p in bestelling.Products)
            {
                subtotaal = subtotaal + Convert.ToDecimal(p.Prijs);
            }
            bestelling.Totaalprijs = subtotaal.ToString();

            //Klant Data
            bestelling.Huisnummer = klant.Huisnummer;
            bestelling.Postcode = klant.Postcode;

            return bestelling;
        }
    }
}
