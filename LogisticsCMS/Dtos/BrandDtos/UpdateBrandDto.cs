namespace LogisticsCMS.Dtos.BrandDtos
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateBrandDto
    {
        public string BrandId { get; set; } = null!;

        public string BrandName { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
        public bool IsStatus { get; set; }
    }
}

