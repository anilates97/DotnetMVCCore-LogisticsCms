using AutoMapper;
using LogisticsCMS.Dtos.Question;
using LogisticsCMS.Services;
using LogisticsCMS.Settings;
using System.Linq.Expressions;
using QuestionModel = LogisticsCMS.Models.Question;

namespace LogisticsCMS.Services.Question
{
    public class QuestionService
        : MongoCrudServiceBase<
            QuestionModel,
            CreateQuestionDto,
            UpdateQuestionDto,
            ResultQuestionDto,
            GetQuestionByIdDto
        >,
            IQuestionService
    {
        public QuestionService(
            IMapper mapper,
            DatabaseSettings databaseSettings,
            IMongoDbContext mongoDbContext
        )
            : base(databaseSettings.QuestionCollectionName, mapper, mongoDbContext) { }

        protected override Expression<Func<QuestionModel, bool>> BuildIdFilter(string id) =>
            question => question.QuestionId == id;

        protected override string GetEntityId(QuestionModel entity) => entity.QuestionId;

        public Task<List<ResultQuestionDto>> GetAllQuestionsAsync() => GetAllAsync();

        public Task CreateQuestionAsync(CreateQuestionDto createQuestionDto) =>
            CreateAsync(createQuestionDto);

        public Task UpdateQuestionAsync(UpdateQuestionDto updateQuestionDto) =>
            UpdateAsync(updateQuestionDto);

        public Task<GetQuestionByIdDto?> GetQuestionByIdAsync(string id) => GetByIdAsync(id);

        public Task DeleteQuestionAsync(string id) => DeleteAsync(id);
    }
}
