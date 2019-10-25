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
            CategorieViewModel vm = new CategorieViewModel();
            List<Categorie> categories = new List<Categorie>();
            categories = categorieRepository.GetAll();
            vm.CategorieDetailViewModels = converter.ModelsToViewModels(categories);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Creëer()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Aanpassen(long id)
        {
            Categorie categorie = categorieRepository.GetById(id);
            CategorieDetailViewModel vm = converter.ModelToViewModel(categorie);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Creëer(CategorieDetailViewModel vm)
        {
            // Check if model is valid
            if (ModelState.IsValid)
            {
                Categorie categorie = converter.ViewModelToModel(vm);
                long id = categorieRepository.Insert(categorie);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Aanpassen(CategorieDetailViewModel vm)
        {
            // Check if model is valid
            if (ModelState.IsValid)
            {
                Categorie categorie = converter.ViewModelToModel(vm);
                bool Update = categorieRepository.Update(categorie);    
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}