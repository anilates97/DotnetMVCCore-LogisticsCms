using LogisticsCMS.Dtos.HowItWorkDtos;

namespace LogisticsCMS.Services.HowItWorkService
{
    public interface IHowItWorkService
    {
        Task<List<ResultHowItWorkDto>> GetAllHowItWorksAsync();
        Task CreateHowItWorkAsync(CreateHowItWorkDto createHowItWorkDto);
        Task UpdateHowItWorkAsync(UpdateHowItWorkDto updateHowItWorkDto);
        Task<GetHowItWorkByIdDto> GetHowItWorkByIdAsync(string id);
        Task DeleteHowItWorkAsync(string id);
    }
}

