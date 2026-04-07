using LogisticsCMS.Dtos.Brand;
using LogisticsCMS.Services.Brand;

namespace LogisticsCMS.Tests.Helpers;

internal sealed class FakeBrandService : IBrandService
{
    public List<ResultBrandDto> Brands { get; set; } = [];
    public GetBrandByIdDto? BrandById { get; set; }
    public CreateBrandDto? CreatedBrand { get; private set; }
    public UpdateBrandDto? UpdatedBrand { get; private set; }
    public string? DeletedBrandId { get; private set; }
    public Exception? ExceptionOnCreate { get; set; }
    public Exception? ExceptionOnUpdate { get; set; }
    public Exception? ExceptionOnDelete { get; set; }
    public Exception? ExceptionOnGetById { get; set; }

    public Task CreateAsync(CreateBrandDto createDto) => throw new NotImplementedException();

    public Task CreateBrandAsync(CreateBrandDto createBrandDto)
    {
        if (ExceptionOnCreate is not null)
        {
            throw ExceptionOnCreate;
        }

        CreatedBrand = createBrandDto;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(string id) => throw new NotImplementedException();

    public Task DeleteBrandAsync(string brandId)
    {
        if (ExceptionOnDelete is not null)
        {
            throw ExceptionOnDelete;
        }

        DeletedBrandId = brandId;
        return Task.CompletedTask;
    }

    public Task<List<ResultBrandDto>> GetAllAsync() => throw new NotImplementedException();

    public Task<List<ResultBrandDto>> GetAllBrandsAsync() => Task.FromResult(Brands);

    public Task<GetBrandByIdDto?> GetBrandByIdAsync(string brandId)
    {
        if (ExceptionOnGetById is not null)
        {
            throw ExceptionOnGetById;
        }

        return Task.FromResult(BrandById);
    }

    public Task<GetBrandByIdDto?> GetByIdAsync(string id) => throw new NotImplementedException();

    public Task UpdateAsync(UpdateBrandDto updateDto) => throw new NotImplementedException();

    public Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
    {
        if (ExceptionOnUpdate is not null)
        {
            throw ExceptionOnUpdate;
        }

        UpdatedBrand = updateBrandDto;
        return Task.CompletedTask;
    }
}
