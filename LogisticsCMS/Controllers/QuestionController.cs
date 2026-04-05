using Microsoft.AspNetCore.Mvc;
using LogisticsCMS.Dtos.QuestionDtos;
using LogisticsCMS.Services.QuestionService;

namespace LogisticsCMS.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public async Task<IActionResult> QuestionList()
        {
            var values = await _questionService.GetAllQuestionsAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateQuestion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion(CreateQuestionDto createQuestionDto)
        {
            if (ModelState.IsValid)
            {
                await _questionService.CreateQuestionAsync(createQuestionDto);
                return RedirectToAction(nameof(QuestionList));
            }

            return View(createQuestionDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateQuestion(string id)
        {
            var value = await _questionService.GetQuestionByIdAsync(id);
            if (value == null)
            {
                return NotFound();
            }

            var updateDto = new UpdateQuestionDto
            {
                QuestionId = value.QuestionId,
                Title = value.Title,
                Description = value.Description,
                Status = value.Status
            };

            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuestion(UpdateQuestionDto updateQuestionDto)
        {
            if (ModelState.IsValid)
            {
                await _questionService.UpdateQuestionAsync(updateQuestionDto);
                return RedirectToAction(nameof(QuestionList));
            }

            return View(updateQuestionDto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteQuestion(string id)
        {
            await _questionService.DeleteQuestionAsync(id);
            return RedirectToAction(nameof(QuestionList));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFaq(string id)
        {
            await _questionService.DeleteQuestionAsync(id);
            return RedirectToAction(nameof(QuestionList));
        }
    }
}

