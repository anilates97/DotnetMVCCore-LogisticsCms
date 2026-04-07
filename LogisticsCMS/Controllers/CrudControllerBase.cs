using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public abstract class CrudControllerBase : Controller
    {
        protected async Task<IActionResult> LoadEditViewAsync<TSource, TViewModel>(
            Func<Task<TSource?>> loadAction,
            Func<TSource, TViewModel> mapAction
        )
            where TSource : class
        {
            var source = await loadAction();
            if (source == null)
            {
                return NotFound();
            }

            return View(mapAction(source));
        }

        protected async Task<IActionResult> SaveAndRedirectAsync<TModel>(
            TModel model,
            Func<TModel, Task> saveAction
        )
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await saveAction(model);
            return RedirectToAction(nameof(Index));
        }

        protected async Task<IActionResult> DeleteAndRedirectAsync(Func<Task> deleteAction)
        {
            await deleteAction();
            return RedirectToAction(nameof(Index));
        }
    }
}
