namespace LogisticsCMS.Dtos.HowItWorkDtos
{
    public class UpdateHowItWorkDto
    {
        public string HowItWorkId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public bool Status { get; set; }
    }
}

