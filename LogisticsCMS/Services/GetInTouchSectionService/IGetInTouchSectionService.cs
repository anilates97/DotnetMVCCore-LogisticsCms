using LogisticsCMS.Dtos.GetInTouchSectionDtos;

namespace LogisticsCMS.Services.GetInTouchSectionService
{
    public interface IGetInTouchSectionService
    {
        Task<List<ResultGetInTouchSectionDto>> GetAllGetInTouchSectionsAsync();
        Task CreateGetInTouchSectionAsync(CreateGetInTouchSectionDto createGetInTouchSectionDto);
        Task UpdateGetInTouchSectionAsync(UpdateGetInTouchSectionDto updateGetInTouchSectionDto);
        Task<GetGetInTouchSectionByIdDto> GetGetInTouchSectionByIdAsync(string id);
        Task DeleteGetInTouchSectionAsync(string id);
    }
}

