using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OnlineExamProject.Application.Abstractions.Services;
using OnlineExamProject.Application.Const;
using OnlineExamProject.Application.CustomAttributes;
using OnlineExamProject.Application.Enums;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Application.Validators.Exam;
using OnlineExamProject.Application.ViewModels.Exam;
using OnlineExamProject.Domain.Entities;
using OnlineExamProject.Domain.Entities.Identity;
using System;
using System.Threading.Tasks;

namespace OnlineExamProject.UI.Areas.Admin.Controllers
{
	//[Authorize(Roles = "Admin")]
	[Area("Admin")]
	[Route("/Admin/[controller]/[action]")]	
	public class ExamController : Controller
	{
		readonly private IExamReadRepository _examReadRepository;
		readonly private IExamWriteRepository _examWriteRepository;
		readonly IMediator _mediator;
		readonly IConfiguration _configuration;
		private readonly IMapper _mapper;
		readonly IUserService _userService;
		
		readonly UserManager<AppUser> _userManager;
        public ExamController(IExamReadRepository examReadRepository, IExamWriteRepository examWriteRepository, IMediator mediator,  IConfiguration configuration, IMapper mapper, UserManager<AppUser> userManager, IUserService userService)
        {
            _examReadRepository = examReadRepository;
            _examWriteRepository = examWriteRepository;
            _mediator = mediator;
            
            _configuration = configuration;
            _mapper = mapper;

            _userManager = userManager;
            _userService = userService;
        }

        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Exam, Definition = "Get All Exams", ActionType = ActionType.Read)]
		public async Task<IActionResult> Index()
		{
            /*_examReadRepository.GetAll().Where(x => x.Status == true);*/
            //         var userName = _httpContext.User.Identity.Name;
            //         AppUser user = await _userManager.FindByNameAsync(userName);
            //user.ıd = 14;
            AppUser user = await _userService.GetUserInfo();
            var datas = _examReadRepository.GetTeachersExams(user.Id);
			return View(datas);
		}
		[HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Exam, Definition = "Get Add Exam", ActionType = ActionType.Read)]
        public IActionResult AddExam()
		{
			return View();
		}
        // bir sınavın birden fazla sorusu olabilir.
        //     principal			dependent
        // bire cok iliskilerde önce principal entity üzerinden veri eklemesi yapılır. (olmasi gereken)
        // bir hoca birden fazla sınav yapabilir
        //     principal		 dependent
        //     blog				 post
        //    hashset
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Exam, Definition = "Add Exam", ActionType = ActionType.Add)]
        [HttpPost]
		public async Task<IActionResult> AddExam(Exam exam)
		{
			if (ModelState.IsValid)
			{
				exam.CreatedDate = DateTime.UtcNow;
				exam.UpdatedDate = DateTime.UtcNow;
				exam.Status = true;
				await _examWriteRepository.AddAsync(exam);
				await _examWriteRepository.SaveAsync();
			}
			return View();
		}
		//else
		//{
		//	foreach (var item in result.Errors)
		//	{
		//		ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
		//	}
		//}


		//return View();

		[HttpGet("{id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Exam, Definition = "Delete Exam", ActionType = ActionType.Read)]
        public async Task<IActionResult> Delete(int id)
		{
			Exam exam = await _examReadRepository.GetByIdAsync(id);
			if (exam.Status == false)
            {
				exam.Status = true;
				_examWriteRepository.Update(exam);
			}
            else
            {
				exam.Status = false;
				_examWriteRepository.Update(exam);
			}				
			await _examWriteRepository.SaveAsync();
			return RedirectToAction("Index");
		}
		[HttpGet("{id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Exam, Definition = "Get By Exam Id(Update)", ActionType = ActionType.Read)]
        public async Task<ActionResult> ExamUpdate(int id)
		{
			Exam exam = await _examReadRepository.GetByIdAsync(id);
			ViewBag.examName = exam.Name;
			return View(exam);
		}
		[HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Exam, Definition = "Exam Update", ActionType = ActionType.Update)]
        public ActionResult ExamUpdate(Exam exam)
		{
			if(ModelState.IsValid)
				exam.CreatedDate = DateTime.UtcNow;
				exam.UpdatedDate = DateTime.UtcNow;
				exam.Status = true;
				_examWriteRepository.Update(exam);
				_examWriteRepository.SaveAsync();
			return View();
		}
		[HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Exam, Definition = "Deleted Exams", ActionType = ActionType.Read)]
        public IActionResult DeletedExams()
		{
			var deleted = _examReadRepository.GetWhere(x => x.Status == false);
			return View(deleted);
		}
		
	}
}
