using AutoMapper;
using LogisticsCMS.Dtos.ProjectSection;
using LogisticsCMS.Services;
using LogisticsCMS.Settings;
using System.Linq.Expressions;
using ProjectSectionModel = LogisticsCMS.Models.ProjectSection;

namespace LogisticsCMS.Services.ProjectSection
{
    public class ProjectSectionService
        : MongoCrudServiceBase<
            ProjectSectionModel,
            CreateProjectSectionDto,
            UpdateProjectSectionDto,
            ResultProjectSectionDto,
            GetProjectSectionByIdDto
        >,
            IProjectSectionService
    {
        public ProjectSectionService(
            IMapper mapper,
            DatabaseSettings databaseSettings,
            IMongoDbContext mongoDbContext
        )
            : base(databaseSettings.ProjectSectionCollectionName, mapper, mongoDbContext) { }

        protected override Expression<Func<ProjectSectionModel, bool>> BuildIdFilter(string id) =>
            section => section.ProjectSectionId == id;

        protected override string GetEntityId(ProjectSectionModel entity) => entity.ProjectSectionId;

        public Task<List<ResultProjectSectionDto>> GetAllProjectSectionsAsync() => GetAllAsync();

        public Task CreateProjectSectionAsync(CreateProjectSectionDto createProjectSectionDto) =>
            CreateAsync(createProjectSectionDto);

        public Task UpdateProjectSectionAsync(UpdateProjectSectionDto updateProjectSectionDto) =>
            UpdateAsync(updateProjectSectionDto);

        public Task<GetProjectSectionByIdDto?> GetProjectSectionByIdAsync(string id) =>
            GetByIdAsync(id);

        public Task DeleteProjectSectionAsync(string id) => DeleteAsync(id);
    }
}
