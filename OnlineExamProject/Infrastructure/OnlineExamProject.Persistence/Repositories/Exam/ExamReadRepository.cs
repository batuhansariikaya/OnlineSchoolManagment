using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineExamProject.Application.Abstractions.Services;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Domain.Entities;
using OnlineExamProject.Domain.Entities.Identity;
using OnlineExamProject.Persistence.Contexts;
using OnlineExamProject.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Persistence.Repositories
{
    public class ExamReadRepository : ReadRepository<Exam>, IExamReadRepository
    {

        readonly UserManager<AppUser> _userManager;
        readonly private OnlineExamProjectDbContext _context;
        readonly IUserService _userService;
        public ExamReadRepository(OnlineExamProjectDbContext context, UserManager<AppUser> userManager, IUserService userService) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _userService = userService;
        }
        public DbSet<Exam> Table => _context.Set<Exam>();

        public List<Exam> GetExamWithUser()
        {
            return Table.Include(x => x.AppUser).ToList();
        }

        public  List<Exam> GetTeachersExams(int id)
        {
            //AppUser user = await _userService.GetUserInfo();            
            //user.Id
            
            return  Table.Include(x=>x.Questions).Where(u=>u.UserId==id).ToList();

        }

        public async Task<List<Exam>> GetUsersExams()
        {
            AppUser user=await _userService.GetUserInfo();        
            return  Table.Where(x=>x.UserId==user.Id).ToList();
        }
    }
}
