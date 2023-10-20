using Javni_admin_modul.Data;
using Javni_admin_modul.Data.Services;
using Javni_admin_modul.Data.Static;
using Javni_admin_modul.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Javni_admin_modul.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
    public class TagsController : Controller
    {
        private readonly ITagsService _service;

        public TagsController(ITagsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allTags = await _service.GetAllAsync();
            return View(allTags);
        }


        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var tagDetails=await _service.GetByIdAsync(id);
            if (tagDetails==null) return View("NotFound");
            return View(tagDetails);
            
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                return View(tag);
            }
            await _service.AddAsync(tag);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tagDetails = await _service.GetByIdAsync(id);

            if (tagDetails == null) return View("NotFound");

            return View(tagDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                return View(tag);
            }

            if (id==tag.Id)
            {
                await _service.UpdateAsync(id, tag);
                return RedirectToAction(nameof(Index));
            }
            return View(tag);
            
        }

        public async Task<IActionResult> Delete(int id)
        {
            var tagDetails = await _service.GetByIdAsync(id);

            if (tagDetails == null) return View("NotFound");

            return View(tagDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tagDetails = await _service.GetByIdAsync(id);

            if (tagDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
