using DeliveryApp.Data;
using DeliveryApp.Interfaces;
using DeliveryApp.Models;
using DeliveryApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace DeliveryApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartDishRepository _cartDishRepository;
        private readonly ICartRepository _cartRepository; 
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDishRepository _dishRepository;

        public CartController(ICartDishRepository cartDishRepository, ICartRepository cartRepository, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor, IDishRepository dishRepository)
        {
            _cartDishRepository = cartDishRepository;
            _cartRepository = cartRepository;
            _httpContextAccessor = httpContextAccessor;
            _dishRepository = dishRepository;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();  
            Cart cart = await _cartRepository.GetByUserIdAsync(userId);
            IEnumerable<CartDish> cartDishes = await _cartDishRepository.GetAllByCartId(cart.Id);
            return View(cartDishes);
        }

        

    }
}
