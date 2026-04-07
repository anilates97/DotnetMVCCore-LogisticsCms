using AutoMapper;
using LogisticsCMS.Dtos.About;
using LogisticsCMS.Services;
using LogisticsCMS.Settings;
using System.Linq.Expressions;
using AboutModel = LogisticsCMS.Models.About;

namespace LogisticsCMS.Services.About
{
    public class AboutService
        : MongoCrudServiceBase<
            AboutModel,
            CreateAboutDto,
            UpdateAboutDto,
            ResultAboutDto,
            GetAboutByIdDto
        >,
            IAboutService
    {
        public AboutService(
            IMapper mapper,
            DatabaseSettings databaseSettings,
            IMongoDbContext mongoDbContext
        )
            : base(databaseSettings.AboutCollectionName, mapper, mongoDbContext) { }

        protected override Expression<Func<AboutModel, bool>> BuildIdFilter(string id) =>
            about => about.AboutId == id;

        protected override string GetEntityId(AboutModel entity) => entity.AboutId;

        public Task<List<ResultAboutDto>> GetAllAboutsAsync() => GetAllAsync();

        public Task CreateAboutAsync(CreateAboutDto createAboutDto) => CreateAsync(createAboutDto);

        public Task UpdateAboutAsync(UpdateAboutDto updateAboutDto) => UpdateAsync(updateAboutDto);

        public Task<GetAboutByIdDto?> GetAboutByIdAsync(string id) => GetByIdAsync(id);

        public Task DeleteAboutAsync(string id) => DeleteAsync(id);
    }
}
