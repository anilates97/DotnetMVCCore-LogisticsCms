namespace LogisticsCMS.Dtos.ProjectSectionDtos
{
    public class ResultProjectSectionDto
    {
        public string ProjectSectionId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public bool Status { get; set; }
    }
}

