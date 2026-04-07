using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace LogisticsCMS.Tests.Helpers;

internal static class TestControllerFactory
{
    public static TController CreateWithHttpContext<TController>(
        TController controller,
        IServiceProvider? services = null,
        ClaimsPrincipal? user = null
    )
        where TController : Controller
    {
        var httpContext = new DefaultHttpContext
        {
            RequestServices = services ?? new ServiceCollection().BuildServiceProvider(),
            User = user ?? new ClaimsPrincipal(new ClaimsIdentity()),
        };

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = httpContext,
        };
        controller.TempData = new FakeTempDataDictionary();
        controller.Url = new FakeUrlHelper();

        return controller;
    }
}
