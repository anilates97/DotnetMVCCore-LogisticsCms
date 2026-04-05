using AutoMapper;
using MongoDB.Driver;
using LogisticsCMS.Dtos.GetInTouchSectionDtos;
using LogisticsCMS.Models;
using LogisticsCMS.Settings;

namespace LogisticsCMS.Services.GetInTouchSectionService
{
    public class GetInTouchSectionService : IGetInTouchSectionService
    {
        private readonly IMongoCollection<GetInTouchSection> _getInTouchSectionCollection;
        private readonly IMapper _mapper;

        public GetInTouchSectionService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _getInTouchSectionCollection = database.GetCollection<GetInTouchSection>(
                databaseSettings.GetInTouchSectionCollectionName
            );
            _mapper = mapper;
        }

        public async Task<List<ResultGetInTouchSectionDto>> GetAllGetInTouchSectionsAsync()
        {
            var values = await _getInTouchSectionCollection.Find(_ => true).ToListAsync();
            return _mapper.Map<List<ResultGetInTouchSectionDto>>(values);
        }

        public async Task CreateGetInTouchSectionAsync(CreateGetInTouchSectionDto createGetInTouchSectionDto)
        {
            var value = _mapper.Map<GetInTouchSection>(createGetInTouchSectionDto);
            await _getInTouchSectionCollection.InsertOneAsync(value);
        }

        public async Task UpdateGetInTouchSectionAsync(UpdateGetInTouchSectionDto updateGetInTouchSectionDto)
        {
            var value = _mapper.Map<GetInTouchSection>(updateGetInTouchSectionDto);
            await _getInTouchSectionCollection.ReplaceOneAsync(
                x => x.GetInTouchSectionId == updateGetInTouchSectionDto.GetInTouchSectionId,
                value
            );
        }

        public async Task<GetGetInTouchSectionByIdDto> GetGetInTouchSectionByIdAsync(string id)
        {
            var value = await _getInTouchSectionCollection
                .Find(x => x.GetInTouchSectionId == id)
                .FirstOrDefaultAsync();
            return _mapper.Map<GetGetInTouchSectionByIdDto>(value);
        }

        public async Task DeleteGetInTouchSectionAsync(string id)
        {
            await _getInTouchSectionCollection.DeleteOneAsync(x => x.GetInTouchSectionId == id);
        }
    }
}

