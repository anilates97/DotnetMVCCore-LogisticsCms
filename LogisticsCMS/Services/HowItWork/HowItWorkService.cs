using AutoMapper;
using LogisticsCMS.Dtos.HowItWork;
using LogisticsCMS.Services;
using LogisticsCMS.Settings;
using System.Linq.Expressions;
using HowItWorkModel = LogisticsCMS.Models.HowItWork;

namespace LogisticsCMS.Services.HowItWork
{
    public class HowItWorkService
        : MongoCrudServiceBase<
            HowItWorkModel,
            CreateHowItWorkDto,
            UpdateHowItWorkDto,
            ResultHowItWorkDto,
            GetHowItWorkByIdDto
        >,
            IHowItWorkService
    {
        public HowItWorkService(
            IMapper mapper,
            DatabaseSettings databaseSettings,
            IMongoDbContext mongoDbContext
        )
            : base(databaseSettings.HowItWorkCollectionName, mapper, mongoDbContext) { }

        protected override Expression<Func<HowItWorkModel, bool>> BuildIdFilter(string id) =>
            howItWork => howItWork.HowItWorkId == id;

        protected override string GetEntityId(HowItWorkModel entity) => entity.HowItWorkId;

        public Task<List<ResultHowItWorkDto>> GetAllHowItWorksAsync() => GetAllAsync();

        public Task CreateHowItWorkAsync(CreateHowItWorkDto createHowItWorkDto) =>
            CreateAsync(createHowItWorkDto);

        public Task UpdateHowItWorkAsync(UpdateHowItWorkDto updateHowItWorkDto) =>
            UpdateAsync(updateHowItWorkDto);

        public Task<GetHowItWorkByIdDto?> GetHowItWorkByIdAsync(string id) => GetByIdAsync(id);

        public Task DeleteHowItWorkAsync(string id) => DeleteAsync(id);
    }
}
