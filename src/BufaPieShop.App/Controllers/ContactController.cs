using Microsoft.AspNetCore.Mvc;

namespace BufaPieShop.App.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
