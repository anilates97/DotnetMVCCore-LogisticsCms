using System.Security.Claims;
using LogisticsCMS.Controllers;
using LogisticsCMS.Models;
using LogisticsCMS.Services.Security;
using LogisticsCMS.Settings;
using LogisticsCMS.Tests.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace LogisticsCMS.Tests.Controllers;

public class AccountControllerTests
{
    [Fact]
    public void Login_Get_Should_Return_View_For_Anonymous_User()
    {
        var controller = CreateController();

        var result = controller.Login("/Shipment/Index");

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<LoginViewModel>(viewResult.Model);
        Assert.Equal("/Shipment/Index", model.ReturnUrl);
    }

    [Fact]
    public void Login_Get_Should_Redirect_When_User_Is_Already_Authenticated()
    {
        var user = new ClaimsPrincipal(
            new ClaimsIdentity([new Claim(ClaimTypes.Name, "Admin")], "TestAuth")
        );
        var controller = CreateController(user: user);

        var result = controller.Login("/Brand/Index");

        var redirectResult = Assert.IsType<RedirectResult>(result);
        Assert.Equal("/Brand/Index", redirectResult.Url);
    }

    [Fact]
    public async Task Login_Post_Should_Return_View_When_ModelState_Is_Invalid()
    {
        var controller = CreateController();
        controller.ModelState.AddModelError("Username", "Required");

        var result = await controller.Login(new LoginViewModel());

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.IsType<LoginViewModel>(viewResult.Model);
    }

    [Fact]
    public async Task Login_Post_Should_Add_Model_Error_For_Invalid_Credentials()
    {
        var controller = CreateController();

        var result = await controller.Login(
            new LoginViewModel { Username = "wrong", Password = "wrong" }
        );

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.False(controller.ModelState.IsValid);
        Assert.IsType<LoginViewModel>(viewResult.Model);
    }

    [Fact]
    public async Task Login_Post_Should_SignIn_And_Redirect_For_Valid_Credentials()
    {
        var authService = new FakeAuthenticationService();
        var controller = CreateController(authService: authService);

        var result = await controller.Login(
            new LoginViewModel
            {
                Username = "admin",
                Password = "Admin123!",
                ReturnUrl = "/Question/Index",
            }
        );

        var redirectResult = Assert.IsType<RedirectResult>(result);
        Assert.Equal("/Question/Index", redirectResult.Url);
        Assert.Equal(CookieAuthenticationDefaults.AuthenticationScheme, authService.SignedInScheme);
        Assert.Equal("Admin", authService.SignedInPrincipal?.FindFirst(ClaimTypes.Role)?.Value);
        Assert.Equal("Anil Ates", authService.SignedInPrincipal?.Identity?.Name);
    }

    [Fact]
    public async Task Logout_Should_SignOut_And_Redirect_To_Login()
    {
        var authService = new FakeAuthenticationService();
        var user = new ClaimsPrincipal(
            new ClaimsIdentity([new Claim(ClaimTypes.Name, "Anil Ates")], "TestAuth")
        );
        var controller = CreateController(authService: authService, user: user);

        var result = await controller.Logout();

        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.True(authService.SignOutCalled);
        Assert.Equal("Login", redirectResult.ActionName);
    }

    private static AccountController CreateController(
        FakeAuthenticationService? authService = null,
        ClaimsPrincipal? user = null
    )
    {
        var services = new ServiceCollection();
        services.AddSingleton<IAuthenticationService>(authService ?? new FakeAuthenticationService());

        var controller = new AccountController(
            Options.Create(
                new AuthSettings
                {
                    Username = "admin",
                    PasswordHash = new AdminPasswordHasher().HashPassword("Admin123!"),
                    DisplayName = "Anil Ates",
                }
            ),
            new AdminPasswordHasher(),
            NullLogger<AccountController>.Instance
        );

        return TestControllerFactory.CreateWithHttpContext(
            controller,
            services.BuildServiceProvider(),
            user
        );
    }
}
