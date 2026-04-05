namespace LogisticsCMS.Dtos.GetInTouchSectionDtos
{
    public class GetGetInTouchSectionByIdDto
    {
        public string GetInTouchSectionId { get; set; } = null!;
        public string MainTitle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Feature1Title { get; set; } = null!;
        public string Feature1Description { get; set; } = null!;
        public string Feature2Title { get; set; } = null!;
        public string Feature2Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public bool Status { get; set; }
    }
}

