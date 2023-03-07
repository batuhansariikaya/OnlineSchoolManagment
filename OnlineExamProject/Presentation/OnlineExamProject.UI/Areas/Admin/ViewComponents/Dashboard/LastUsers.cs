using Microsoft.AspNetCore.Mvc;
using OnlineExamProject.Application.Repositories;
using System;
using System.Linq;

namespace OnlineExamProject.UI.Areas.Admin.ViewComponents.Dashboard
{
	public class LastUsers: ViewComponent
	{
		readonly private ITeacherReadRepository _teacherReadRepository;

		public LastUsers(ITeacherReadRepository teacherReadRepository)
		{
			_teacherReadRepository = teacherReadRepository;
		}

		public IViewComponentResult Invoke()
		{
			var today = DateTime.Now.Date;
			var last24 = today.AddDays(-1);

			var last24Hours=_teacherReadRepository.GetWhere(x => x.CreatedDate <= today && x.CreatedDate >= last24);
			ViewBag.userCount = last24Hours.Count();
			return View();
		}
	}
}
