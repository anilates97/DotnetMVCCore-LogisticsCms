using AutoMapper;
using MongoDB.Driver;
using LogisticsCMS.Dtos.SliderDtos;
using LogisticsCMS.Models;
using LogisticsCMS.Settings;

namespace LogisticsCMS.Services.SliderService
{
    public class SliderService : ISliderService
    {
        private readonly IMongoCollection<Slider> _sliderCollection; // MongoDB koleksiyonunu temsil eden bir alan
        private readonly IMapper _mapper; // AutoMapper'Ä± kullanmak iÃ§in bir alan

        public SliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); // MongoDB istemcisi oluÅŸturuluyor
            var database = client.GetDatabase(_databaseSettings.DatabaseName); // VeritabanÄ± seÃ§iliyor
            _sliderCollection = database.GetCollection<Slider>(
                _databaseSettings.SliderCollectionName
            ); // Slider koleksiyonu seÃ§iliyor
            _mapper = mapper;
        }

        public async Task<List<ResultSliderDto>> GetAllSlidersAsync()
        {
            var sliders = await _sliderCollection.Find(s => true).ToListAsync(); // MongoDB koleksiyonundaki tÃ¼m slider'larÄ± getiriyoruz
            var result = _mapper.Map<List<ResultSliderDto>>(sliders); // Slider modelini ResultSliderDto'ya dÃ¶nÃ¼ÅŸtÃ¼rÃ¼yoruz
            return result;
        }

        public async Task CreateSliderAsync(CreateSliderDto createSliderDto)
        {
            var value = _mapper.Map<Slider>(createSliderDto); // CreateSliderDto nesnesini Slider modeline dÃ¶nÃ¼ÅŸtÃ¼rÃ¼yoruz
            await _sliderCollection.InsertOneAsync(value); // MongoDB koleksiyonuna yeni slider ekliyoruz
        }

        public async Task UpdateSliderAsync(UpdateSliderDto updateSliderDto)
        {
            var values = _mapper.Map<Slider>(updateSliderDto); // UpdateSliderDto nesnesini Slider modeline dÃ¶nÃ¼ÅŸtÃ¼rÃ¼yoruz
            await _sliderCollection.ReplaceOneAsync(
                s => s.SliderId == updateSliderDto.SliderId,
                values
            ); // MongoDB koleksiyonunda belirtilen id'ye sahip slider'Ä± gÃ¼ncelliyoruz
        }

        public async Task<GetSliderByIdDto> GetSliderByIdAsync(string id)
        {
            var value = await _sliderCollection.Find(s => s.SliderId == id).FirstOrDefaultAsync(); // MongoDB koleksiyonundan belirtilen id'ye sahip slider'Ä± getiriyoruz
            var result = _mapper.Map<GetSliderByIdDto>(value); // Slider modelini GetSliderByIdDto'ya dÃ¶nÃ¼ÅŸtÃ¼rÃ¼yoruz
            return result;
        }

        public async Task DeleteSliderAsync(string id)
        {
            await _sliderCollection.DeleteOneAsync(s => s.SliderId == id); // MongoDB koleksiyonundan belirtilen id'ye sahip slider'Ä± siliyoruz
        }
    }
}

