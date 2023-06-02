using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineExamProject.Application.Abstractions.Services;
using OnlineExamProject.Application.Const;
using OnlineExamProject.Application.CustomAttributes;
using OnlineExamProject.Application.Enums;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Domain.Entities.Identity;
using OnlineExamProject.Persistence.Contexts;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/[controller]/[action]")]
    public class HomeController : Controller
    {
        readonly private OnlineExamProjectDbContext _context;
        readonly IUserService _userService;
        readonly UserManager<AppUser> _userManager;
        readonly IExamReadRepository _examReadRepository;
        readonly IGradeReadRepository _gradeReadRepository;
        public HomeController(OnlineExamProjectDbContext context, IUserService userService, UserManager<AppUser> userManager, IExamReadRepository examReadRepository, IGradeReadRepository gradeReadRepository)
        {
            _context = context;
            _userService = userService;
            _userManager = userManager;
            _examReadRepository = examReadRepository;
            _gradeReadRepository = gradeReadRepository;
        }


        public async Task<IActionResult> Index()
        {
            ViewBag.questionCount = _context.Questions.Count();
            ViewBag.examCount = _context.Exams.Count();
            ViewBag.userCount = _context.Users.Count();
            ViewBag.roleCount = _context.Roles.Count();
           
            //var id=_userService.GetUserId();
            //AppUser user=await _userManager.FindByIdAsync(id);

            var user = _userService.GetUserInfo().Result;
            ViewBag.nickName = user.UserName;
            ViewBag.userName = user.Name;

            //var lastUser=_userManager.Users.ToList().LastOrDefault();
            //ViewBag.lastUser = lastUser;

            //var lastExam=_examReadRepository.GetAll().ToList().LastOrDefault();
            //ViewBag.lastExam = lastExam.Name;

            //var lastGrade=_gradeReadRepository.GetAll().ToList().LastOrDefault();
            //ViewBag.lastGrade = lastGrade.Name;

            return View();
        }
    }
}
