using OnlineExamProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Repositories
{
	public interface IQuestionReadRepository:IReadRepository<Question>
	{
		List<Question> GetAllQuestionWithExam();
		Task<Question> GetByIdAsyncWithExam(int id);

		List<Question> GetAllQuestionWithTeacherAndExam(int id);
	}
}
