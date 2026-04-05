namespace LogisticsCMS.Dtos.OfferDtos
{
    public class CreateOfferDto
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
        public bool IsStatus { get; set; }
    }
}

