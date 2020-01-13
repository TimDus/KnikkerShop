using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KnikkerShop.Controllers
{
    public class GebruikerController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Woonplaats()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Account()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BestelGeschiedenis()
        {
            return View();
        }
    }
}