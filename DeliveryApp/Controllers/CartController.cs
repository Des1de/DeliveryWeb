using DeliveryApp.Data;
using DeliveryApp.Interfaces;
using DeliveryApp.Models;
using DeliveryApp.Repository;
using DeliveryApp.Services;
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
        private readonly IAddressRepository _addressRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDishRepository _orderDishRepository;
        private readonly IUserRepository _userRepository;

        public CartController(ICartDishRepository cartDishRepository, ICartRepository cartRepository, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor, IDishRepository dishRepository, IAddressRepository addressRepository, IOrderRepository orderRepository, IOrderDishRepository orderDishRepository, IUserRepository userRepository)
        {
            _cartDishRepository = cartDishRepository;
            _cartRepository = cartRepository;
            _httpContextAccessor = httpContextAccessor;
            _dishRepository = dishRepository;
            _addressRepository = addressRepository;
            _orderRepository = orderRepository;
            _orderDishRepository = orderDishRepository;
            _userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();  
            Cart cart = await _cartRepository.GetByUserIdAsync(userId);
            IEnumerable<CartDish> cartDishes = await _cartDishRepository.GetAllByCartId(cart.Id);
            return View(cartDishes);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var cartDishDetails = await _cartDishRepository.GetByIdAsync(id);
            if (cartDishDetails == null) return View("Error");
            return View(cartDishDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteCartDish(int id)
        {
            var cartDishDetails = await _cartDishRepository.GetByIdAsync(id);

            if (cartDishDetails == null)
            {
                return View("Error");
            }

            _cartDishRepository.Delete(cartDishDetails);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChooseAddress()
        {
            IEnumerable<Address> addresses= await _addressRepository.GetAll();
            return View(addresses);
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrder(int addressId)
        {
            if (ModelState.IsValid)
            {
                var address = await _addressRepository.GetByIdAsync(addressId+1); 
                var userId = _httpContextAccessor.HttpContext.User.GetUserId();
                var user = await _userRepository.GetUserById(userId);
                Cart cart = await _cartRepository.GetByUserIdAsync(userId);
                IEnumerable<CartDish> cartDishes = await _cartDishRepository.GetAllByCartId(cart.Id);
                Order order = new Order()
                {
                    TotalPrice = cartDishes.Sum(i => i.Price),
                    AddressId = addressId,
                    UserId = userId,
                    DeliveryAddress = user.HomeAddress,
                    RestarauntAddress = address.City + ", " + address.Street + ", " + address.House
                };
                _orderRepository.Add(order);
                foreach(var dish in cartDishes)
                {
                    OrderDish orderDish = new OrderDish()
                    {
                        DishId = dish.DishId,
                        Name = dish.Name,
                        Description = dish.Description,
                        Image = dish.Image,
                        OrderId = order.Id,
                        Price = dish.Price
                    };
                    _orderDishRepository.Add(orderDish);
                }

                var cartDishDetailsList = await _cartDishRepository.GetAllByCartId(cart.Id);

                foreach (var cartDishDetails in cartDishDetailsList)
                {
                    _cartDishRepository.Delete(cartDishDetails);
                }
                return RedirectToAction("Index");

                
            }
            else
            {
                ModelState.AddModelError("", "Adding to cart failed");
            }

            return View("Index");
        }
    }
}
