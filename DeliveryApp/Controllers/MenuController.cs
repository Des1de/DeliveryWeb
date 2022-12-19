using DeliveryApp.Interfaces;
using DeliveryApp.Models;
using DeliveryApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Controllers
{
    public class MenuController : Controller
    {
        private readonly IDishRepository _dishRepository;
        private readonly IPhotoService _photoService;

        public MenuController(IDishRepository dishRepository, IPhotoService photoService)
        {
            _dishRepository = dishRepository;
            _photoService = photoService;
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
        public async Task<IActionResult> Create(CreateDishViewModel dishVM)
        {
            if(ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(dishVM.Image);
                var dish = new Dish
                {
                    Name = dishVM.Name,
                    Description = dishVM.Description,
                    Image = result.Url.ToString(),
                    Price = dishVM.Price

                };
                _dishRepository.Add(dish);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(dishVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dish = await _dishRepository.GetByIdAsync(id);
            if (dish == null) return View("Error");
            var dishVM = new EditDishViewModel
            {
                Name = dish.Name,
                Description = dish.Description,
                URL = dish.Image,
                Price = dish.Price
            };
            return View(dishVM); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditDishViewModel dishVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit dish");
                return View("Edit", dishVM);
            }

            var userDish = await _dishRepository.GetByIdAsyncNoTracking(id);

            if (userDish == null)
            {
                return View("Error");
            }

            var photoResult = await _photoService.AddPhotoAsync(dishVM.Image);

            if (photoResult.Error != null)
            {
                ModelState.AddModelError("Image", "Photo upload failed");
                return View(dishVM);
            }

            if (!string.IsNullOrEmpty(userDish.Image))
            {
                _ = _photoService.DeletePhotoAsync(userDish.Image);
            }

            var dish = new Dish
            {
                Id = id,
                Name = dishVM.Name,
                Description = dishVM.Description,
                Image = photoResult.Url.ToString(),
                Price = dishVM.Price
            };

            _dishRepository.Update(dish);

            return RedirectToAction("Index");
        }
    }
}
