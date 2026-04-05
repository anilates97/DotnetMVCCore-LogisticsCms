namespace LogisticsCMS.Services.BrandService
{
    using LogisticsCMS.Dtos.BrandDtos;

    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandsAsync();
        Task<GetBrandByIdDto> GetBrandByIdAsync(string brandId);
        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task DeleteBrandAsync(string brandId);
    }
}

