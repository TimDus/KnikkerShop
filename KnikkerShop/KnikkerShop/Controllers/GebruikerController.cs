using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnikkerShop.Converters;
using KnikkerShop.Models;
using KnikkerShop.Models.Data;
using KnikkerShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KnikkerShop.Controllers
{
    public class GebruikerController : BaseController
    {
        private readonly BestellingRepository bestellingRepository;
        private readonly KlantRepository klantRepository;
        private readonly AccountRepository accountRepository;

        // Converter 
        private readonly KlantViewModelConverter klantConverter = new KlantViewModelConverter();
        private readonly BestellingViewModelConverter bestellingConverter = new BestellingViewModelConverter();
        private readonly BaseAccountViewModelConverter accountConverter = new BaseAccountViewModelConverter();

        public GebruikerController
            (
                KlantRepository klantRepository,
                BestellingRepository bestellingRepository,
                AccountRepository accountRepository
            )
        {
            this.klantRepository = klantRepository;
            this.bestellingRepository = bestellingRepository;
            this.accountRepository = accountRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            BaseAccountDetailViewmodel vm = klantConverter.ModelToViewModel(klantRepository.GetById(GetUserId()));
            return View(vm);
        }

        [HttpGet]
        public IActionResult Woonplaats()
        {
            BaseAccountDetailViewmodel vm = klantConverter.ModelToViewModel(klantRepository.GetById(GetUserId()));
            return View(vm);
        }

        [HttpPost]
        public IActionResult Woonplaats(KlantDetailViewmodel vm)
        {
            Klant klant = klantConverter.ViewModelToModel(vm);
            klant.Id = GetUserId();
            klantRepository.Update(klant);
            return RedirectToAction("Index", "Gebruiker");
        }

        [HttpGet]
        public IActionResult Account()
        {
            BaseAccountDetailViewmodel vm = klantConverter.ModelToViewModel(klantRepository.GetById(GetUserId()));
            return View(vm);
        }

        [HttpPost]
        public IActionResult Account(BaseAccountDetailViewmodel vm)
        {
            BaseAccount baseAccount = accountConverter.ViewModelToModel(vm);
            baseAccount.Id = GetUserId();
            accountRepository.Update(baseAccount);
            return RedirectToAction("Index", "Gebruiker");
        }

        [HttpGet]
        public IActionResult BestelGeschiedenis()
        {
            return View();
        }
    }
}