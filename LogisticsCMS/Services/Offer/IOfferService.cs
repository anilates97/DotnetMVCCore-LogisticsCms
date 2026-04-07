using LogisticsCMS.Dtos.Offer;

namespace LogisticsCMS.Services.Offer
{
    public interface IOfferService
        : ICrudService<CreateOfferDto, UpdateOfferDto, ResultOfferDto, GetOfferByIdDto>
    {
        Task<List<ResultOfferDto>> GetAllOffersAsync();
        Task CreateOfferAsync(CreateOfferDto createOfferDto);
        Task UpdateOfferAsync(UpdateOfferDto updateOfferDto);
        Task<GetOfferByIdDto?> GetOfferByIdAsync(string id);
        Task DeleteOfferAsync(string id);
    }
}
