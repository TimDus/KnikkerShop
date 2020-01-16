using KnikkerShop.Converters;
using KnikkerShop.Helper;
using KnikkerShop.Models;
using LibraryKnikker.Core.BLL.Repositories;
using LibraryKnikker.Core.DAL.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KnikkerShop.Controllers
{
    public class WinkelwagenController : Controller
    {
        // Repos
        private readonly ProductRepository productRepository;

        // Converter 
        private readonly ProductViewModelConverter converter = new ProductViewModelConverter();


        public WinkelwagenController
            (
                ProductRepository productRepository
            )
        {
            this.productRepository = productRepository;
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

        public IActionResult AddWinkelwagen(long id)
        {

            if (SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart") == null)
            {
                EersteItem(id);
            }
            else
            {
                MeerdereItems(id);
            }
            return RedirectToAction("Index");
        }

        private int BestaatWagen(List<Product> cart, long id)
        {


            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Id.Equals(id))
                {
                    return i;
                }
            }

            return -1;
        }

        private int Bestaat(long id)
        {
            List<Product> cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        public IActionResult Delete(long id)
        {
            List<Product> cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            int index = Bestaat(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private void SetSession(List<Product> cart)
        {
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        }

        private List<Product> GetSession()
        {
            List<Product> cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            return cart;
        }

        private void EersteItem(long id)
        {
            List<Product> cart = new List<Product>();
            Product p = productRepository.GetById(id);
            p.Aantal = 1;
            cart.Add(p);

            SetSession(cart);
        }

        private void MeerdereItems(long id)
        {
            List<Product> cart = SessionHelper.GetObjectFromJson<List<Product>>(HttpContext.Session, "cart");
            int index = BestaatWagen(cart, id);
            if (index != -1)
            {
                cart[index].Aantal++;
                SetSession(cart);
            }
            else
            {
                Product p = productRepository.GetById(id);
                p.Aantal = 1;
                cart.Add(p);
                SetSession(cart);
            }
        }
    }
}
