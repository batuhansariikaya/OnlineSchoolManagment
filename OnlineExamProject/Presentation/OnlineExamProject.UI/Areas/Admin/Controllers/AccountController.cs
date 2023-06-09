using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OnlineExamProject.Application.Abstractions.Services;
using OnlineExamProject.Application.Const;
using OnlineExamProject.Application.CustomAttributes;
using OnlineExamProject.Application.DTOs.User;
using OnlineExamProject.Application.Enums;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OnlineExamProject.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	//[Authorize(Roles ="Admin")]
	public class AccountController : Controller
	{
		readonly UserManager<AppUser> _userManager;
		readonly RoleManager<AppRole> _roleManager;
		readonly IMapper _mapper;
		readonly IGetUserInfo _getUserInfo;
		readonly IUserService _userService;
		readonly IGradeReadRepository _gradeReadRepository;
        public AccountController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, IMapper mapper, IGetUserInfo getUserInfo, IUserService userService, IGradeReadRepository gradeReadRepository)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
            _getUserInfo = getUserInfo;
            _userService = userService;
            _gradeReadRepository = gradeReadRepository;
        }

		[HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Account, Definition = "Get All Account", ActionType = ActionType.Read)]
		public IActionResult Users()
		{
			var allUsers = _userManager.Users.ToList();
			var map = _mapper.Map<List<UsersWithRolesDto>>(allUsers);
			
			//foreach (var item in map)
			//{
			//	var findUserId = await _userManager.FindByIdAsync(item.Id.ToString());
			//	var userRole=string.Join("\n",await _userManager.GetRolesAsync(findUserId));
			//	item.Role = userRole;
			//}
			
			
			return View(map);
		}
		[HttpGet]
		[AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Account, Definition = "Delete User", ActionType = ActionType.Delete)]
		public async Task<IActionResult> DeleteUser(int id) 
		{
			AppUser user=await _userManager.FindByIdAsync(id.ToString());			
			await _userManager.UpdateAsync(user);			
			return RedirectToAction("Users", "Account", new {@area="Admin"});
		}
		[HttpGet]
		[AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Account, Definition = "Update User", ActionType = ActionType.Update)]
		public async Task<IActionResult> UpdateUser(int id)
		{
			AppUser user=await _userManager.FindByIdAsync(id.ToString());
			var  roles = await _roleManager.Roles.ToListAsync();
			//var grades = _gradeReadRepository.GetAll();
			var map = _mapper.Map<UserUpdateDTO>(user);		
			map.Role = string.Join("-",roles);
			//map.Grade = string.Join(" ", grades);
			List<SelectListItem> roleList = (from x in roles select new SelectListItem
			{
				Text = x.Name,
				Value = x.Id.ToString()
			}).ToList();
            //List<SelectListItem> gradeList = (from g in grades
            //                                 select new SelectListItem
            //                                 {
            //                                     Text = g.Name,
            //                                     Value = g.Id.ToString()
            //                                 }).ToList();
            //ViewBag.grade = gradeList;
            ViewBag.role = roleList;
            return View(map);
		}
		[HttpPost]
		[AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Account, Definition = "Update User Post", ActionType = ActionType.Update)]
		public async Task<IActionResult> UpdateUser(UserUpdateDTO userUpdate)
		{			
			AppUser user =await _userManager.FindByIdAsync(userUpdate.Id.ToString());
			var updateUser= _mapper.Map(userUpdate, user);			
			await _userManager.UpdateAsync(updateUser);
		
			return View();
		}
		[HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Account, Definition = "Get User Info", ActionType = ActionType.Read)]

        public IActionResult GetUserInfo()
		{
			var user= _userService.GetUserInfo().Result;			
			return View(user);
		}
		[HttpGet("{id}")]
		[AuthorizeDefinition(Menu =AuthorizeDefinitionConstanst.Account,Definition ="User Roles",ActionType =ActionType.Read)]
		public async Task<IActionResult> UserRoles(int id)
		{
			AppUser userId = await _userManager.FindByIdAsync(id.ToString());
			// string[] userRoles = string.Join("\n ", await _userManager.GetRolesAsync(userId));   ,
			var userRoles=await _userManager.GetRolesAsync(userId);
			return View(userRoles);
        }
		[HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Account, Definition = "PasswordReset Get", ActionType = ActionType.Read)]
		public IActionResult PasswordReset()
		{
			return View();
		}
        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Account, Definition = "PasswordReset Post", ActionType = ActionType.Add)]
        public async Task<IActionResult> PasswordReset(ResetPasswordDTO reset)
        {
            AppUser user = await _userManager.FindByEmailAsync(reset.Email);
            if (user is not null)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                MailMessage mail = new();
                mail.IsBodyHtml = true;
                mail.To.Add(user.Email);
                mail.From = new MailAddress("batuhansarikaya008@gmail.com", "Şifre Güncelleme", Encoding.UTF8);
                mail.Subject = "Şifre Güncelleme Talebi";


                mail.Body = $"<a target=\"_blank\" href=\"https://localhost:44398{Url.Action("UpdatePassword", "Account", new { userId = user.Id, token = HttpUtility.UrlEncode(resetToken) })}\">Yeni şifre talebi için tıklayınız</a>";
                SmtpClient smp = new();
                smp.Credentials = new NetworkCredential("batuhansarikaya008@gmail.com", "B@tuh@n861");
                smp.Port = 587;
                smp.Host = "smtp.gmail.com";
                smp.EnableSsl = true;
                smp.Send(mail);
				ViewBag.State = true;
            }
            else
            {
               ViewBag.State = false;
            }
            return View();
        }
        [HttpGet("[action]/{userId}/{token}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Account, Definition = "UpdatePassword Get", ActionType = ActionType.Read)]
        public IActionResult UpdatePassword(string userId,string token)
        {
            return View();
        }
        [HttpPost("[action]/{userId}/{token}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Account, Definition = "UpdatePassword Post", ActionType = ActionType.Add)]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordDTO updatePassword,string userId,string token)
        {
			AppUser user =await _userManager.FindByIdAsync(userId);
			IdentityResult result = await _userManager.ResetPasswordAsync(user, HttpUtility.UrlDecode(token), updatePassword.NewPassword);
			if( result.Succeeded)
			{
				ViewBag.State = true;
                await _userManager.UpdateSecurityStampAsync(user);
            }
			else
			{
				ViewBag.State = false;
			}
            return View();
        }

    }
}


