using AutoMapper;
using LogisticsCMS.Dtos.GetInTouchSection;
using LogisticsCMS.Services;
using LogisticsCMS.Settings;
using System.Linq.Expressions;
using GetInTouchSectionModel = LogisticsCMS.Models.GetInTouchSection;

namespace LogisticsCMS.Services.GetInTouchSection
{
    public class GetInTouchSectionService
        : MongoCrudServiceBase<
            GetInTouchSectionModel,
            CreateGetInTouchSectionDto,
            UpdateGetInTouchSectionDto,
            ResultGetInTouchSectionDto,
            GetInTouchSectionByIdDto
        >,
            IGetInTouchSectionService
    {
        public GetInTouchSectionService(
            IMapper mapper,
            DatabaseSettings databaseSettings,
            IMongoDbContext mongoDbContext
        )
            : base(databaseSettings.GetInTouchSectionCollectionName, mapper, mongoDbContext) { }

        protected override Expression<Func<GetInTouchSectionModel, bool>> BuildIdFilter(string id) =>
            section => section.GetInTouchSectionId == id;

        protected override string GetEntityId(GetInTouchSectionModel entity) =>
            entity.GetInTouchSectionId;

        public Task<List<ResultGetInTouchSectionDto>> GetAllGetInTouchSectionsAsync() => GetAllAsync();

        public Task CreateGetInTouchSectionAsync(CreateGetInTouchSectionDto createGetInTouchSectionDto) =>
            CreateAsync(createGetInTouchSectionDto);

        public Task UpdateGetInTouchSectionAsync(UpdateGetInTouchSectionDto updateGetInTouchSectionDto) =>
            UpdateAsync(updateGetInTouchSectionDto);

        public Task<GetInTouchSectionByIdDto?> GetInTouchSectionByIdAsync(string id) =>
            GetByIdAsync(id);

        public Task DeleteGetInTouchSectionAsync(string id) => DeleteAsync(id);
    }
}
