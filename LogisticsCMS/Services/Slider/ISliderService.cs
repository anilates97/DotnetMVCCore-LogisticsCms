using LogisticsCMS.Dtos.Slider;

namespace LogisticsCMS.Services.Slider
{
    public interface ISliderService
        : ICrudService<CreateSliderDto, UpdateSliderDto, ResultSliderDto, GetSliderByIdDto>
    {
        Task<List<ResultSliderDto>> GetAllSlidersAsync();
        Task CreateSliderAsync(CreateSliderDto createSliderDto);
        Task UpdateSliderAsync(UpdateSliderDto updateSliderDto);
        Task<GetSliderByIdDto?> GetSliderByIdAsync(string id);
        Task DeleteSliderAsync(string id);
    }
}
