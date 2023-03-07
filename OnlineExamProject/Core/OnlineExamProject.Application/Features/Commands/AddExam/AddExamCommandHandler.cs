using MediatR;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Application.Validators.Exam;
using OnlineExamProject.Application.ViewModels.Exam;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Features.Commands.AddExam
{
	public class AddExamCommandHandler : IRequestHandler<AddExamCommandRequest, AddExamCommandResponse>
	{
		readonly IExamReadRepository _examReadRepository;
		readonly IExamWriteRepository _examWriteRepository;
		public AddExamCommandHandler(IExamReadRepository examReadRepository, IExamWriteRepository examWriteRepository)
		{
			_examReadRepository = examReadRepository;
			_examWriteRepository = examWriteRepository;
		}
		public async Task<AddExamCommandResponse> Handle(AddExamCommandRequest request, CancellationToken cancellationToken)
		{
			//VM_AddExam model = new();
			//CreateExamValidator examValidator = new CreateExamValidator();
			//ValidationResult result = examValidator.Validate(model);


			//request.Exam.CreatedDate = DateTime.UtcNow;
			//request.Exam.UpdatedDate = DateTime.UtcNow;
			//request.Exam.Status = true;
			await _examWriteRepository.AddAsync(request.Exam);
			await _examWriteRepository.SaveAsync();
			return new();



		}
	}
}
