using AutoMapper;
using LogisticsCMS.Dtos.Question;
using LogisticsCMS.Services.Question;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCMS.Controllers
{
    public class QuestionController : CrudControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _questionService.GetAllQuestionsAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionDto createDto)
        {
            return await SaveAndRedirectAsync(
                createDto,
                dto => _questionService.CreateQuestionAsync(dto)
            );
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            return await LoadEditViewAsync(
                () => _questionService.GetQuestionByIdAsync(id),
                value => _mapper.Map<UpdateQuestionDto>(value)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateQuestionDto updateDto)
        {
            return await SaveAndRedirectAsync(
                updateDto,
                dto => _questionService.UpdateQuestionAsync(dto)
            );
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> Delete(string id)
        {
            return await DeleteAndRedirectAsync(() => _questionService.DeleteQuestionAsync(id));
        }
    }
}
