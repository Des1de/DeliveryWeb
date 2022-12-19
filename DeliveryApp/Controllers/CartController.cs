using DeliveryApp.Data;
using DeliveryApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DeliveryApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        public IActionResult Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();  

            return View();
        }
    }
}
