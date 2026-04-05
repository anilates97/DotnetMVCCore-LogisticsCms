using AutoMapper;
using MongoDB.Driver;
using LogisticsCMS.Dtos.HowItWorkDtos;
using LogisticsCMS.Models;
using LogisticsCMS.Settings;

namespace LogisticsCMS.Services.HowItWorkService
{
    public class HowItWorkService : IHowItWorkService
    {
        private readonly IMongoCollection<HowItWork> _howItWorkCollection;
        private readonly IMapper _mapper;

        public HowItWorkService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _howItWorkCollection = database.GetCollection<HowItWork>(
                databaseSettings.HowItWorkCollectionName
            );
            _mapper = mapper;
        }

        public async Task<List<ResultHowItWorkDto>> GetAllHowItWorksAsync()
        {
            var values = await _howItWorkCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultHowItWorkDto>>(values);
        }

        public async Task CreateHowItWorkAsync(CreateHowItWorkDto createHowItWorkDto)
        {
            var value = _mapper.Map<HowItWork>(createHowItWorkDto);
            await _howItWorkCollection.InsertOneAsync(value);
        }

        public async Task UpdateHowItWorkAsync(UpdateHowItWorkDto updateHowItWorkDto)
        {
            var value = _mapper.Map<HowItWork>(updateHowItWorkDto);
            await _howItWorkCollection.ReplaceOneAsync(
                x => x.HowItWorkId == updateHowItWorkDto.HowItWorkId,
                value
            );
        }

        public async Task<GetHowItWorkByIdDto> GetHowItWorkByIdAsync(string id)
        {
            var value = await _howItWorkCollection.Find(x => x.HowItWorkId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetHowItWorkByIdDto>(value);
        }

        public async Task DeleteHowItWorkAsync(string id)
        {
            await _howItWorkCollection.DeleteOneAsync(x => x.HowItWorkId == id);
        }
    }
}

