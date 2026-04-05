using LogisticsCMS.Dtos.BrandDtos;
using LogisticsCMS.Services.BrandService;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IActionResult> BrandList()
        {
            var brands = await _brandService.GetAllBrandsAsync();
            return View(brands);
        }

        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createBrandDto);
            }
            await _brandService.CreateBrandAsync(createBrandDto);
            return RedirectToAction("BrandList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            var brand = await _brandService.GetBrandByIdAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            var newBrand = new GetBrandByIdDto
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName,
                ImageUrl = brand.ImageUrl,
                IsStatus = brand.IsStatus,
            };
            return View(newBrand);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateBrandDto);
            }
            await _brandService.UpdateBrandAsync(updateBrandDto);
            return RedirectToAction("BrandList");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return RedirectToAction("BrandList");
        }
    }
}
