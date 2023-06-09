using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
using System.Collections.Generic;
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
        public ExamController(IExamReadRepository examReadRepository, IExamWriteRepository examWriteRepository, IMediator mediator, IConfiguration configuration, IMapper mapper, UserManager<AppUser> userManager, IUserService userService)
        {
            _examReadRepository = examReadRepository;
            _examWriteRepository = examWriteRepository;
            _mediator = mediator;
            _configuration = configuration;
            _mapper = mapper;
            _userManager = userManager;
            _userService = userService;
        }
        [HttpGet]
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
        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Exam, Definition = "Add Exam", ActionType = ActionType.Add)]
        public async Task<IActionResult> AddExam(Exam exam)
        {
            var userId = _userService.GetUserInfo().Result.Id;

            exam.Status = true;
            exam.UserId = userId;
            await _examWriteRepository.AddAsync(exam);
            await _examWriteRepository.SaveAsync();

            return RedirectToAction("Index", "Exam", new { @area = "Admin" });
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
            _examWriteRepository.Remove(exam);
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
        public async Task<ActionResult> ExamUpdate(Exam exam)
        {


            exam.Status = true;
            _examWriteRepository.Update(exam);
            await _examWriteRepository.SaveAsync();
            return View();
        }
        [HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Exam, Definition = "Deleted Exams", ActionType = ActionType.Read)]
        public IActionResult DeletedExams()
        {
            var exam = _examReadRepository.GetAllPassive();
            return View(exam);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> MakeActive(int id)
        {
            Exam exam=await _examReadRepository.GetByIdAsync(id);
            _examWriteRepository.MakeActive(exam);
            return View();
        }

    }
}
