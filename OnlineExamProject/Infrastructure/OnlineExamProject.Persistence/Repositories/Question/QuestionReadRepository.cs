using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Domain.Entities;
using OnlineExamProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Persistence.Repositories
{
	public class QuestionReadRepository:ReadRepository<Question>, IQuestionReadRepository
	{
		readonly private OnlineExamProjectDbContext _context;
		readonly private IHttpContextAccessor _httpContextAccessor;
		readonly private ClaimsPrincipal _user;
		public QuestionReadRepository(OnlineExamProjectDbContext context, IHttpContextAccessor httpContextAccessor, ClaimsPrincipal user = null) : base(context)
		{
			_context = context;
			_httpContextAccessor = httpContextAccessor;
			_user = httpContextAccessor.HttpContext.User;
		}
		public DbSet<Question> Table => _context.Set<Question>();

		public List<Question> GetAllQuestionWithExam()
		{
			
			return Table.Include(x => x.Exam).ToList();
		}		
		public List<Question> GetAllQuestionWithTeacherAndExam(int id)
		{
			return Table.Include(x => x.Exam).ThenInclude(y => y.AppUser).ToList();
			
		}

		public async Task<Question> GetByIdAsyncWithExam(int id)
		{
			return await Table.Include(a=>a.Exam).FirstOrDefaultAsync(x => x.Id == id);
		}
	}
}
