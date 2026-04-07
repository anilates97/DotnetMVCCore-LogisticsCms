using LogisticsCMS.Dtos.Shipment;
using LogisticsCMS.Tests.Helpers;

namespace LogisticsCMS.Tests.Validation;

public class ShipmentDtoValidationTests
{
    [Fact]
    public void Should_Fail_When_Origin_And_Destination_Are_The_Same()
    {
        var model = CreateValidShipment();
        model.OriginCity = "Istanbul";
        model.OriginDistrict = "Kadikoy";
        model.DestinationCity = "Istanbul";
        model.DestinationDistrict = "Kadikoy";

        var results = ValidationTestHelper.Validate(model);

        Assert.Contains(results, x => x.ErrorMessage == "Çıkış ve varış lokasyonu aynı olamaz.");
    }

    [Fact]
    public void Should_Fail_When_TrackingNumber_Is_Too_Short()
    {
        var model = CreateValidShipment();
        model.TrackingNumber = "123";

        var results = ValidationTestHelper.Validate(model);

        Assert.Contains(results, x => x.MemberNames.Contains(nameof(CreateShipmentDto.TrackingNumber)));
    }

    [Fact]
    public void Should_Pass_When_Shipment_Model_Is_Valid()
    {
        var model = CreateValidShipment();

        var results = ValidationTestHelper.Validate(model);

        Assert.Empty(results);
    }

    private static CreateShipmentDto CreateValidShipment() =>
        new()
        {
            TrackingNumber = "TRK12345",
            SenderName = "Ali Veli",
            ReceiverName = "Ayse Yilmaz",
            OriginCity = "Istanbul",
            OriginDistrict = "Kadikoy",
            DestinationCity = "Ankara",
            DestinationDistrict = "Cankaya",
            Address = "Ornek Mahallesi Test Sokak No 10 Daire 5",
            CurrentStatus = "Yolda",
            CreatedDate = new DateTime(2026, 4, 6),
        };
}
