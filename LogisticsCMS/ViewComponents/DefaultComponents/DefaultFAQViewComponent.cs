using Microsoft.AspNetCore.Mvc;
using LogisticsCMS.Services.Question;

namespace LogisticsCMS.ViewComponents.DefaultComponents
{
    public class DefaultFAQViewComponent : ViewComponent
    {
        private readonly IQuestionService _questionService;

        public DefaultFAQViewComponent(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _questionService.GetAllQuestionsAsync();
            var activeValues = values.Where(x => x.Status).ToList();

            return View(activeValues.Any() ? activeValues : values);
        }
    }
}

