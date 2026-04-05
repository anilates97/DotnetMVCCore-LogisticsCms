namespace LogisticsCMS.Dtos.QuestionDtos
{
    public class CreateQuestionDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Status { get; set; }
    }
}

