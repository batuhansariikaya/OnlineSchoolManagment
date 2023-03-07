using Microsoft.AspNetCore.Mvc;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Domain.Entities;
using System.Threading.Tasks;
using System;
using System.Linq;
using OnlineExamProject.Application.ViewModels.Question;
using Microsoft.Extensions.Logging;
using MediatR;
using OnlineExamProject.Application.Features.Queries.Question.GetAllQuestion;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using OnlineExamProject.Application.CustomAttributes;
using OnlineExamProject.Application.Const;
using OnlineExamProject.Application.Enums;
using Microsoft.Extensions.Caching.Memory;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace OnlineExamProject.UI.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Area(nameof(Admin))]
    [Route("/Admin/[controller]/[action]/")]
	
	public class QuestionController : Controller
	{
		readonly private IQuestionReadRepository _questionReadRepository;
		readonly private IQuestionWriteRepository _questionWriteRepository;
		readonly private IExamReadRepository _examReadRepository;
		private readonly ILogger<QuestionController> _logger;
		readonly IMediator _mediator;
		readonly IMapper _mapper;
		public INotyfService _notifyService { get; }



		public QuestionController(IQuestionReadRepository questionReadRepository, IQuestionWriteRepository questionWriteRepository, IExamReadRepository examReadRepository, ILogger<QuestionController> logger, IMediator mediator, IMapper mapper, INotyfService notifyService)
		{
			_questionReadRepository = questionReadRepository;
			_questionWriteRepository = questionWriteRepository;
			_examReadRepository = examReadRepository;
			_logger = logger;
			_mediator = mediator;
			_mapper = mapper;
			_notifyService = notifyService;
		}
		[AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Question, Definition = "Get All Questions", ActionType = ActionType.Read)]
		public async Task<IActionResult> Index(GetAllQuestionQueryRequest questionQueryRequest)
		{
			var response = await _mediator.Send(questionQueryRequest);
			return View(response);
		}
		[HttpGet("{id}")]
		[AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Question, Definition = "Get Questions By Id", ActionType = ActionType.Read)]
		public async Task<IActionResult> ExamQuestions(int id)
		{
			Question question = await _questionReadRepository.GetByIdAsyncWithExam(id);// dataları tutuyor.
			ViewBag.questionHeader = question.Exam.Name;
			ViewBag.examId = question.Id;
			return View();
		}
		[HttpPost]
		[AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Question, Definition = "Add Questions", ActionType = ActionType.Add)]

		public async Task<IActionResult> ExamQuestions(VM_QuestionAdd questionAdd)
		{
			var map = _mapper.Map<Question>(questionAdd);
			map.CreatedDate = DateTime.Now;
			map.UpdatedDate = DateTime.Now;
			map.Status = true;
			if (ModelState.IsValid)
			{
                await _questionWriteRepository.AddAsync(map);
                await _questionWriteRepository.SaveAsync();
                _notifyService.Success("Soru başarıyla eklenmiştir.");
            }			
			
			return View();
		}

		[HttpGet("{id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Question, Definition = "Exam Questions", ActionType = ActionType.Read)]
        public IActionResult ExamQuestionList(VM_QuestionAdd questionList)
		{
			var question = _examReadRepository.GetIdInfo(questionList.Id);
			return View(question);
			//ViewBag.id = id;

			////var data = _questionReadRepository.GetByIdAsync(id);
			////var questionList = _questionReadRepository.GetWhere(x=>x.Id==id);
			//var questionList = _questionReadRepository.GetAll().Where(x=>x.Id==id);
			//return View(questionList);
		}
		[HttpGet]
		[AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Question, Definition = "Delete Question", ActionType = ActionType.Delete)]
		public async Task<IActionResult> QuestionDelete(int id)
		{
			Question question = await _questionReadRepository.GetByIdAsync(id);
			question.Status = false;
			_questionWriteRepository.Update(question);
			await _questionWriteRepository.SaveAsync();
			return View();
		}
	}
}
