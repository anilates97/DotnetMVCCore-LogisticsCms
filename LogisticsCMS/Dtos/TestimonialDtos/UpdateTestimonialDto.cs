namespace LogisticsCMS.Dtos.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public string TestimonialId { get; set; } = null!;
        public string NameSurname { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string ReviewDetails { get; set; } = null!;
        public int ReviewScore { get; set; }
        public bool Status { get; set; }
    }
}

