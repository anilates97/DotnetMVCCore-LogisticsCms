using LogisticsCMS.Dtos.Brand;

namespace LogisticsCMS.Services.Brand
{
    public interface IBrandService
        : ICrudService<CreateBrandDto, UpdateBrandDto, ResultBrandDto, GetBrandByIdDto>
    {
        Task<List<ResultBrandDto>> GetAllBrandsAsync();
        Task<GetBrandByIdDto?> GetBrandByIdAsync(string brandId);
        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task DeleteBrandAsync(string brandId);
    }
}
