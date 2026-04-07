using LogisticsCMS.Dtos.Brand;
using LogisticsCMS.Tests.Helpers;

namespace LogisticsCMS.Tests.Validation;

public class BrandDtoValidationTests
{
    [Fact]
    public void Should_Fail_When_ImageUrl_Is_Not_A_Valid_Url()
    {
        var model = new CreateBrandDto
        {
            BrandName = "Lojistik Marka",
            ImageUrl = "gecersiz-url",
            IsStatus = true,
        };

        var results = ValidationTestHelper.Validate(model);

        Assert.Contains(results, x => x.MemberNames.Contains(nameof(CreateBrandDto.ImageUrl)));
    }

    [Fact]
    public void Should_Pass_When_Brand_Model_Is_Valid()
    {
        var model = new CreateBrandDto
        {
            BrandName = "Lojistik Marka",
            ImageUrl = "https://example.com/brand.png",
            IsStatus = true,
        };

        var results = ValidationTestHelper.Validate(model);

        Assert.Empty(results);
    }
}
