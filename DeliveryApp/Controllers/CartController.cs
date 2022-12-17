using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
