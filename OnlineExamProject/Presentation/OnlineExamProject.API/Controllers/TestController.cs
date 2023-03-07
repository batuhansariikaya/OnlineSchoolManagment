using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Domain.Entities;
using System.Threading.Tasks;
using System;
using OnlineExamProject.Application.ViewModels.Exam;
using System.Net;
using MediatR;


namespace OnlineExamProject.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{

		readonly private IExamReadRepository _examReadRepository;
		readonly private IQuestionReadRepository _questionReadRepository;
		readonly private IExamWriteRepository _examWriteRepository;
		readonly IMediator _mediator;

		public TestController(IExamReadRepository examReadRepository, IExamWriteRepository examWriteRepository, IQuestionReadRepository questionReadRepository, IMediator mediator)
		{
			_examReadRepository = examReadRepository;
			_examWriteRepository = examWriteRepository;
			_questionReadRepository = questionReadRepository;
			_mediator = mediator;
		}

		[HttpGet]
		//public async Task<IActionResult> Get(GetAllExamQueryRequest getAllExamQueryRequest)
		//{
		//	//var datas = _examReadRepository.GetAll();
		//	GetAllExamQueryResponse response = await _mediator.Send(getAllExamQueryRequest);
		//	return Ok(response);
		//}
		[HttpGet("{id}")]
		public IActionResult GetExam(int id)
		{			
			return Ok(_examReadRepository.GetByIdAsync(id,false));
		}
		[HttpPost]
		public async Task<IActionResult> Post(VM_AddExam exam)
		{
			await _examWriteRepository.AddAsync(new()
			{
				Name = exam.name,
				Description = exam.description,
				Time = exam.time.ToString(),
				TeacherId = exam.teacherId,
				CreatedDate = DateTime.UtcNow,
				UpdatedDate = DateTime.UtcNow,
				Status = true
			});
			await _examWriteRepository.SaveAsync();
			return Ok();
		}
		[HttpPut]
		public async Task<IActionResult> Put(VM_UpdateExam model, int id)
		{
			await _examReadRepository.GetByIdAsync(id);
			_examWriteRepository.Update(new()
			{
				Name = model.name,
				Description = model.description,
				Time = model.time.ToString(),
				TeacherId = model.teacherId,
				CreatedDate = model.createdDate,
				UpdatedDate = model.updatedDate,
				Status = model.status
			});
			await _examWriteRepository.SaveAsync();
			return Ok();
		}
	}
}

