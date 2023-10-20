using Javni_admin_modul.Data;
using Javni_admin_modul.Data.Services;
using Javni_admin_modul.Data.Static;
using Javni_admin_modul.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Javni_admin_modul.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class VideosController : Controller
    {
        private readonly IVideosService _service;

        public VideosController(IVideosService service)
        {
            _service =  service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allVideos = await _service.GetAllAsync();
            return View(allVideos);
        }
        [AllowAnonymous]

        public async Task<IActionResult> Filter(string searchString)

        {
            var allVideos = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allVideos.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
            
            return View("Index", allVideos);
        }

        //GET: VIDEOS/DETAILS/[id}

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails=await _service.GetVideoByIdAsync(id);
            return View(movieDetails);
        }

        //GET; VIDEOS/CREATE
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewVideoDropdownsValues();

            ViewBag.Genres = new SelectList(movieDropdownsData.Genres, "Id", "Name");
            ViewBag.Tags = new SelectList(movieDropdownsData.Tags, "Id", "Name");
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Create(NewVideoVM video)
        {
            if (ModelState.IsValid) 
            {
                var movieDropdownsData = await _service.GetNewVideoDropdownsValues();
                ViewBag.Genres = new SelectList(movieDropdownsData.Genres, "Id", "Name");
                ViewBag.Tags = new SelectList(movieDropdownsData.Tags, "Id", "Name");
                return View(video);
            }
            await _service.AddNewVideoAsync(video);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails= await _service.GetVideoByIdAsync(id);

            if (movieDetails == null) return View("NotFound");

            var response = new NewVideoVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                TotalTime = movieDetails.TotalTime,
                StreamingUrl = movieDetails.StreamingUrl,
                Image=movieDetails.Image,
                GenreId=movieDetails.GenreId,
                CreatedAt=movieDetails.CreatedAt,
                TagIds=movieDetails.VideoTags.Select(n=>n.TagId).ToList(),
            };

            var movieDropdownsData = await _service.GetNewVideoDropdownsValues();

            ViewBag.Genres = new SelectList(movieDropdownsData.Genres, "Id", "Name");
            ViewBag.Tags = new SelectList(movieDropdownsData.Tags, "Id", "Name");
            return View(response);
        }


        [HttpPost]

        public async Task<IActionResult> Edit(int id, NewVideoVM video)
        {
            if (id != video.Id) return View("NotFound");
            
            if (ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewVideoDropdownsValues();
                ViewBag.Genres = new SelectList(movieDropdownsData.Genres, "Id", "Name");
                ViewBag.Tags = new SelectList(movieDropdownsData.Tags, "Id", "Name");
                return View(video);
            }
            await _service.UpdateVideoAsync(video);
            return RedirectToAction(nameof(Index));
        }


    }
}
