using DeliveryApp.Interfaces;
using DeliveryApp.Models;
using DeliveryApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderDishRepository _orderDishRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        public OrderController(IOrderDishRepository orderDishRepository, IOrderRepository orderRepository, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _orderDishRepository = orderDishRepository;
            _orderRepository = orderRepository;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Order> orders = await _orderRepository.GetAll();
            List<OrderViewModel> result = new();
            foreach(var order in orders)
            {
                var userId = _httpContextAccessor.HttpContext.User.GetUserId();
                var user = await _userRepository.GetUserById(userId);
                var orderViewModel = new OrderViewModel
                {
                    Id = order.Id,
                    TotalPrice = order.TotalPrice,
                    DeliveryAddress = order.DeliveryAddress,
                    RestarauntAddress = order.RestarauntAddress,
                    UserEmail = user.Email
                };
                result.Add(orderViewModel);
            };
            return View(result);
        }

        public async Task<IActionResult> UserOrders()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();
            IEnumerable<Order> orders = await _orderRepository.GetAllByUserId(userId);
            List<OrderViewModel> result = new();
            foreach (var order in orders)
            {
                var orderViewModel = new OrderViewModel
                {
                    Id = order.Id,
                    TotalPrice = order.TotalPrice,
                    DeliveryAddress = order.DeliveryAddress,
                    RestarauntAddress = order.RestarauntAddress,
                };
                result.Add(orderViewModel);
            };
            return View(result); 
        }

        public async Task<IActionResult> OrderDetail(int orderId)
        {
            IEnumerable <OrderDish> orderDishes = await _orderDishRepository.GetAllByOrderId(orderId);
            return View(orderDishes);
        }
    }
}
