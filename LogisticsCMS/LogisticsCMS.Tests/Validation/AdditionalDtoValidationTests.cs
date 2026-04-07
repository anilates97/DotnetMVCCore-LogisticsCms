using LogisticsCMS.Dtos.About;
using LogisticsCMS.Dtos.Offer;
using LogisticsCMS.Dtos.Question;
using LogisticsCMS.Dtos.Slider;
using LogisticsCMS.Dtos.Testimonial;
using LogisticsCMS.Tests.Helpers;

namespace LogisticsCMS.Tests.Validation;

public class AdditionalDtoValidationTests
{
    [Fact]
    public void AboutDto_Should_Fail_When_Title_Is_Too_Short()
    {
        var model = new CreateAboutDto
        {
            Title = "AB",
            Description = "Geçerli uzunlukta bir açıklama.",
            ImageUrl = "https://example.com/about.png",
        };

        var results = ValidationTestHelper.Validate(model);

        Assert.Contains(results, x => x.MemberNames.Contains(nameof(CreateAboutDto.Title)));
    }

    [Fact]
    public void AboutDto_Should_Pass_With_Maximum_Allowed_Lengths()
    {
        var model = new CreateAboutDto
        {
            Title = new string('A', 150),
            Description = new string('B', 2000),
            ImageUrl = $"https://example.com/{new string('c', 480)}",
        };

        var results = ValidationTestHelper.Validate(model);

        Assert.Empty(results);
    }

    [Fact]
    public void OfferDto_Should_Fail_When_Description_Exceeds_Max_Length()
    {
        var model = new CreateOfferDto
        {
            Title = "Teklif",
            Description = new string('A', 1001),
            ImageUrl = "https://example.com/offer.png",
            IsStatus = true,
        };

        var results = ValidationTestHelper.Validate(model);

        Assert.Contains(results, x => x.MemberNames.Contains(nameof(CreateOfferDto.Description)));
    }

    [Fact]
    public void QuestionDto_Should_Fail_When_Title_Is_Empty()
    {
        var model = new CreateQuestionDto
        {
            Title = "",
            Description = "Bu açıklama yeterli uzunlukta.",
            Status = true,
        };

        var results = ValidationTestHelper.Validate(model);

        Assert.Contains(results, x => x.MemberNames.Contains(nameof(CreateQuestionDto.Title)));
    }

    [Fact]
    public void SliderDto_Should_Fail_When_ImageUrl_Is_Too_Long()
    {
        var model = new CreateSliderDto
        {
            Title = "Slider Başlık",
            SubTitle = "Alt başlık",
            Description = "Bu açıklama yeterli uzunlukta.",
            ImageUrl = $"https://example.com/{new string('x', 490)}",
        };

        var results = ValidationTestHelper.Validate(model);

        Assert.Contains(results, x => x.MemberNames.Contains(nameof(CreateSliderDto.ImageUrl)));
    }

    [Fact]
    public void TestimonialDto_Should_Fail_When_ReviewScore_Is_Out_Of_Range()
    {
        var model = new CreateTestimonialDto
        {
            NameSurname = "Ali Veli",
            Title = "Mudur",
            ImageUrl = "https://example.com/user.png",
            ReviewDetails = "Bu yorum yeterli uzunlukta bir icerik tasiyor.",
            ReviewScore = 6,
            Status = true,
        };

        var results = ValidationTestHelper.Validate(model);

        Assert.Contains(results, x => x.MemberNames.Contains(nameof(CreateTestimonialDto.ReviewScore)));
    }

    [Fact]
    public void TestimonialDto_Should_Pass_With_Valid_Boundary_Values()
    {
        var model = new CreateTestimonialDto
        {
            NameSurname = new string('A', 100),
            Title = new string('B', 100),
            ImageUrl = "https://example.com/user.png",
            ReviewDetails = new string('C', 2000),
            ReviewScore = 5,
            Status = true,
        };

        var results = ValidationTestHelper.Validate(model);

        Assert.Empty(results);
    }
}
