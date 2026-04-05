namespace LogisticsCMS.Dtos.OfferDtos
{
    public class UpdateOfferDto
    {
        public string OfferId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
        public bool IsStatus { get; set; }
    }
}

