using AutoMapper;
using LogisticsCMS.Dtos.Slider;
using LogisticsCMS.Services;
using LogisticsCMS.Settings;
using System.Linq.Expressions;
using SliderModel = LogisticsCMS.Models.Slider;

namespace LogisticsCMS.Services.Slider
{
    public class SliderService
        : MongoCrudServiceBase<
            SliderModel,
            CreateSliderDto,
            UpdateSliderDto,
            ResultSliderDto,
            GetSliderByIdDto
        >,
            ISliderService
    {
        public SliderService(
            IMapper mapper,
            DatabaseSettings databaseSettings,
            IMongoDbContext mongoDbContext
        )
            : base(databaseSettings.SliderCollectionName, mapper, mongoDbContext) { }

        protected override Expression<Func<SliderModel, bool>> BuildIdFilter(string id) =>
            slider => slider.SliderId == id;

        protected override string GetEntityId(SliderModel entity) => entity.SliderId;

        public Task<List<ResultSliderDto>> GetAllSlidersAsync() => GetAllAsync();

        public Task CreateSliderAsync(CreateSliderDto createSliderDto) => CreateAsync(createSliderDto);

        public Task UpdateSliderAsync(UpdateSliderDto updateSliderDto) => UpdateAsync(updateSliderDto);

        public Task<GetSliderByIdDto?> GetSliderByIdAsync(string id) => GetByIdAsync(id);

        public Task DeleteSliderAsync(string id) => DeleteAsync(id);
    }
}
