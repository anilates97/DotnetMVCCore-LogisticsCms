using LogisticsCMS.Controllers;
using LogisticsCMS.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Tests.Controllers;

public class CrudControllerBaseTests
{
    [Fact]
    public async Task LoadEditViewAsync_Should_Return_NotFound_When_Source_Is_Null()
    {
        var controller = TestControllerFactory.CreateWithHttpContext(new TestCrudController());

        var result = await controller.CallLoadEditViewAsync<string, string>(
            () => Task.FromResult<string?>(null),
            source => source.ToUpperInvariant()
        );

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task LoadEditViewAsync_Should_Return_View_With_Mapped_Model()
    {
        var controller = TestControllerFactory.CreateWithHttpContext(new TestCrudController());

        var result = await controller.CallLoadEditViewAsync(
            () => Task.FromResult<TestSource?>(new TestSource { Name = "brand" }),
            source => new TestViewModel { Value = source.Name.ToUpperInvariant() }
        );

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<TestViewModel>(viewResult.Model);
        Assert.Equal("BRAND", model.Value);
    }

    [Fact]
    public async Task SaveAndRedirectAsync_Should_Return_View_When_ModelState_Is_Invalid()
    {
        var controller = TestControllerFactory.CreateWithHttpContext(new TestCrudController());
        controller.ModelState.AddModelError("Name", "Required");
        var saveCalled = false;

        var result = await controller.CallSaveAndRedirectAsync(
            new TestViewModel { Value = "test" },
            _ =>
            {
                saveCalled = true;
                return Task.CompletedTask;
            }
        );

        var viewResult = Assert.IsType<ViewResult>(result);
        Assert.IsType<TestViewModel>(viewResult.Model);
        Assert.False(saveCalled);
    }

    [Fact]
    public async Task SaveAndRedirectAsync_Should_Save_And_Redirect_When_Model_Is_Valid()
    {
        var controller = TestControllerFactory.CreateWithHttpContext(new TestCrudController());
        var saveCalled = false;

        var result = await controller.CallSaveAndRedirectAsync(
            new TestViewModel { Value = "test" },
            _ =>
            {
                saveCalled = true;
                return Task.CompletedTask;
            }
        );

        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.True(saveCalled);
        Assert.Equal("Index", redirectResult.ActionName);
    }

    [Fact]
    public async Task DeleteAndRedirectAsync_Should_Execute_Delete_And_Redirect()
    {
        var controller = TestControllerFactory.CreateWithHttpContext(new TestCrudController());
        var deleteCalled = false;

        var result = await controller.CallDeleteAndRedirectAsync(() =>
        {
            deleteCalled = true;
            return Task.CompletedTask;
        });

        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.True(deleteCalled);
        Assert.Equal("Index", redirectResult.ActionName);
    }

    private sealed class TestCrudController : CrudControllerBase
    {
        public Task<IActionResult> CallLoadEditViewAsync<TSource, TViewModel>(
            Func<Task<TSource?>> loadAction,
            Func<TSource, TViewModel> mapAction
        )
            where TSource : class => LoadEditViewAsync(loadAction, mapAction);

        public Task<IActionResult> CallSaveAndRedirectAsync<TModel>(
            TModel model,
            Func<TModel, Task> saveAction
        ) => SaveAndRedirectAsync(model, saveAction);

        public Task<IActionResult> CallDeleteAndRedirectAsync(Func<Task> deleteAction) =>
            DeleteAndRedirectAsync(deleteAction);
    }

    private sealed class TestSource
    {
        public string Name { get; set; } = string.Empty;
    }

    private sealed class TestViewModel
    {
        public string Value { get; set; } = string.Empty;
    }
}
