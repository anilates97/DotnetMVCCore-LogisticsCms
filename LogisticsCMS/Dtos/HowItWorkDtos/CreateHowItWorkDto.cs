namespace LogisticsCMS.Dtos.HowItWorkDtos
{
    public class CreateHowItWorkDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public bool Status { get; set; }
    }
}

