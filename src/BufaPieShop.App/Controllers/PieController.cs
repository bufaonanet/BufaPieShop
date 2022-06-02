using BufaPieShop.App.Models;
using BufaPieShop.App.ViewModes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BufaPieShop.App.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, 
                             ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        //public IActionResult List()
        //{
        //    var piesListViewModel = new PieListViewModel
        //    {
        //        Pies = _pieRepository.AllPies,
        //        CurrentCategory = "Toarta doce"
        //    };

        //    return View(piesListViewModel);
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory;

            if (string.IsNullOrWhiteSpace(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All Pies";
            }
            else
            {
                pies = _pieRepository.AllPies
                    .Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId);

                currentCategory = _categoryRepository.AllCategories
                    .FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }


            var piesListViewModel = new PieListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory
            };

            return View(piesListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null) return NotFound();

            return View(pie);
        }
    }
}
