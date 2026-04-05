namespace LogisticsCMS.Dtos.BrandDtos
{
    public class GetBrandByIdDto
    {
        public string BrandId { get; set; } = null!;

        public string BrandName { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
        public bool IsStatus { get; set; }
    }
}

