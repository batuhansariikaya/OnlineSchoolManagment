using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Application.ViewModels.Teacher;
using OnlineExamProject.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace OnlineExamProject.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TeacherController : Controller
	{
		 readonly private ITeacherReadRepository _teacherReadRepository;
		 readonly private ITeacherWriteRepository _teacherWriteRepository;
		readonly IMapper _mapper;
		readonly IMediator _mediator;

		public TeacherController(ITeacherReadRepository teacherReadRepository, ITeacherWriteRepository teacherWriteRepository, IMapper mapper, IMediator mediator)
		{
			_teacherReadRepository = teacherReadRepository;
			_teacherWriteRepository = teacherWriteRepository;
			_mapper = mapper;
			_mediator = mediator;
		}

		public IActionResult Index()
		{
			var teacherList = _teacherReadRepository.GetAll();
			return View(teacherList);
		}
		[HttpGet]
		public IActionResult AddTeacher()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddTeacher(VM_TeacherAdd teacher)
		{
			//Teacher teacher = new()
			//{
			//	Id=model.id,
			//	Name = model.name,
			//	Surname = model.surname
			//};

			OnlineExamProject.Domain.Entities.Teacher teacherAdd = _mapper.Map<OnlineExamProject.Domain.Entities.Teacher>(teacher);
			teacherAdd.CreatedDate = DateTime.UtcNow;
			teacherAdd.UpdatedDate = DateTime.UtcNow;

			teacherAdd.Status = true;
			_teacherWriteRepository.AddAsync(teacherAdd);
			_teacherWriteRepository.SaveAsync();
			return RedirectToAction("Index");

		}
	}
}
