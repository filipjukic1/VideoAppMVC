using Javni_admin_modul.Data.Services;
using Javni_admin_modul.Data.Static;
using Javni_admin_modul.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Javni_admin_modul.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class GenresController : Controller
    {
        private readonly IGenresService _service;

        public GenresController(IGenresService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allGenres = await _service.GetAllAsync();
            return View(allGenres);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Description")] Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View(genre);
            }
            await _service.AddAsync(genre);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var genreDetails = await _service.GetByIdAsync(id);

            if (genreDetails == null) return View("NotFound");
            return View(genreDetails);

        }


        public async Task<IActionResult> Edit(int id)
        {
            var genreDetails = await _service.GetByIdAsync(id);

            if (genreDetails == null) return View("NotFound");

            return View(genreDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return View(genre);
            }
            await _service.UpdateAsync(id, genre);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var genreDetails = await _service.GetByIdAsync(id);

            if (genreDetails == null) return View("NotFound");

            return View(genreDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genreDetails = await _service.GetByIdAsync(id);

            if (genreDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
