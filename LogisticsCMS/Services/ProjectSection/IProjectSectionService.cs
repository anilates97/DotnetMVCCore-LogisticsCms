using LogisticsCMS.Dtos.ProjectSection;

namespace LogisticsCMS.Services.ProjectSection
{
    public interface IProjectSectionService
        : ICrudService<
            CreateProjectSectionDto,
            UpdateProjectSectionDto,
            ResultProjectSectionDto,
            GetProjectSectionByIdDto
        >
    {
        Task<List<ResultProjectSectionDto>> GetAllProjectSectionsAsync();
        Task CreateProjectSectionAsync(CreateProjectSectionDto createProjectSectionDto);
        Task UpdateProjectSectionAsync(UpdateProjectSectionDto updateProjectSectionDto);
        Task<GetProjectSectionByIdDto?> GetProjectSectionByIdAsync(string id);
        Task DeleteProjectSectionAsync(string id);
    }
}
