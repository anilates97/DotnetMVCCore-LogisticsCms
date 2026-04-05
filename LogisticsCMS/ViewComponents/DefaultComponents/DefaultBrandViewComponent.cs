using Microsoft.AspNetCore.Mvc;
using LogisticsCMS.Services.BrandService;

namespace LogisticsCMS.ViewComponents.DefaultComponents
{
    public class DefaultBrandViewComponent : ViewComponent
    {
        private readonly IBrandService _brandService;

        public DefaultBrandViewComponent(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var brands = await _brandService.GetAllBrandsAsync();
            return View(brands);
        }
    }
}

