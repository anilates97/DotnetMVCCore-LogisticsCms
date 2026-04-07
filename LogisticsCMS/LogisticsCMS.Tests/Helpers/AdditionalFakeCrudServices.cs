using LogisticsCMS.Dtos.About;
using LogisticsCMS.Dtos.GetInTouchSection;
using LogisticsCMS.Dtos.HowItWork;
using LogisticsCMS.Dtos.Offer;
using LogisticsCMS.Dtos.ProjectSection;
using LogisticsCMS.Dtos.Question;
using LogisticsCMS.Dtos.Slider;
using LogisticsCMS.Dtos.Testimonial;
using LogisticsCMS.Services.About;
using LogisticsCMS.Services.GetInTouchSection;
using LogisticsCMS.Services.HowItWork;
using LogisticsCMS.Services.Offer;
using LogisticsCMS.Services.ProjectSection;
using LogisticsCMS.Services.Question;
using LogisticsCMS.Services.Slider;
using LogisticsCMS.Services.Testimonial;

namespace LogisticsCMS.Tests.Helpers;

internal abstract class FakeCrudDomainServiceBase<TCreate, TUpdate, TResult, TGetById>
{
    public List<TResult> Items { get; set; } = [];
    public TGetById? ItemById { get; set; }
    public TCreate? CreatedItem { get; protected set; }
    public TUpdate? UpdatedItem { get; protected set; }
    public string? DeletedId { get; protected set; }
    public Exception? ExceptionOnCreate { get; set; }
    public Exception? ExceptionOnUpdate { get; set; }
    public Exception? ExceptionOnDelete { get; set; }
    public Exception? ExceptionOnGetById { get; set; }
}

internal sealed class FakeAboutService
    : FakeCrudDomainServiceBase<CreateAboutDto, UpdateAboutDto, ResultAboutDto, GetAboutByIdDto>,
        IAboutService
{
    public Task CreateAsync(CreateAboutDto createDto) => throw new NotImplementedException();
    public Task CreateAboutAsync(CreateAboutDto createAboutDto) { if (ExceptionOnCreate is not null) throw ExceptionOnCreate; CreatedItem = createAboutDto; return Task.CompletedTask; }
    public Task DeleteAsync(string id) => throw new NotImplementedException();
    public Task DeleteAboutAsync(string id) { if (ExceptionOnDelete is not null) throw ExceptionOnDelete; DeletedId = id; return Task.CompletedTask; }
    public Task<List<ResultAboutDto>> GetAllAboutsAsync() => Task.FromResult(Items);
    public Task<List<ResultAboutDto>> GetAllAsync() => throw new NotImplementedException();
    public Task<GetAboutByIdDto?> GetAboutByIdAsync(string id) { if (ExceptionOnGetById is not null) throw ExceptionOnGetById; return Task.FromResult(ItemById); }
    public Task<GetAboutByIdDto?> GetByIdAsync(string id) => throw new NotImplementedException();
    public Task UpdateAsync(UpdateAboutDto updateDto) => throw new NotImplementedException();
    public Task UpdateAboutAsync(UpdateAboutDto updateAboutDto) { if (ExceptionOnUpdate is not null) throw ExceptionOnUpdate; UpdatedItem = updateAboutDto; return Task.CompletedTask; }
}

internal sealed class FakeOfferService
    : FakeCrudDomainServiceBase<CreateOfferDto, UpdateOfferDto, ResultOfferDto, GetOfferByIdDto>,
        IOfferService
{
    public Task CreateAsync(CreateOfferDto createDto) => throw new NotImplementedException();
    public Task CreateOfferAsync(CreateOfferDto createOfferDto) { if (ExceptionOnCreate is not null) throw ExceptionOnCreate; CreatedItem = createOfferDto; return Task.CompletedTask; }
    public Task DeleteAsync(string id) => throw new NotImplementedException();
    public Task DeleteOfferAsync(string id) { if (ExceptionOnDelete is not null) throw ExceptionOnDelete; DeletedId = id; return Task.CompletedTask; }
    public Task<List<ResultOfferDto>> GetAllOffersAsync() => Task.FromResult(Items);
    public Task<List<ResultOfferDto>> GetAllAsync() => throw new NotImplementedException();
    public Task<GetOfferByIdDto?> GetOfferByIdAsync(string id) { if (ExceptionOnGetById is not null) throw ExceptionOnGetById; return Task.FromResult(ItemById); }
    public Task<GetOfferByIdDto?> GetByIdAsync(string id) => throw new NotImplementedException();
    public Task UpdateAsync(UpdateOfferDto updateDto) => throw new NotImplementedException();
    public Task UpdateOfferAsync(UpdateOfferDto updateOfferDto) { if (ExceptionOnUpdate is not null) throw ExceptionOnUpdate; UpdatedItem = updateOfferDto; return Task.CompletedTask; }
}

internal sealed class FakeQuestionService
    : FakeCrudDomainServiceBase<CreateQuestionDto, UpdateQuestionDto, ResultQuestionDto, GetQuestionByIdDto>,
        IQuestionService
{
    public Task CreateAsync(CreateQuestionDto createDto) => throw new NotImplementedException();
    public Task CreateQuestionAsync(CreateQuestionDto createQuestionDto) { if (ExceptionOnCreate is not null) throw ExceptionOnCreate; CreatedItem = createQuestionDto; return Task.CompletedTask; }
    public Task DeleteAsync(string id) => throw new NotImplementedException();
    public Task DeleteQuestionAsync(string id) { if (ExceptionOnDelete is not null) throw ExceptionOnDelete; DeletedId = id; return Task.CompletedTask; }
    public Task<List<ResultQuestionDto>> GetAllQuestionsAsync() => Task.FromResult(Items);
    public Task<List<ResultQuestionDto>> GetAllAsync() => throw new NotImplementedException();
    public Task<GetQuestionByIdDto?> GetQuestionByIdAsync(string id) { if (ExceptionOnGetById is not null) throw ExceptionOnGetById; return Task.FromResult(ItemById); }
    public Task<GetQuestionByIdDto?> GetByIdAsync(string id) => throw new NotImplementedException();
    public Task UpdateAsync(UpdateQuestionDto updateDto) => throw new NotImplementedException();
    public Task UpdateQuestionAsync(UpdateQuestionDto updateQuestionDto) { if (ExceptionOnUpdate is not null) throw ExceptionOnUpdate; UpdatedItem = updateQuestionDto; return Task.CompletedTask; }
}

internal sealed class FakeSliderService
    : FakeCrudDomainServiceBase<CreateSliderDto, UpdateSliderDto, ResultSliderDto, GetSliderByIdDto>,
        ISliderService
{
    public Task CreateAsync(CreateSliderDto createDto) => throw new NotImplementedException();
    public Task CreateSliderAsync(CreateSliderDto createSliderDto) { if (ExceptionOnCreate is not null) throw ExceptionOnCreate; CreatedItem = createSliderDto; return Task.CompletedTask; }
    public Task DeleteAsync(string id) => throw new NotImplementedException();
    public Task DeleteSliderAsync(string id) { if (ExceptionOnDelete is not null) throw ExceptionOnDelete; DeletedId = id; return Task.CompletedTask; }
    public Task<List<ResultSliderDto>> GetAllSlidersAsync() => Task.FromResult(Items);
    public Task<List<ResultSliderDto>> GetAllAsync() => throw new NotImplementedException();
    public Task<GetSliderByIdDto?> GetSliderByIdAsync(string id) { if (ExceptionOnGetById is not null) throw ExceptionOnGetById; return Task.FromResult(ItemById); }
    public Task<GetSliderByIdDto?> GetByIdAsync(string id) => throw new NotImplementedException();
    public Task UpdateAsync(UpdateSliderDto updateDto) => throw new NotImplementedException();
    public Task UpdateSliderAsync(UpdateSliderDto updateSliderDto) { if (ExceptionOnUpdate is not null) throw ExceptionOnUpdate; UpdatedItem = updateSliderDto; return Task.CompletedTask; }
}

internal sealed class FakeHowItWorkService
    : FakeCrudDomainServiceBase<CreateHowItWorkDto, UpdateHowItWorkDto, ResultHowItWorkDto, GetHowItWorkByIdDto>,
        IHowItWorkService
{
    public Task CreateAsync(CreateHowItWorkDto createDto) => throw new NotImplementedException();
    public Task CreateHowItWorkAsync(CreateHowItWorkDto createHowItWorkDto) { if (ExceptionOnCreate is not null) throw ExceptionOnCreate; CreatedItem = createHowItWorkDto; return Task.CompletedTask; }
    public Task DeleteAsync(string id) => throw new NotImplementedException();
    public Task DeleteHowItWorkAsync(string id) { if (ExceptionOnDelete is not null) throw ExceptionOnDelete; DeletedId = id; return Task.CompletedTask; }
    public Task<List<ResultHowItWorkDto>> GetAllHowItWorksAsync() => Task.FromResult(Items);
    public Task<List<ResultHowItWorkDto>> GetAllAsync() => throw new NotImplementedException();
    public Task<GetHowItWorkByIdDto?> GetHowItWorkByIdAsync(string id) { if (ExceptionOnGetById is not null) throw ExceptionOnGetById; return Task.FromResult(ItemById); }
    public Task<GetHowItWorkByIdDto?> GetByIdAsync(string id) => throw new NotImplementedException();
    public Task UpdateAsync(UpdateHowItWorkDto updateDto) => throw new NotImplementedException();
    public Task UpdateHowItWorkAsync(UpdateHowItWorkDto updateHowItWorkDto) { if (ExceptionOnUpdate is not null) throw ExceptionOnUpdate; UpdatedItem = updateHowItWorkDto; return Task.CompletedTask; }
}

internal sealed class FakeProjectSectionService
    : FakeCrudDomainServiceBase<CreateProjectSectionDto, UpdateProjectSectionDto, ResultProjectSectionDto, GetProjectSectionByIdDto>,
        IProjectSectionService
{
    public Task CreateAsync(CreateProjectSectionDto createDto) => throw new NotImplementedException();
    public Task CreateProjectSectionAsync(CreateProjectSectionDto createProjectSectionDto) { if (ExceptionOnCreate is not null) throw ExceptionOnCreate; CreatedItem = createProjectSectionDto; return Task.CompletedTask; }
    public Task DeleteAsync(string id) => throw new NotImplementedException();
    public Task DeleteProjectSectionAsync(string id) { if (ExceptionOnDelete is not null) throw ExceptionOnDelete; DeletedId = id; return Task.CompletedTask; }
    public Task<List<ResultProjectSectionDto>> GetAllProjectSectionsAsync() => Task.FromResult(Items);
    public Task<List<ResultProjectSectionDto>> GetAllAsync() => throw new NotImplementedException();
    public Task<GetProjectSectionByIdDto?> GetProjectSectionByIdAsync(string id) { if (ExceptionOnGetById is not null) throw ExceptionOnGetById; return Task.FromResult(ItemById); }
    public Task<GetProjectSectionByIdDto?> GetByIdAsync(string id) => throw new NotImplementedException();
    public Task UpdateAsync(UpdateProjectSectionDto updateDto) => throw new NotImplementedException();
    public Task UpdateProjectSectionAsync(UpdateProjectSectionDto updateProjectSectionDto) { if (ExceptionOnUpdate is not null) throw ExceptionOnUpdate; UpdatedItem = updateProjectSectionDto; return Task.CompletedTask; }
}

internal sealed class FakeGetInTouchSectionService
    : FakeCrudDomainServiceBase<CreateGetInTouchSectionDto, UpdateGetInTouchSectionDto, ResultGetInTouchSectionDto, GetInTouchSectionByIdDto>,
        IGetInTouchSectionService
{
    public Task CreateAsync(CreateGetInTouchSectionDto createDto) => throw new NotImplementedException();
    public Task CreateGetInTouchSectionAsync(CreateGetInTouchSectionDto createGetInTouchSectionDto) { if (ExceptionOnCreate is not null) throw ExceptionOnCreate; CreatedItem = createGetInTouchSectionDto; return Task.CompletedTask; }
    public Task DeleteAsync(string id) => throw new NotImplementedException();
    public Task DeleteGetInTouchSectionAsync(string id) { if (ExceptionOnDelete is not null) throw ExceptionOnDelete; DeletedId = id; return Task.CompletedTask; }
    public Task<List<ResultGetInTouchSectionDto>> GetAllGetInTouchSectionsAsync() => Task.FromResult(Items);
    public Task<List<ResultGetInTouchSectionDto>> GetAllAsync() => throw new NotImplementedException();
    public Task<GetInTouchSectionByIdDto?> GetInTouchSectionByIdAsync(string id) { if (ExceptionOnGetById is not null) throw ExceptionOnGetById; return Task.FromResult(ItemById); }
    public Task<GetInTouchSectionByIdDto?> GetByIdAsync(string id) => throw new NotImplementedException();
    public Task UpdateAsync(UpdateGetInTouchSectionDto updateDto) => throw new NotImplementedException();
    public Task UpdateGetInTouchSectionAsync(UpdateGetInTouchSectionDto updateGetInTouchSectionDto) { if (ExceptionOnUpdate is not null) throw ExceptionOnUpdate; UpdatedItem = updateGetInTouchSectionDto; return Task.CompletedTask; }
}

internal sealed class FakeTestimonialService
    : FakeCrudDomainServiceBase<CreateTestimonialDto, UpdateTestimonialDto, ResultTestimonialDto, GetTestimonialByIdDto>,
        ITestimonialService
{
    public Task CreateAsync(CreateTestimonialDto createDto) => throw new NotImplementedException();
    public Task CreateTestimonialAsync(CreateTestimonialDto createTestimonialDto) { if (ExceptionOnCreate is not null) throw ExceptionOnCreate; CreatedItem = createTestimonialDto; return Task.CompletedTask; }
    public Task DeleteAsync(string id) => throw new NotImplementedException();
    public Task DeleteTestimonialAsync(string id) { if (ExceptionOnDelete is not null) throw ExceptionOnDelete; DeletedId = id; return Task.CompletedTask; }
    public Task<List<ResultTestimonialDto>> GetAllTestimonialsAsync() => Task.FromResult(Items);
    public Task<List<ResultTestimonialDto>> GetAllAsync() => throw new NotImplementedException();
    public Task<GetTestimonialByIdDto?> GetTestimonialByIdAsync(string id) { if (ExceptionOnGetById is not null) throw ExceptionOnGetById; return Task.FromResult(ItemById); }
    public Task<GetTestimonialByIdDto?> GetByIdAsync(string id) => throw new NotImplementedException();
    public Task UpdateAsync(UpdateTestimonialDto updateDto) => throw new NotImplementedException();
    public Task UpdateTestimonialAsync(UpdateTestimonialDto updateTestimonialDto) { if (ExceptionOnUpdate is not null) throw ExceptionOnUpdate; UpdatedItem = updateTestimonialDto; return Task.CompletedTask; }
}
