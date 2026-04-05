using LogisticsCMS.Dtos.QuestionDtos;

namespace LogisticsCMS.Services.QuestionService
{
    public interface IQuestionService
    {
        Task<List<ResultQuestionDto>> GetAllQuestionsAsync();
        Task CreateQuestionAsync(CreateQuestionDto createQuestionDto);
        Task UpdateQuestionAsync(UpdateQuestionDto updateQuestionDto);
        Task<GetQuestionByIdDto> GetQuestionByIdAsync(string id);
        Task DeleteQuestionAsync(string id);
    }
}

