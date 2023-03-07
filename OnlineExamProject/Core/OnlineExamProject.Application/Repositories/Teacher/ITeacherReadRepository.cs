using OnlineExamProject.Domain.Entities;
using OnlineExamProject.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Repositories
{
	public interface ITeacherReadRepository:IReadRepository<Teacher>
	{
		List<Teacher> GetAllTeacherWithExam();
	}
}
