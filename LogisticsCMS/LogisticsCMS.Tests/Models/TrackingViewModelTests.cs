using LogisticsCMS.Models;

namespace LogisticsCMS.Tests.Models;

public class TrackingViewModelTests
{
    [Fact]
    public void TrackingResultViewModel_Should_Return_CurrentStepIndex_Based_On_Status()
    {
        var model = new TrackingResultViewModel { CurrentStatus = "Teslim Edildi" };

        Assert.Equal(4, model.CurrentStepIndex);
        Assert.True(model.IsDelivered);
    }

    [Fact]
    public void TrackingResultViewModel_Should_Default_To_First_Step_For_Unknown_Status()
    {
        var model = new TrackingResultViewModel { CurrentStatus = "Bilinmeyen" };

        Assert.Equal(0, model.CurrentStepIndex);
        Assert.False(model.IsDelivered);
    }

    [Fact]
    public void TrackingEventViewModel_Should_Return_Delivered_Classes_For_Delivered_Status()
    {
        var model = new TrackingEventViewModel { TrackingStatus = "Teslim Edildi" };

        Assert.Equal("delivered", model.MarkerClass);
        Assert.Equal("bi-check-circle-fill", model.IconClass);
    }

    [Fact]
    public void TrackingEventViewModel_Should_Return_Transit_Classes_For_InTransit_Status()
    {
        var model = new TrackingEventViewModel { TrackingStatus = "Yolda" };

        Assert.Equal("transit", model.MarkerClass);
        Assert.Equal("bi-arrow-right-circle-fill", model.IconClass);
    }

    [Fact]
    public void TrackingEventViewModel_Should_Return_Fallback_Classes_For_Unknown_Status()
    {
        var model = new TrackingEventViewModel { TrackingStatus = "Bilinmeyen" };

        Assert.Equal("processing", model.MarkerClass);
        Assert.Equal("bi-circle", model.IconClass);
    }
}
