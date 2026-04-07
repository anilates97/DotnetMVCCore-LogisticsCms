using AutoMapper;
using LogisticsCMS.Dtos.Brand;
using LogisticsCMS.Dtos.Shipment;
using LogisticsCMS.Mapping;
using LogisticsCMS.Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace LogisticsCMS.Tests.Mapping;

public class GeneralMappingTests
{
    private readonly IMapper _mapper;

    public GeneralMappingTests()
    {
        var configuration = new MapperConfiguration(
            cfg => cfg.AddProfile<GeneralMapping>(),
            NullLoggerFactory.Instance
        );
        _mapper = configuration.CreateMapper();
    }

    [Fact]
    public void Should_Map_GetBrandByIdDto_To_UpdateBrandDto()
    {
        var source = new GetBrandByIdDto
        {
            BrandId = "brand-1",
            BrandName = "Transpo",
            ImageUrl = "https://example.com/logo.png",
            IsStatus = true,
        };

        var result = _mapper.Map<UpdateBrandDto>(source);

        Assert.Equal(source.BrandId, result.BrandId);
        Assert.Equal(source.BrandName, result.BrandName);
        Assert.Equal(source.ImageUrl, result.ImageUrl);
        Assert.Equal(source.IsStatus, result.IsStatus);
    }

    [Fact]
    public void Should_Map_Shipment_To_GetShipmentByIdDto_With_Trackings()
    {
        var source = new Shipment
        {
            ShipmentId = "shipment-1",
            TrackingNumber = "TRK12345",
            SenderName = "Ali",
            ReceiverName = "Ayse",
            OriginCity = "Istanbul",
            OriginDistrict = "Kadikoy",
            DestinationCity = "Ankara",
            DestinationDistrict = "Cankaya",
            Address = "Test mahallesi test sokagi no 1",
            CurrentStatus = "Yolda",
            Trackings =
            [
                new ShipmentTracking
                {
                    EventDate = new DateTime(2026, 4, 6),
                    Location = "Istanbul",
                    Description = "Kargo çıkış şubesinde işleme alındı",
                    TrackingStatus = "Hazirlaniyor",
                },
            ],
        };

        var result = _mapper.Map<GetShipmentByIdDto>(source);

        Assert.Equal(source.ShipmentId, result.ShipmentId);
        Assert.Equal(source.TrackingNumber, result.TrackingNumber);
        Assert.NotNull(result.Trackings);
        Assert.Single(result.Trackings!);
        Assert.Equal(source.Trackings[0].TrackingStatus, result.Trackings[0].TrackingStatus);
    }
}
