using AutoMapper;
using LogisticsCMS.Dtos.Brand;
using LogisticsCMS.Services;
using LogisticsCMS.Settings;
using System.Linq.Expressions;
using BrandModel = LogisticsCMS.Models.Brand;

namespace LogisticsCMS.Services.Brand
{
    public class BrandService
        : MongoCrudServiceBase<
            BrandModel,
            CreateBrandDto,
            UpdateBrandDto,
            ResultBrandDto,
            GetBrandByIdDto
        >,
            IBrandService
    {
        public BrandService(
            DatabaseSettings databaseSettings,
            IMapper mapper,
            IMongoDbContext mongoDbContext
        )
            : base(databaseSettings.BrandCollectionName, mapper, mongoDbContext) { }

        protected override Expression<Func<BrandModel, bool>> BuildIdFilter(string id) =>
            brand => brand.BrandId == id;

        protected override string GetEntityId(BrandModel entity) => entity.BrandId;

        public Task CreateBrandAsync(CreateBrandDto createBrandDto) => CreateAsync(createBrandDto);

        public Task DeleteBrandAsync(string brandId) => DeleteAsync(brandId);

        public Task<List<ResultBrandDto>> GetAllBrandsAsync() => GetAllAsync();

        public Task<GetBrandByIdDto?> GetBrandByIdAsync(string brandId) => GetByIdAsync(brandId);

        public Task UpdateBrandAsync(UpdateBrandDto updateBrandDto) => UpdateAsync(updateBrandDto);
    }
}
