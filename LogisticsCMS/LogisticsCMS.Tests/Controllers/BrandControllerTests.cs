using AutoMapper;
using LogisticsCMS.Controllers;
using LogisticsCMS.Dtos.Brand;
using LogisticsCMS.Mapping;
using LogisticsCMS.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace LogisticsCMS.Tests.Controllers;

public class BrandControllerTests
{
    private readonly IMapper _mapper = new MapperConfiguration(
        cfg => cfg.AddProfile<GeneralMapping>(),
        NullLoggerFactory.Instance
    ).CreateMapper();

    [Fact]
    public async Task Index_Should_Return_View_With_Brand_List()
    {
        var service = new FakeBrandService
        {
            Brands =
            [
                new ResultBrandDto
                {
                    BrandName = "Brand 1",
                    ImageUrl = "https://example.com/1.png",
                    IsStatus = true,
                },
            ],
        };
        var controller = CreateController(service);

        var result = await controller.Index();

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<List<ResultBrandDto>>(viewResult.Model);
        Assert.Single(model);
        Assert.Equal("Brand 1", model[0].BrandName);
    }

    [Fact]
    public void Create_Get_Should_Return_View()
    {
        var controller = CreateController(new FakeBrandService());

        var result = controller.Create();

        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public async Task Create_Post_Should_Return_View_When_ModelState_Is_Invalid()
    {
        var service = new FakeBrandService();
        var controller = CreateController(service);
        controller.ModelState.AddModelError("BrandName", "Required");

        var dto = new CreateBrandDto
        {
            BrandName = "Brand",
            ImageUrl = "https://example.com/logo.png",
            IsStatus = true,
        };

        var result = await controller.Create(dto);

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.Same(dto, viewResult.Model);
        Assert.Null(service.CreatedBrand);
    }

    [Fact]
    public async Task Create_Post_Should_Create_And_Redirect_When_Model_Is_Valid()
    {
        var service = new FakeBrandService();
        var controller = CreateController(service);
        var dto = new CreateBrandDto
        {
            BrandName = "Brand",
            ImageUrl = "https://example.com/logo.png",
            IsStatus = true,
        };

        var result = await controller.Create(dto);

        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Same(dto, service.CreatedBrand);
        Assert.Equal("Index", redirectResult.ActionName);
    }

    [Fact]
    public async Task Edit_Get_Should_Return_NotFound_When_Brand_Does_Not_Exist()
    {
        var controller = CreateController(new FakeBrandService());

        var result = await controller.Edit("brand-1");

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Edit_Get_Should_Map_Brand_To_UpdateDto()
    {
        var service = new FakeBrandService
        {
            BrandById = new GetBrandByIdDto
            {
                BrandId = "brand-1",
                BrandName = "Brand",
                ImageUrl = "https://example.com/logo.png",
                IsStatus = true,
            },
        };
        var controller = CreateController(service);

        var result = await controller.Edit("brand-1");

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<UpdateBrandDto>(viewResult.Model);
        Assert.Equal("brand-1", model.BrandId);
        Assert.Equal("Brand", model.BrandName);
    }

    [Fact]
    public async Task Edit_Post_Should_Update_And_Redirect_When_Model_Is_Valid()
    {
        var service = new FakeBrandService();
        var controller = CreateController(service);
        var dto = new UpdateBrandDto
        {
            BrandId = "brand-1",
            BrandName = "Brand",
            ImageUrl = "https://example.com/logo.png",
            IsStatus = true,
        };

        var result = await controller.Edit(dto);

        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Same(dto, service.UpdatedBrand);
        Assert.Equal("Index", redirectResult.ActionName);
    }

    [Fact]
    public async Task Delete_Should_Delete_And_Redirect()
    {
        var service = new FakeBrandService();
        var controller = CreateController(service);

        var result = await controller.Delete("brand-1");

        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("brand-1", service.DeletedBrandId);
        Assert.Equal("Index", redirectResult.ActionName);
    }

    private BrandController CreateController(FakeBrandService service) =>
        TestControllerFactory.CreateWithHttpContext(new BrandController(service, _mapper));
}
