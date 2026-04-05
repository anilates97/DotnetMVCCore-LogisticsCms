using Microsoft.AspNetCore.Mvc;
using LogisticsCMS.Dtos.TestimonialDtos;
using LogisticsCMS.Services.TestimonialService;

namespace LogisticsCMS.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IActionResult> TestimonialList()
        {
            var values = await _testimonialService.GetAllTestimonialsAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(
            CreateTestimonialDto createTestimonialDto
        )
        {
            if (ModelState.IsValid)
            {
                await _testimonialService.CreateTestimonialAsync(createTestimonialDto);
                return RedirectToAction(nameof(TestimonialList));
            }

            return View(createTestimonialDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(string id)
        {
            var value = await _testimonialService.GetTestimonialByIdAsync(id);
            if (value == null)
            {
                return NotFound();
            }

            var updateDto = new UpdateTestimonialDto
            {
                TestimonialId = value.TestimonialId,
                NameSurname = value.NameSurname,
                Title = value.Title,
                ImageUrl = value.ImageUrl,
                ReviewDetails = value.ReviewDetails,
                ReviewScore = value.ReviewScore,
                Status = value.Status,
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(
            UpdateTestimonialDto updateTestimonialDto
        )
        {
            if (ModelState.IsValid)
            {
                await _testimonialService.UpdateTestimonialAsync(updateTestimonialDto);
                return RedirectToAction(nameof(TestimonialList));
            }

            return View(updateTestimonialDto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction(nameof(TestimonialList));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteReview(string id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction(nameof(TestimonialList));
        }
    }
}

