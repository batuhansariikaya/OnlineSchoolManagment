using OnlineExamProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Repositories
{
	public interface IExamReadRepository:IReadRepository<Exam>
	{
		//List<Exam> GetExamWithQuestionAndTeacher();
		//List<Exam> GetExamWithTeacher(int id);
		// kullanıcı isimleri ile birlikte sınavları listele
		List<Exam> GetExamWithUser();
		// öğretmenin sınavları exam
		List<Exam> GetTeachersExams(int id);
		Task<List<Exam>> GetUsersExams();
	}
}
