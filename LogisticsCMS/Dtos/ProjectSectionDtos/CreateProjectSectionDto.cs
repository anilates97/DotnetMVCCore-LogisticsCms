namespace LogisticsCMS.Dtos.ProjectSectionDtos
{
    public class CreateProjectSectionDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public bool Status { get; set; }
    }
}

