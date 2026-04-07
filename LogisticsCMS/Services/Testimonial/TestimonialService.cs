using AutoMapper;
using LogisticsCMS.Dtos.Testimonial;
using LogisticsCMS.Services;
using LogisticsCMS.Settings;
using System.Linq.Expressions;
using TestimonialModel = LogisticsCMS.Models.Testimonial;

namespace LogisticsCMS.Services.Testimonial
{
    public class TestimonialService
        : MongoCrudServiceBase<
            TestimonialModel,
            CreateTestimonialDto,
            UpdateTestimonialDto,
            ResultTestimonialDto,
            GetTestimonialByIdDto
        >,
            ITestimonialService
    {
        public TestimonialService(
            IMapper mapper,
            DatabaseSettings databaseSettings,
            IMongoDbContext mongoDbContext
        )
            : base(databaseSettings.TestimonialCollectionName, mapper, mongoDbContext) { }

        protected override Expression<Func<TestimonialModel, bool>> BuildIdFilter(string id) =>
            testimonial => testimonial.TestimonialId == id;

        protected override string GetEntityId(TestimonialModel entity) => entity.TestimonialId;

        public Task<List<ResultTestimonialDto>> GetAllTestimonialsAsync() => GetAllAsync();

        public Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto) =>
            CreateAsync(createTestimonialDto);

        public Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto) =>
            UpdateAsync(updateTestimonialDto);

        public Task<GetTestimonialByIdDto?> GetTestimonialByIdAsync(string id) => GetByIdAsync(id);

        public Task DeleteTestimonialAsync(string id) => DeleteAsync(id);
    }
}
