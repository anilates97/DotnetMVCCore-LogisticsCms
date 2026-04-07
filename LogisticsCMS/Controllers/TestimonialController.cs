using AutoMapper;
using LogisticsCMS.Dtos.Testimonial;
using LogisticsCMS.Services.Testimonial;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Controllers
{
    public class TestimonialController : CrudControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _testimonialService.GetAllTestimonialsAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialDto createDto)
        {
            return await SaveAndRedirectAsync(
                createDto,
                dto => _testimonialService.CreateTestimonialAsync(dto)
            );
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            return await LoadEditViewAsync(
                () => _testimonialService.GetTestimonialByIdAsync(id),
                value => _mapper.Map<UpdateTestimonialDto>(value)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateTestimonialDto updateDto)
        {
            return await SaveAndRedirectAsync(
                updateDto,
                dto => _testimonialService.UpdateTestimonialAsync(dto)
            );
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> Delete(string id)
        {
            return await DeleteAndRedirectAsync(() => _testimonialService.DeleteTestimonialAsync(id));
        }
    }
}
