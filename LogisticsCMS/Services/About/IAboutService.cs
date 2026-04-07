using LogisticsCMS.Dtos.About;

namespace LogisticsCMS.Services.About
{
    public interface IAboutService
        : ICrudService<CreateAboutDto, UpdateAboutDto, ResultAboutDto, GetAboutByIdDto>
    {
        Task<List<ResultAboutDto>> GetAllAboutsAsync();
        Task CreateAboutAsync(CreateAboutDto createAboutDto);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task<GetAboutByIdDto?> GetAboutByIdAsync(string id);
        Task DeleteAboutAsync(string id);
    }
}
