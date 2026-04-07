using LogisticsCMS.Dtos.Question;

namespace LogisticsCMS.Services.Question
{
    public interface IQuestionService
        : ICrudService<CreateQuestionDto, UpdateQuestionDto, ResultQuestionDto, GetQuestionByIdDto>
    {
        Task<List<ResultQuestionDto>> GetAllQuestionsAsync();
        Task CreateQuestionAsync(CreateQuestionDto createQuestionDto);
        Task UpdateQuestionAsync(UpdateQuestionDto updateQuestionDto);
        Task<GetQuestionByIdDto?> GetQuestionByIdAsync(string id);
        Task DeleteQuestionAsync(string id);
    }
}
