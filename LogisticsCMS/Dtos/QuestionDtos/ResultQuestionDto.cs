namespace LogisticsCMS.Dtos.QuestionDtos
{
    public class ResultQuestionDto
    {
        public string QuestionId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Status { get; set; }
    }
}

