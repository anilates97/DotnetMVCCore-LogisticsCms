using AutoMapper;
using LogisticsCMS.Controllers;
using LogisticsCMS.Dtos.About;
using LogisticsCMS.Dtos.GetInTouchSection;
using LogisticsCMS.Dtos.HowItWork;
using LogisticsCMS.Dtos.Offer;
using LogisticsCMS.Dtos.ProjectSection;
using LogisticsCMS.Dtos.Question;
using LogisticsCMS.Dtos.Shipment;
using LogisticsCMS.Dtos.Slider;
using LogisticsCMS.Dtos.Testimonial;
using LogisticsCMS.Mapping;
using LogisticsCMS.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace LogisticsCMS.Tests.Controllers;

public class AdditionalCrudControllerTests
{
    private readonly IMapper _mapper = new MapperConfiguration(
        cfg => cfg.AddProfile<GeneralMapping>(),
        NullLoggerFactory.Instance
    ).CreateMapper();

    [Fact]
    public async Task AboutController_Edit_Get_Should_Return_NotFound_When_Item_Missing()
    {
        var controller = TestControllerFactory.CreateWithHttpContext(
            new AboutController(new FakeAboutService(), _mapper)
        );
        var result = await controller.Edit("about-1");
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task AboutController_Delete_Should_Delete_And_Redirect()
    {
        var service = new FakeAboutService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new AboutController(service, _mapper)
        );
        var result = await controller.Delete("about-1");
        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("about-1", service.DeletedId);
        Assert.Equal("Index", redirect.ActionName);
    }

    [Fact]
    public async Task AboutController_Index_Should_Return_Items()
    {
        var service = new FakeAboutService
        {
            Items = [new ResultAboutDto { AboutId = "about-1" }],
        };
        var controller = TestControllerFactory.CreateWithHttpContext(
            new AboutController(service, _mapper)
        );
        var result = await controller.Index();
        var view = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<List<ResultAboutDto>>(view.Model);
        Assert.Single(model);
    }

    [Fact]
    public async Task AboutController_Create_Post_Should_Return_View_When_ModelState_Is_Invalid()
    {
        var service = new FakeAboutService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new AboutController(service, _mapper)
        );
        controller.ModelState.AddModelError("Title", "Required");
        var dto = new CreateAboutDto();
        var result = await controller.Create(dto);
        var view = Assert.IsType<ViewResult>(result);
        Assert.Same(dto, view.Model);
        Assert.Null(service.CreatedItem);
    }

    [Fact]
    public async Task AboutController_Edit_Get_Should_Map_Model_When_Item_Exists()
    {
        var service = new FakeAboutService
        {
            ItemById = new GetAboutByIdDto { AboutId = "about-1" },
        };
        var controller = TestControllerFactory.CreateWithHttpContext(
            new AboutController(service, _mapper)
        );
        var result = await controller.Edit("about-1");
        var view = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<UpdateAboutDto>(view.Model);
        Assert.Equal("about-1", model.AboutId);
    }

    [Fact]
    public async Task AboutController_Edit_Post_Should_Update_And_Redirect()
    {
        var service = new FakeAboutService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new AboutController(service, _mapper)
        );
        var dto = new UpdateAboutDto { AboutId = "about-1" };
        var result = await controller.Edit(dto);
        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Same(dto, service.UpdatedItem);
        Assert.Equal("Index", redirect.ActionName);
    }

    [Fact]
    public async Task OfferController_Create_Post_Should_Create_And_Redirect()
    {
        var service = new FakeOfferService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new OfferController(service, _mapper)
        );
        var dto = new CreateOfferDto();
        var result = await controller.Create(dto);
        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Same(dto, service.CreatedItem);
        Assert.Equal("Index", redirect.ActionName);
    }

    [Fact]
    public async Task OfferController_Create_Post_Should_Return_View_When_ModelState_Is_Invalid()
    {
        var service = new FakeOfferService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new OfferController(service, _mapper)
        );
        controller.ModelState.AddModelError("Title", "Required");
        var dto = new CreateOfferDto();
        var result = await controller.Create(dto);
        var view = Assert.IsType<ViewResult>(result);
        Assert.Same(dto, view.Model);
        Assert.Null(service.CreatedItem);
    }

    [Fact]
    public async Task OfferController_Edit_Get_Should_Map_Model()
    {
        var service = new FakeOfferService
        {
            ItemById = new GetOfferByIdDto { OfferId = "offer-1" },
        };
        var controller = TestControllerFactory.CreateWithHttpContext(
            new OfferController(service, _mapper)
        );
        var result = await controller.Edit("offer-1");
        var view = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<UpdateOfferDto>(view.Model);
        Assert.Equal("offer-1", model.OfferId);
    }

    [Fact]
    public async Task GetInTouchSectionController_Edit_Post_Should_Update_And_Redirect()
    {
        var service = new FakeGetInTouchSectionService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new GetInTouchSectionController(service, _mapper)
        );
        var dto = new UpdateGetInTouchSectionDto { GetInTouchSectionId = "contact-1" };
        var result = await controller.Edit(dto);
        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Same(dto, service.UpdatedItem);
        Assert.Equal("Index", redirect.ActionName);
    }

    [Fact]
    public async Task GetInTouchSectionController_Edit_Get_Should_Return_NotFound_When_Item_Missing()
    {
        var controller = TestControllerFactory.CreateWithHttpContext(
            new GetInTouchSectionController(new FakeGetInTouchSectionService(), _mapper)
        );
        var result = await controller.Edit("contact-1");
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetInTouchSectionController_Create_Post_Should_Create_And_Redirect()
    {
        var service = new FakeGetInTouchSectionService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new GetInTouchSectionController(service, _mapper)
        );
        var dto = new CreateGetInTouchSectionDto();
        var result = await controller.Create(dto);
        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Same(dto, service.CreatedItem);
        Assert.Equal("Index", redirect.ActionName);
    }

    [Fact]
    public async Task HowItWorkController_Index_Should_Return_Items()
    {
        var service = new FakeHowItWorkService
        {
            Items = [new ResultHowItWorkDto()],
        };
        var controller = TestControllerFactory.CreateWithHttpContext(
            new HowItWorkController(service, _mapper)
        );
        var result = await controller.Index();
        var view = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<List<ResultHowItWorkDto>>(view.Model);
        Assert.Single(model);
    }

    [Fact]
    public async Task HowItWorkController_Create_Post_Should_Return_View_When_ModelState_Is_Invalid()
    {
        var service = new FakeHowItWorkService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new HowItWorkController(service, _mapper)
        );
        controller.ModelState.AddModelError("Title", "Required");
        var dto = new CreateHowItWorkDto();
        var result = await controller.Create(dto);
        var view = Assert.IsType<ViewResult>(result);
        Assert.Same(dto, view.Model);
        Assert.Null(service.CreatedItem);
    }

    [Fact]
    public async Task HowItWorkController_Edit_Get_Should_Map_Model()
    {
        var service = new FakeHowItWorkService
        {
            ItemById = new GetHowItWorkByIdDto { HowItWorkId = "how-1" },
        };
        var controller = TestControllerFactory.CreateWithHttpContext(
            new HowItWorkController(service, _mapper)
        );
        var result = await controller.Edit("how-1");
        var view = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<UpdateHowItWorkDto>(view.Model);
        Assert.Equal("how-1", model.HowItWorkId);
    }

    [Fact]
    public async Task ProjectSectionController_Delete_Should_Delete_And_Redirect()
    {
        var service = new FakeProjectSectionService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new ProjectSectionController(service, _mapper)
        );
        var result = await controller.Delete("project-1");
        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("project-1", service.DeletedId);
        Assert.Equal("Index", redirect.ActionName);
    }

    [Fact]
    public async Task ProjectSectionController_Create_Post_Should_Create_And_Redirect()
    {
        var service = new FakeProjectSectionService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new ProjectSectionController(service, _mapper)
        );
        var dto = new CreateProjectSectionDto();
        var result = await controller.Create(dto);
        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Same(dto, service.CreatedItem);
        Assert.Equal("Index", redirect.ActionName);
    }

    [Fact]
    public async Task ProjectSectionController_Edit_Get_Should_Return_NotFound_When_Item_Missing()
    {
        var controller = TestControllerFactory.CreateWithHttpContext(
            new ProjectSectionController(new FakeProjectSectionService(), _mapper)
        );
        var result = await controller.Edit("project-1");
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task QuestionController_Edit_Get_Should_Return_NotFound_When_Item_Missing()
    {
        var controller = TestControllerFactory.CreateWithHttpContext(
            new QuestionController(new FakeQuestionService(), _mapper)
        );
        var result = await controller.Edit("question-1");
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task QuestionController_Create_Post_Should_Return_View_When_ModelState_Is_Invalid()
    {
        var service = new FakeQuestionService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new QuestionController(service, _mapper)
        );
        controller.ModelState.AddModelError("Title", "Required");
        var dto = new CreateQuestionDto();
        var result = await controller.Create(dto);
        var view = Assert.IsType<ViewResult>(result);
        Assert.Same(dto, view.Model);
        Assert.Null(service.CreatedItem);
    }

    [Fact]
    public async Task QuestionController_Edit_Post_Should_Update_And_Redirect()
    {
        var service = new FakeQuestionService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new QuestionController(service, _mapper)
        );
        var dto = new UpdateQuestionDto { QuestionId = "question-1" };
        var result = await controller.Edit(dto);
        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Same(dto, service.UpdatedItem);
        Assert.Equal("Index", redirect.ActionName);
    }

    [Fact]
    public async Task SliderController_Create_Post_Should_Create_And_Redirect()
    {
        var service = new FakeSliderService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new SliderController(service, _mapper)
        );
        var dto = new CreateSliderDto();
        var result = await controller.Create(dto);
        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Same(dto, service.CreatedItem);
        Assert.Equal("Index", redirect.ActionName);
    }

    [Fact]
    public async Task SliderController_Edit_Get_Should_Return_NotFound_When_Item_Missing()
    {
        var controller = TestControllerFactory.CreateWithHttpContext(
            new SliderController(new FakeSliderService(), _mapper)
        );
        var result = await controller.Edit("slider-1");
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task SliderController_Delete_Should_Delete_And_Redirect()
    {
        var service = new FakeSliderService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new SliderController(service, _mapper)
        );
        var result = await controller.Delete("slider-1");
        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("slider-1", service.DeletedId);
        Assert.Equal("Index", redirect.ActionName);
    }

    [Fact]
    public async Task TestimonialController_Edit_Post_Should_Update_And_Redirect()
    {
        var service = new FakeTestimonialService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new TestimonialController(service, _mapper)
        );
        var dto = new UpdateTestimonialDto { TestimonialId = "test-1" };
        var result = await controller.Edit(dto);
        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Same(dto, service.UpdatedItem);
        Assert.Equal("Index", redirect.ActionName);
    }

    [Fact]
    public async Task TestimonialController_Index_Should_Return_Items()
    {
        var service = new FakeTestimonialService
        {
            Items = [new ResultTestimonialDto { TestimonialId = "test-1" }],
        };
        var controller = TestControllerFactory.CreateWithHttpContext(
            new TestimonialController(service, _mapper)
        );
        var result = await controller.Index();
        var view = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<List<ResultTestimonialDto>>(view.Model);
        Assert.Single(model);
    }

    [Fact]
    public async Task TestimonialController_Create_Post_Should_Create_And_Redirect()
    {
        var service = new FakeTestimonialService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new TestimonialController(service, _mapper)
        );
        var dto = new CreateTestimonialDto();
        var result = await controller.Create(dto);
        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Same(dto, service.CreatedItem);
        Assert.Equal("Index", redirect.ActionName);
    }

    [Fact]
    public async Task ShipmentController_Index_Should_Return_Shipments()
    {
        var service = new FakeShipmentService
        {
            Shipments = [new ResultShipmentDto { ShipmentId = "shipment-1" }],
        };
        var controller = TestControllerFactory.CreateWithHttpContext(
            new ShipmentController(service, _mapper)
        );
        var result = await controller.Index();
        var view = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<List<ResultShipmentDto>>(view.Model);
        Assert.Single(model);
    }

    [Fact]
    public async Task ShipmentController_Create_Post_Should_Return_View_When_ModelState_Is_Invalid()
    {
        var service = new FakeShipmentService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new ShipmentController(service, _mapper)
        );
        controller.ModelState.AddModelError("TrackingNumber", "Required");
        var dto = new CreateShipmentDto();
        var result = await controller.Create(dto);
        var view = Assert.IsType<ViewResult>(result);
        Assert.Same(dto, view.Model);
        Assert.Null(service.CreatedShipment);
    }

    [Fact]
    public async Task ShipmentController_Edit_Post_Should_Update_And_Redirect()
    {
        var service = new FakeShipmentService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new ShipmentController(service, _mapper)
        );
        var dto = new UpdateShipmentDto { ShipmentId = "shipment-1" };
        var result = await controller.Edit(dto);
        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Same(dto, service.UpdatedShipment);
        Assert.Equal("Index", redirect.ActionName);
    }

    [Fact]
    public async Task ShipmentController_Delete_Should_Delete_And_Redirect()
    {
        var service = new FakeShipmentService();
        var controller = TestControllerFactory.CreateWithHttpContext(
            new ShipmentController(service, _mapper)
        );
        var result = await controller.Delete("shipment-1");
        var redirect = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("shipment-1", service.DeletedShipmentId);
        Assert.Equal("Index", redirect.ActionName);
    }

    [Fact]
    public async Task ShipmentController_Edit_Get_Should_Map_Model()
    {
        var service = new FakeShipmentService
        {
            ShipmentById = new GetShipmentByIdDto
            {
                ShipmentId = "shipment-1",
                TrackingNumber = "TRK1",
                SenderName = "Ali",
                ReceiverName = "Ayse",
                OriginCity = "Istanbul",
                OriginDistrict = "Kadikoy",
                DestinationCity = "Ankara",
                DestinationDistrict = "Cankaya",
                Address = "Test adresi 12345",
                CurrentStatus = "Yolda",
            },
        };
        var controller = TestControllerFactory.CreateWithHttpContext(
            new ShipmentController(service, _mapper)
        );
        var result = await controller.Edit("shipment-1");
        var view = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<UpdateShipmentDto>(view.Model);
        Assert.Equal("shipment-1", model.ShipmentId);
    }
}
