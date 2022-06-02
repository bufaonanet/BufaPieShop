using BufaPieShop.App.Repository;
using BufaPieShop.App.ViewModes;
using Microsoft.AspNetCore.Mvc;

namespace BufaPieShop.App.Components
{
    public class ShoppingCardSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCardSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
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
    }
}
