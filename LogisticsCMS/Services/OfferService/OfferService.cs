using AutoMapper;
using MongoDB.Driver;
using LogisticsCMS.Dtos.OfferDtos;
using LogisticsCMS.Models;
using LogisticsCMS.Settings;

namespace LogisticsCMS.Services.OfferService
{
    public class OfferService : IOfferService
    {
        private readonly IMongoCollection<Offer> _OfferCollection; // MongoDB koleksiyonunu temsil eden bir alan
        private readonly IMapper _mapper; // AutoMapper'Ä± kullanmak iÃ§in bir alan

        public OfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); // MongoDB istemcisi oluÅŸturuluyor
            var database = client.GetDatabase(_databaseSettings.DatabaseName); // VeritabanÄ± seÃ§iliyor
            _OfferCollection = database.GetCollection<Offer>(_databaseSettings.OfferCollectionName); // Offer koleksiyonu seÃ§iliyor
            _mapper = mapper;
        }

        public async Task<List<ResultOfferDto>> GetAllOffersAsync()
        {
            var Offers = await _OfferCollection.Find(s => true).ToListAsync(); // MongoDB koleksiyonundaki tÃ¼m Offer'larÄ± getiriyoruz
            var result = _mapper.Map<List<ResultOfferDto>>(Offers); // Offer modelini ResultOfferDto'ya dÃ¶nÃ¼ÅŸtÃ¼rÃ¼yoruz
            return result;
        }

        public async Task CreateOfferAsync(CreateOfferDto createOfferDto)
        {
            var value = _mapper.Map<Offer>(createOfferDto); // CreateOfferDto nesnesini Offer modeline dÃ¶nÃ¼ÅŸtÃ¼rÃ¼yoruz
            await _OfferCollection.InsertOneAsync(value); // MongoDB koleksiyonuna yeni Offer ekliyoruz
        }

        public async Task UpdateOfferAsync(UpdateOfferDto updateOfferDto)
        {
            var values = _mapper.Map<Offer>(updateOfferDto); // UpdateOfferDto nesnesini Offer modeline dÃ¶nÃ¼ÅŸtÃ¼rÃ¼yoruz
            await _OfferCollection.ReplaceOneAsync(
                s => s.OfferId == updateOfferDto.OfferId,
                values
            ); // MongoDB koleksiyonunda belirtilen id'ye sahip Offer'Ä± gÃ¼ncelliyoruz
        }

        public async Task<GetOfferByIdDto> GetOfferByIdAsync(string id)
        {
            var value = await _OfferCollection.Find(s => s.OfferId == id).FirstOrDefaultAsync(); // MongoDB koleksiyonundan belirtilen id'ye sahip Offer'Ä± getiriyoruz
            var result = _mapper.Map<GetOfferByIdDto>(value); // Offer modelini GetOfferByIdDto'ya dÃ¶nÃ¼ÅŸtÃ¼rÃ¼yoruz
            return result;
        }

        public async Task DeleteOfferAsync(string id)
        {
            await _OfferCollection.DeleteOneAsync(s => s.OfferId == id); // MongoDB koleksiyonundan belirtilen id'ye sahip Offer'Ä± siliyoruz
        }
    }
}

