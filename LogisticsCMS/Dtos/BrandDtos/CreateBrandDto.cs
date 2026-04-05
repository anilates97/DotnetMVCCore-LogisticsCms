namespace LogisticsCMS.Dtos.BrandDtos
{
    public class CreateBrandDto
    {
        public string BrandName { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
        public bool IsStatus { get; set; }
    }
}

