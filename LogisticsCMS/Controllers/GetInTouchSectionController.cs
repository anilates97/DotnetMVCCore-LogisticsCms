using Microsoft.AspNetCore.Mvc;
using LogisticsCMS.Dtos.GetInTouchSectionDtos;
using LogisticsCMS.Services.GetInTouchSectionService;

namespace LogisticsCMS.Controllers
{
    public class GetInTouchSectionController : Controller
    {
        private readonly IGetInTouchSectionService _getInTouchSectionService;

        public GetInTouchSectionController(IGetInTouchSectionService getInTouchSectionService)
        {
            _getInTouchSectionService = getInTouchSectionService;
        }

        public async Task<IActionResult> GetInTouchSectionList()
        {
            var values = await _getInTouchSectionService.GetAllGetInTouchSectionsAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateGetInTouchSection()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGetInTouchSection(CreateGetInTouchSectionDto createGetInTouchSectionDto)
        {
            if (ModelState.IsValid)
            {
                await _getInTouchSectionService.CreateGetInTouchSectionAsync(createGetInTouchSectionDto);
                return RedirectToAction(nameof(GetInTouchSectionList));
            }

            return View(createGetInTouchSectionDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateGetInTouchSection(string id)
        {
            var value = await _getInTouchSectionService.GetGetInTouchSectionByIdAsync(id);
            if (value == null)
            {
                return NotFound();
            }

            var updateDto = new UpdateGetInTouchSectionDto
            {
                GetInTouchSectionId = value.GetInTouchSectionId,
                MainTitle = value.MainTitle,
                Description = value.Description,
                Feature1Title = value.Feature1Title,
                Feature1Description = value.Feature1Description,
                Feature2Title = value.Feature2Title,
                Feature2Description = value.Feature2Description,
                ImageUrl = value.ImageUrl,
                Status = value.Status
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGetInTouchSection(UpdateGetInTouchSectionDto updateGetInTouchSectionDto)
        {
            if (ModelState.IsValid)
            {
                await _getInTouchSectionService.UpdateGetInTouchSectionAsync(updateGetInTouchSectionDto);
                return RedirectToAction(nameof(GetInTouchSectionList));
            }

            return View(updateGetInTouchSectionDto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGetInTouchSection(string id)
        {
            await _getInTouchSectionService.DeleteGetInTouchSectionAsync(id);
            return RedirectToAction(nameof(GetInTouchSectionList));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSection(string id)
        {
            await _getInTouchSectionService.DeleteGetInTouchSectionAsync(id);
            return RedirectToAction(nameof(GetInTouchSectionList));
        }
    }
}

