using BufaPieShop.App.Models;
using BufaPieShop.App.Repository;
using BufaPieShop.App.ViewModes;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BufaPieShop.App.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IPieRepository pieRepository,
                                      ShoppingCart shoppingCart)
        {
            _pieRepository = pieRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCardViewMode = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };


            return View(shoppingCardViewMode);
        }

        public RedirectToActionResult AddToShoppingCart(int pieId)
        {
            var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);

            if(selectedPie != null)
            {
                _shoppingCart.AddToCart(selectedPie, 1);
            }

            return RedirectToAction(nameof(Index));
        }

        public RedirectToActionResult RemoveToShoppingCard(int pieId)
        {
            var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);

            if (selectedPie != null)
            {
                _shoppingCart.RemoveFromCart(selectedPie);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
