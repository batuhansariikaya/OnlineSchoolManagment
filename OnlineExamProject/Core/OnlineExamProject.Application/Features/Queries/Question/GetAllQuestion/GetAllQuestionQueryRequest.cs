using MediatR;
using OnlineExamProject.Application.DTOs.Exam;
using OnlineExamProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Features.Queries.Question.GetAllQuestion
{
	public class GetAllQuestionQueryRequest:IRequest<IQueryable<Exam>>
	{
		public ExamListDTO ExamListDTO { get; set; }
	}
}
