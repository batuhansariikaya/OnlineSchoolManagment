using Microsoft.EntityFrameworkCore;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Domain.Entities;
using OnlineExamProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Persistence.Repositories
{
	public class TeacherReadRepository:ReadRepository<Teacher>, ITeacherReadRepository
	{
		//readonly private OnlineExamProjectDbContext _context;
		public TeacherReadRepository(OnlineExamProjectDbContext context):base(context)
		{
			
		}
		DbSet<Teacher> Table { get; set; }
		public  List<Teacher> GetAllTeacherWithExam()
		{
			return null;
		}
	}
}
