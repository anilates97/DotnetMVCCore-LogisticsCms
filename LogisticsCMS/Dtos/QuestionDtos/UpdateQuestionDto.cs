namespace LogisticsCMS.Dtos.QuestionDtos
{
    public class UpdateQuestionDto
    {
        public string QuestionId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Status { get; set; }
    }
}

