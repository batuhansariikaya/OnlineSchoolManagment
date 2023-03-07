using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Application.ViewModels.Exam;
using System.Threading.Tasks;
using System;
using OnlineExamProject.Domain.Entities;

namespace OnlineExamProject.API.Controllers.Admin
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExamController : ControllerBase
	{
		readonly private IExamReadRepository _examReadRepository;
		readonly private IExamWriteRepository _examWriteRepository;
		public ExamController(IExamWriteRepository examWriteRepository, IExamReadRepository examReadRepository )
		{
			_examWriteRepository = examWriteRepository;
			_examReadRepository = examReadRepository;
		}
		[HttpGet]
		public IActionResult GetExams()
		{
			var examList = _examReadRepository.GetAll();
			return Ok(examList);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetExam(int id)
		{			
			return Ok(await _examReadRepository.GetByIdAsync(id));
		}
		[HttpPost]
		public async Task<IActionResult> AddExam(VM_AddExam model)
		{
			await _examWriteRepository.AddAsync(new()
			{
				Name = model.name,
				Description = model.description,
				Time = model.time.ToString(),
				TeacherId = model.teacherId,
				CreatedDate = DateTime.Now,
				UpdatedDate = DateTime.Now,
				Status = true
			});
			await _examWriteRepository.SaveAsync();
			return Ok();
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteExam(int id)
		{
			Exam exam= await _examReadRepository.GetByIdAsync(id);
			 _examWriteRepository.Remove(exam);
			await _examWriteRepository.SaveAsync();
			return Ok();
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateExam(int id,VM_UpdateExam model)
		{
			Exam exam=await _examReadRepository.GetByIdAsync(id);
			exam.Name = model.name;
			exam.Description = model.description;
			exam.Time = model.time.ToString();
			exam.TeacherId = model.teacherId;
			exam.CreatedDate = model.createdDate;
			exam.UpdatedDate = model.updatedDate;
			exam.Status = model.status;
			//_examWriteRepository.Update(exam);
			_examWriteRepository.SaveAsync();
			return Ok();
		}
	}
}
