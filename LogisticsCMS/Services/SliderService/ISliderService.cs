using LogisticsCMS.Dtos.SliderDtos;

namespace LogisticsCMS.Services.SliderService
{
    public interface ISliderService
    {
        Task<List<ResultSliderDto>> GetAllSlidersAsync();
        Task CreateSliderAsync(CreateSliderDto createSliderDto);
        Task UpdateSliderAsync(UpdateSliderDto updateSliderDto);
        Task<GetSliderByIdDto> GetSliderByIdAsync(string id);
        Task DeleteSliderAsync(string id);
    }
}

