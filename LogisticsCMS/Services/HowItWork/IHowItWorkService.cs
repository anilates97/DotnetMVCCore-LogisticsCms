using LogisticsCMS.Dtos.HowItWork;

namespace LogisticsCMS.Services.HowItWork
{
    public interface IHowItWorkService
        : ICrudService<
            CreateHowItWorkDto,
            UpdateHowItWorkDto,
            ResultHowItWorkDto,
            GetHowItWorkByIdDto
        >
    {
        Task<List<ResultHowItWorkDto>> GetAllHowItWorksAsync();
        Task CreateHowItWorkAsync(CreateHowItWorkDto createHowItWorkDto);
        Task UpdateHowItWorkAsync(UpdateHowItWorkDto updateHowItWorkDto);
        Task<GetHowItWorkByIdDto?> GetHowItWorkByIdAsync(string id);
        Task DeleteHowItWorkAsync(string id);
    }
}
