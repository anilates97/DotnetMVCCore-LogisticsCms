namespace LogisticsCMS.Services.BrandService
{
    using AutoMapper;
    using MongoDB.Driver;
    using LogisticsCMS.Dtos.BrandDtos;
    using LogisticsCMS.Models;
    using LogisticsCMS.Settings;

    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _brandCollection;
        private readonly IMapper _mapper;

        public BrandService(IDatabaseSettings _databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var value = _mapper.Map<Brand>(createBrandDto);
            await _brandCollection.InsertOneAsync(value);
        }

        public async Task DeleteBrandAsync(string brandId)
        {
            await _brandCollection.DeleteOneAsync(b => b.BrandId == brandId);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandsAsync()
        {
            var brands = await _brandCollection.Find(_ => true).ToListAsync();
            return _mapper.Map<List<ResultBrandDto>>(brands);
        }

        public async Task<GetBrandByIdDto> GetBrandByIdAsync(string brandId)
        {
            var brand = await _brandCollection
                .Find(b => b.BrandId == brandId)
                .FirstOrDefaultAsync();
            return _mapper.Map<GetBrandByIdDto>(brand);
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var brand = _mapper.Map<Brand>(updateBrandDto);
            await _brandCollection.ReplaceOneAsync(b => b.BrandId == brand.BrandId, brand);
        }
    }
}

