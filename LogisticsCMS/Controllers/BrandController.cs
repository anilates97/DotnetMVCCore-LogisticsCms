using AutoMapper;
using LogisticsCMS.Dtos.Brand;
using LogisticsCMS.Services.Brand;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Controllers
{
    public class BrandController : CrudControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await _brandService.GetAllBrandsAsync();
            return View(brands);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandDto createBrandDto)
        {
            return await SaveAndRedirectAsync(
                createBrandDto,
                dto => _brandService.CreateBrandAsync(dto)
            );
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            return await LoadEditViewAsync(
                () => _brandService.GetBrandByIdAsync(id),
                brand => _mapper.Map<UpdateBrandDto>(brand)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateBrandDto updateBrandDto)
        {
            return await SaveAndRedirectAsync(
                updateBrandDto,
                dto => _brandService.UpdateBrandAsync(dto)
            );
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> Delete(string id)
        {
            return await DeleteAndRedirectAsync(() => _brandService.DeleteBrandAsync(id));
        }
    }
}
