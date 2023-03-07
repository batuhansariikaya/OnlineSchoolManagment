using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineExamProject.Application.Abstractions.Services;
using OnlineExamProject.Application.Const;
using OnlineExamProject.Application.CustomAttributes;
using OnlineExamProject.Application.Enums;
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
        public HomeController(OnlineExamProjectDbContext context, IUserService userService, UserManager<AppUser> userManager)
        {
            _context = context;
            _userService = userService;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            ViewBag.questionCount = _context.Questions.Count();
            ViewBag.examCount = _context.Exams.Count();
            ViewBag.teacherCount = _context.Teachers.Count();
            //var id=_userService.GetUserId();
            //AppUser user=await _userManager.FindByIdAsync(id);
            var user = _userService.GetUserInfo().Result;
            ViewBag.data = user.Name;
            return View();
        }
    }
}
