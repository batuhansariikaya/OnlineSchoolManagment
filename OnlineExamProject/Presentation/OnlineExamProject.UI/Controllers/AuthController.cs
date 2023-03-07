using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineExamProject.Application.ViewModels.User;
using OnlineExamProject.Domain.Entities.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Security.Claims;

namespace OnlineExamProject.UI.Controllers
{
	[AllowAnonymous]
	public class AuthController : Controller
	{
		readonly UserManager<AppUser> _userManager;
		readonly SignInManager<AppUser> _signInManager;
		readonly RoleManager<AppRole> _roleManager;
		public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}
		[HttpGet]
		public IActionResult Login()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(VM_Login loginModel,string returnUrl)
		{
			AppUser user=await _userManager.FindByNameAsync(loginModel.usernameOrmail);
			if (user == null)			
				user = await _userManager.FindByEmailAsync(loginModel.usernameOrmail);
			//kullanicinin cookiesi varsa temizliyorum
			await _signInManager.SignOutAsync();
			Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user,loginModel.password,false,false);
			


			List<string> userRole = await _userManager.GetRolesAsync(user) as List<string>;
			//bool isAdmin = userRole.Contains("Admin");
			//bool isTeacher = userRole.Contains("Teacher");
			//bool isStudent = userRole.Contains("Student");
			if (result.Succeeded)
				//if (isAdmin)
				if (!string.IsNullOrEmpty(returnUrl))
				{
					return Redirect(returnUrl);
				}
				else
					return RedirectToAction("Index", "Home", new { Area = "Admin" });
				//else if (isTeacher)
				//	return RedirectToAction("Index", "Home", new { Area = "Teacher" });
				//else if (isStudent)
				//	return RedirectToAction("Index", "Home", new { Area = "Student" });
				//else
				//	return RedirectToAction("Index", "Home", new { Area = "Admin" });
			else
				return RedirectToAction("Index", "Exam", new { Area = "Admin" });

		


			return View();
		}
        
	
		[HttpGet]
		public IActionResult SignUp()
		{
			
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignUp(VM_UserAdd userAdd)
		{
			AppUser	user= new()
			{
				Name = userAdd.name,
				Surname=userAdd.surname,
				UserName=userAdd.username,
				Email=userAdd.mail
			};
			IdentityResult  result=await _userManager.CreateAsync(user, userAdd.sifre);
			
			if (result.Succeeded)								
				return RedirectToAction("Index", "Home", new {Area="Admin"});
			return View();
		}
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Login");
		}
	}
}
