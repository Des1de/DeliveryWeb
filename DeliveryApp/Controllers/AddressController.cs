using DeliveryApp.Interfaces;
using DeliveryApp.Models;
using DeliveryApp.Repository;
using DeliveryApp.Services;
using DeliveryApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApp.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository; 
        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }



        public async Task<IActionResult> Index()
        {
            IEnumerable<Address> addresses = await _addressRepository.GetAll();
            return View(addresses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAddressViewModel addressVM)
        {
            if (ModelState.IsValid)
            {
                var address = new Address
                {
                    City = addressVM.City,
                    Street = addressVM.Street,
                    House = addressVM.House
                };
                _addressRepository.Add(address);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }

            return View(addressVM);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var address = await _addressRepository.GetByIdAsync(id);
            if (address == null) return View("Error");
            var addressVM = new EditAddressViewModel
            {
                City = address.City,
                Street = address.Street,
                House = address.House
                
            };
            return View(addressVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditAddressViewModel addressVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit address");
                return View("Edit", addressVM);
            }

            var userAddress = await _addressRepository.GetByIdAsyncNoTracking(id);

            if (userAddress == null)
            {
                return View("Error");
            }


            var address = new Address
            {
                Id = id,
                City= addressVM.City,
                Street= addressVM.Street,
                House= addressVM.House
            };

            _addressRepository.Update(address);

            return RedirectToAction("Index");
        }
    }
}

