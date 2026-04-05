using AutoMapper;
using MongoDB.Driver;
using LogisticsCMS.Dtos.AboutDtos;
using LogisticsCMS.Models;
using LogisticsCMS.Settings;

namespace LogisticsCMS.Services.AboutService
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;
        private readonly IMapper _mapper;

        public AboutService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
            _mapper = mapper;
        }

        public async Task<List<ResultAboutDto>> GetAllAboutsAsync()
        {
            var abouts = await _aboutCollection.Find(_ => true).ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(abouts);
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto);
            await _aboutCollection.InsertOneAsync(value);
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto);
            await _aboutCollection.ReplaceOneAsync(a => a.AboutId == updateAboutDto.AboutId, value);
        }

        public async Task<GetAboutByIdDto> GetAboutByIdAsync(string id)
        {
            var value = await _aboutCollection.Find(a => a.AboutId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetAboutByIdDto>(value);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _aboutCollection.DeleteOneAsync(a => a.AboutId == id);
        }
    }
}

