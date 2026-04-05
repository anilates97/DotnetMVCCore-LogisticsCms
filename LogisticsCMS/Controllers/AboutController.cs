using Microsoft.AspNetCore.Mvc;
using LogisticsCMS.Dtos.AboutDtos;
using LogisticsCMS.Services.AboutService;

namespace LogisticsCMS.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> AboutList()
        {
            var abouts = await _aboutService.GetAllAboutsAsync();
            return View(abouts);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            if (ModelState.IsValid)
            {
                await _aboutService.CreateAboutAsync(createAboutDto);
                return RedirectToAction(nameof(AboutList));
            }

            return View(createAboutDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            var about = await _aboutService.GetAboutByIdAsync(id);
            if (about == null)
            {
                return NotFound();
            }

            var updateAboutDto = new UpdateAboutDto
            {
                AboutId = about.AboutId,
                Title = about.Title,
                Description = about.Description,
                ImageUrl = about.ImageUrl
            };

            return View(updateAboutDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            if (ModelState.IsValid)
            {
                await _aboutService.UpdateAboutAsync(updateAboutDto);
                return RedirectToAction(nameof(AboutList));
            }

            return View(updateAboutDto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction(nameof(AboutList));
        }
    }
}

