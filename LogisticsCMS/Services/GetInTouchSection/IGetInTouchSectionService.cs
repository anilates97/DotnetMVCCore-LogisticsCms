using LogisticsCMS.Dtos.GetInTouchSection;

namespace LogisticsCMS.Services.GetInTouchSection
{
    public interface IGetInTouchSectionService
        : ICrudService<
            CreateGetInTouchSectionDto,
            UpdateGetInTouchSectionDto,
            ResultGetInTouchSectionDto,
            GetInTouchSectionByIdDto
        >
    {
        Task<List<ResultGetInTouchSectionDto>> GetAllGetInTouchSectionsAsync();
        Task CreateGetInTouchSectionAsync(CreateGetInTouchSectionDto createGetInTouchSectionDto);
        Task UpdateGetInTouchSectionAsync(UpdateGetInTouchSectionDto updateGetInTouchSectionDto);
        Task<GetInTouchSectionByIdDto?> GetInTouchSectionByIdAsync(string id);
        Task DeleteGetInTouchSectionAsync(string id);
    }
}
