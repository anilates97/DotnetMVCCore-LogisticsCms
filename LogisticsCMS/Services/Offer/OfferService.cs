using AutoMapper;
using LogisticsCMS.Dtos.Offer;
using LogisticsCMS.Services;
using LogisticsCMS.Settings;
using System.Linq.Expressions;
using OfferModel = LogisticsCMS.Models.Offer;

namespace LogisticsCMS.Services.Offer
{
    public class OfferService
        : MongoCrudServiceBase<
            OfferModel,
            CreateOfferDto,
            UpdateOfferDto,
            ResultOfferDto,
            GetOfferByIdDto
        >,
            IOfferService
    {
        public OfferService(
            IMapper mapper,
            DatabaseSettings databaseSettings,
            IMongoDbContext mongoDbContext
        )
            : base(databaseSettings.OfferCollectionName, mapper, mongoDbContext) { }

        protected override Expression<Func<OfferModel, bool>> BuildIdFilter(string id) =>
            offer => offer.OfferId == id;

        protected override string GetEntityId(OfferModel entity) => entity.OfferId;

        public Task<List<ResultOfferDto>> GetAllOffersAsync() => GetAllAsync();

        public Task CreateOfferAsync(CreateOfferDto createOfferDto) => CreateAsync(createOfferDto);

        public Task UpdateOfferAsync(UpdateOfferDto updateOfferDto) => UpdateAsync(updateOfferDto);

        public Task<GetOfferByIdDto?> GetOfferByIdAsync(string id) => GetByIdAsync(id);

        public Task DeleteOfferAsync(string id) => DeleteAsync(id);
    }
}
