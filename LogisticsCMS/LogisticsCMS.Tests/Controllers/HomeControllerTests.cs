using System.Diagnostics;
using LogisticsCMS.Controllers;
using LogisticsCMS.Models;
using LogisticsCMS.Tests.Helpers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace LogisticsCMS.Tests.Controllers;

public class HomeControllerTests
{
    [Fact]
    public void Error_Should_Return_404_Model_For_Status_Code()
    {
        var controller = TestControllerFactory.CreateWithHttpContext(
            new HomeController(NullLogger<HomeController>.Instance)
        );
        controller.ControllerContext.HttpContext.Features.Set<IStatusCodeReExecuteFeature>(
            new StatusCodeReExecuteFeature
            {
                OriginalPath = "/missing-page",
                OriginalQueryString = string.Empty,
                OriginalPathBase = string.Empty,
                Endpoint = null,
                RouteValues = null,
            }
        );

        var result = controller.Error(404);

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<ErrorViewModel>(viewResult.Model);
        Assert.Equal(404, model.StatusCode);
        Assert.Equal("/missing-page", model.Path);
        Assert.Equal("Aradığınız sayfa bulunamadı.", model.UserMessage);
    }

    [Fact]
    public void Error_Should_Return_500_Model_For_Exception()
    {
        var controller = TestControllerFactory.CreateWithHttpContext(
            new HomeController(NullLogger<HomeController>.Instance)
        );
        controller.ControllerContext.HttpContext.Features.Set<IExceptionHandlerPathFeature>(
            new ExceptionHandlerFeature
            {
                Error = new InvalidOperationException("boom"),
                Path = "/Shipment/Index",
            }
        );

        var result = controller.Error();

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<ErrorViewModel>(viewResult.Model);
        Assert.Equal(500, model.StatusCode);
        Assert.Equal("/Shipment/Index", model.Path);
        Assert.Equal(
            "Beklenmeyen bir hata oluştu. Lütfen biraz sonra tekrar deneyin.",
            model.UserMessage
        );
    }
}
