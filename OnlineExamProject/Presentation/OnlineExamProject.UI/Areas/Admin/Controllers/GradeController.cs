using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineExamProject.Application.Abstractions.Hubs;
using OnlineExamProject.Application.Const;
using OnlineExamProject.Application.CustomAttributes;
using OnlineExamProject.Application.DTOs.Grade;
using OnlineExamProject.Application.Enums;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Application.Validators.Grade;
using OnlineExamProject.Domain.Entities;
using System.Threading.Tasks;

namespace OnlineExamProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class GradeController : Controller
    {
        readonly IGradeReadRepository _gradeReadRepository;
        readonly IGradeWriteRepository _gradeWriteRepository;
        readonly IMapper _mapper;
        readonly IMediator _mediator;
        private readonly IGradeHubService _gradeHubService;
        public GradeController(IGradeReadRepository gradeReadRepository, IGradeWriteRepository gradeWriteRepository, IMapper mapper, IMediator mediator, IGradeHubService gradeHubService)
        {
            _gradeReadRepository = gradeReadRepository;
            _gradeWriteRepository = gradeWriteRepository;
            _mapper = mapper;
            _mediator = mediator;
            _gradeHubService = gradeHubService;
        }
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Grade, Definition = "Grade List", ActionType = ActionType.Read)]
        public IActionResult GradeList()
        {
            var datas = _gradeReadRepository.GetAll();
            return View(datas);
        }
        [HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Grade, Definition = "Grade Add Get", ActionType = ActionType.Read)]
        public IActionResult GradeAdd()
        {
            return View();
        }
        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Grade, Definition = "Grade Add", ActionType = ActionType.Add)]
        public IActionResult GradeAdd(GradeAddDTO gradeAdd)
        {
            var map = _mapper.Map<Grade>(gradeAdd);
            map.Status = true;

            
            
                _gradeWriteRepository.AddAsync(map);
                _gradeWriteRepository.SaveAsync();
                _gradeHubService.GradeAddMessageAsync("Sınıf Başarıyla Eklenmiştir.");
            

            return RedirectToAction("GradeList", "Grade", new {@area="Admin"});
        }
        [HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Grade, Definition = "Grade Delete", ActionType = ActionType.Delete)]
        public async Task<IActionResult> GradeDelete(int id)
        {
            Grade grade = await _gradeReadRepository.GetByIdAsync(id);            
            _gradeWriteRepository.Remove(grade);
            await _gradeWriteRepository.SaveAsync();
            return View();
        }
        [HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Grade, Definition = "Grade Update Get", ActionType = ActionType.Read)]
        public IActionResult GradeUpdate(int id)
        {
            var grade = _gradeReadRepository.GetByIdAsync(id).Result;
            return View(grade);
        }
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Grade, Definition = "Grade Update", ActionType = ActionType.Update)]
        [HttpPost]
        public IActionResult GradeUpdate(Grade grade)
        {
            _gradeWriteRepository.Update(grade);
            _gradeWriteRepository.SaveAsync();
            return View();
        }
       

    }
}
