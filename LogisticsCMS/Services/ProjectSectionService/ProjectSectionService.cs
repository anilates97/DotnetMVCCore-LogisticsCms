using AutoMapper;
using MongoDB.Driver;
using LogisticsCMS.Dtos.ProjectSectionDtos;
using LogisticsCMS.Models;
using LogisticsCMS.Settings;

namespace LogisticsCMS.Services.ProjectSectionService
{
    public class ProjectSectionService : IProjectSectionService
    {
        private readonly IMongoCollection<ProjectSection> _projectSectionCollection;
        private readonly IMapper _mapper;

        public ProjectSectionService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _projectSectionCollection = database.GetCollection<ProjectSection>(
                databaseSettings.ProjectSectionCollectionName
            );
            _mapper = mapper;
        }

        public async Task<List<ResultProjectSectionDto>> GetAllProjectSectionsAsync()
        {
            var values = await _projectSectionCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProjectSectionDto>>(values);
        }

        public async Task CreateProjectSectionAsync(CreateProjectSectionDto createProjectSectionDto)
        {
            var value = _mapper.Map<ProjectSection>(createProjectSectionDto);
            await _projectSectionCollection.InsertOneAsync(value);
        }

        public async Task UpdateProjectSectionAsync(UpdateProjectSectionDto updateProjectSectionDto)
        {
            var value = _mapper.Map<ProjectSection>(updateProjectSectionDto);
            await _projectSectionCollection.ReplaceOneAsync(
                x => x.ProjectSectionId == updateProjectSectionDto.ProjectSectionId,
                value
            );
        }

        public async Task<GetProjectSectionByIdDto> GetProjectSectionByIdAsync(string id)
        {
            var value = await _projectSectionCollection.Find(x => x.ProjectSectionId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProjectSectionByIdDto>(value);
        }

        public async Task DeleteProjectSectionAsync(string id)
        {
            await _projectSectionCollection.DeleteOneAsync(x => x.ProjectSectionId == id);
        }
    }
}

