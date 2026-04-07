using AutoMapper;
using LogisticsCMS.Controllers;
using LogisticsCMS.Dtos.Brand;
using LogisticsCMS.Mapping;
using LogisticsCMS.Models;
using LogisticsCMS.Services.Security;
using LogisticsCMS.Settings;
using LogisticsCMS.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LogisticsCMS.Tests.Controllers;

public class ControllerEdgeCaseTests
{
    private readonly IMapper _mapper = new MapperConfiguration(
        cfg => cfg.AddProfile<GeneralMapping>(),
        NullLoggerFactory.Instance
    ).CreateMapper();

    [Fact]
    public async Task BrandController_Create_Should_Propagate_Service_Exception()
    {
        var service = new FakeBrandService
        {
            ExceptionOnCreate = new InvalidOperationException("create failed"),
        };
        var controller = TestControllerFactory.CreateWithHttpContext(
            new BrandController(service, _mapper)
        );

        await Assert.ThrowsAsync<InvalidOperationException>(
            () =>
                controller.Create(
                    new CreateBrandDto
                    {
                        BrandName = "Brand",
                        ImageUrl = "https://example.com/logo.png",
                        IsStatus = true,
                    }
                )
        );
    }

    [Fact]
    public async Task BrandController_Edit_Should_Propagate_Service_Exception()
    {
        var service = new FakeBrandService
        {
            ExceptionOnGetById = new InvalidOperationException("read failed"),
        };
        var controller = TestControllerFactory.CreateWithHttpContext(
            new BrandController(service, _mapper)
        );

        await Assert.ThrowsAsync<InvalidOperationException>(() => controller.Edit("brand-1"));
    }

    [Fact]
    public async Task BrandController_Delete_Should_Propagate_Service_Exception()
    {
        var service = new FakeBrandService
        {
            ExceptionOnDelete = new InvalidOperationException("delete failed"),
        };
        var controller = TestControllerFactory.CreateWithHttpContext(
            new BrandController(service, _mapper)
        );

        await Assert.ThrowsAsync<InvalidOperationException>(() => controller.Delete("brand-1"));
    }

    [Fact]
    public async Task AccountController_Login_Should_Redirect_To_Default_For_External_ReturnUrl()
    {
        var authService = new FakeAuthenticationService();
        var controller = CreateAccountController(authService);

        var result = await controller.Login(
            new LoginViewModel
            {
                Username = "admin",
                Password = "Admin123!",
                ReturnUrl = "https://evil.example.com",
            }
        );

        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirect.ActionName);
        Assert.Equal("Shipment", redirect.ControllerName);
    }

    private static AccountController CreateAccountController(FakeAuthenticationService authService)
    {
        var services = new ServiceCollection();
        services.AddSingleton<Microsoft.AspNetCore.Authentication.IAuthenticationService>(authService);

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

        return TestControllerFactory.CreateWithHttpContext(controller, services.BuildServiceProvider());
    }
}
