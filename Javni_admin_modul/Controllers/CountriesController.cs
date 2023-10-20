using Javni_admin_modul.Data.Services;
using Javni_admin_modul.Data.Static;
using Javni_admin_modul.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Javni_admin_modul.Controllers
{

    [Authorize(Roles = UserRoles.Admin)]
    public class CountriesController : Controller
    {

        

        private readonly ICountriesService _service;

        public CountriesController(ICountriesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCountries = await _service.GetAllAsync();
            return View(allCountries);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Code,Name")] Country country)
        {
            if (ModelState.IsValid)
            {
                return View(country);
            }
            await _service.AddAsync(country);
            return RedirectToAction(nameof(Index));
        }
        //Get: COuntries/Details/{id}


        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var countryDetails = await _service.GetByIdAsync(id);

            if (countryDetails == null) return View("NotFound");
            return View(countryDetails);
            
        }


        public async Task<IActionResult> Edit(int id)
        {
            var countryDetails = await _service.GetByIdAsync(id);

            if (countryDetails == null) return View("NotFound");

            return View(countryDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name")] Country country)
        {
            if (ModelState.IsValid)
            {
                return View(country);
            }
            await _service.UpdateAsync(id, country);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var countryDetails = await _service.GetByIdAsync(id);

            if (countryDetails == null) return View("NotFound");

            return View(countryDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var countryDetails = await _service.GetByIdAsync(id);

            if (countryDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            
            return RedirectToAction(nameof(Index));
        }
    }
 }

