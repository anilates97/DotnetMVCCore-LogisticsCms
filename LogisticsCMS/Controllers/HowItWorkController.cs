using Microsoft.AspNetCore.Mvc;
using LogisticsCMS.Dtos.HowItWorkDtos;
using LogisticsCMS.Services.HowItWorkService;

namespace LogisticsCMS.Controllers
{
    public class HowItWorkController : Controller
    {
        private readonly IHowItWorkService _howItWorkService;

        public HowItWorkController(IHowItWorkService howItWorkService)
        {
            _howItWorkService = howItWorkService;
        }

        public async Task<IActionResult> HowItWorkList()
        {
            var values = await _howItWorkService.GetAllHowItWorksAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateHowItWork()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateHowItWork(CreateHowItWorkDto createHowItWorkDto)
        {
            if (ModelState.IsValid)
            {
                await _howItWorkService.CreateHowItWorkAsync(createHowItWorkDto);
                return RedirectToAction(nameof(HowItWorkList));
            }

            return View(createHowItWorkDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateHowItWork(string id)
        {
            var value = await _howItWorkService.GetHowItWorkByIdAsync(id);
            if (value == null)
            {
                return NotFound();
            }

            var updateDto = new UpdateHowItWorkDto
            {
                HowItWorkId = value.HowItWorkId,
                Title = value.Title,
                Description = value.Description,
                ImageUrl = value.ImageUrl,
                Status = value.Status
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateHowItWork(UpdateHowItWorkDto updateHowItWorkDto)
        {
            if (ModelState.IsValid)
            {
                await _howItWorkService.UpdateHowItWorkAsync(updateHowItWorkDto);
                return RedirectToAction(nameof(HowItWorkList));
            }

            return View(updateHowItWorkDto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteHowItWork(string id)
        {
            await _howItWorkService.DeleteHowItWorkAsync(id);
            return RedirectToAction(nameof(HowItWorkList));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteStep(string id)
        {
            await _howItWorkService.DeleteHowItWorkAsync(id);
            return RedirectToAction(nameof(HowItWorkList));
        }

        [HttpGet]
        public Task<IActionResult> UpdateStep(string id)
        {
            return UpdateHowItWork(id);
        }
    }
}

