using DeliveryApp.Interfaces;
using DeliveryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Controllers
{
    public class MenuController : Controller
    {
        private readonly IDishRepository _dishRepository;

        public MenuController(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Dish> dishes =  await _dishRepository.GetAll();
            return View(dishes);
        }

        public async Task<IActionResult> DishDetail(int id)
        {
            Dish dish = await _dishRepository.GetByIdAsync(id);
            return View(dish);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Dish dish)
        {
            if(!ModelState.IsValid)
            {
                return View(dish);
            }
            _dishRepository.Add(dish);
            return RedirectToAction("Index");
        }
    }
}
