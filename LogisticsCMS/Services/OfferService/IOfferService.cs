using LogisticsCMS.Dtos.OfferDtos;

namespace LogisticsCMS.Services.OfferService
{
    public interface IOfferService
    {
        Task<List<ResultOfferDto>> GetAllOffersAsync();
        Task CreateOfferAsync(CreateOfferDto createOfferDto);
        Task UpdateOfferAsync(UpdateOfferDto updateOfferDto);
        Task<GetOfferByIdDto> GetOfferByIdAsync(string id);
        Task DeleteOfferAsync(string id);
    }
}

