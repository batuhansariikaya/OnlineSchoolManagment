using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Domain.Entities.Identity;
using System;
using System.Linq;

namespace OnlineExamProject.UI.Areas.Admin.ViewComponents.Dashboard
{
	public class LastUsers: ViewComponent
	{
		readonly UserManager<AppUser> _userManager;

        public LastUsers(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

         

        

		public IViewComponentResult Invoke()
		{
			
			return View();
		}
	}
}
