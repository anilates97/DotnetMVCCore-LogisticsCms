using Microsoft.AspNetCore.Mvc;
using LogisticsCMS.Services.Testimonial;

namespace LogisticsCMS.ViewComponents.DefaultComponents
{
    public class DefaultTestimonialViewComponent : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public DefaultTestimonialViewComponent(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _testimonialService.GetAllTestimonialsAsync();
            var activeValues = values.Where(x => x.Status).ToList();
            return View(activeValues.Any() ? activeValues : values);
        }
    }
}

