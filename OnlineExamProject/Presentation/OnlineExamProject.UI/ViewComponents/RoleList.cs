using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineExamProject.Domain.Entities.Identity;
using System.Collections.Generic;
using System.Linq;

namespace OnlineExamProject.UI.ViewComponents
{
    public class RoleList:ViewComponent
    {
        readonly RoleManager<AppRole> _roleManager;

        public RoleList(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IViewComponentResult Invoke()
        {
            List<SelectListItem> a = (from x in _roleManager.Roles.ToList()
                                      select new SelectListItem
                                      {
                                          Value=x.Id.ToString(),
                                          Text=x.Name
                                      }).ToList();
            ViewBag.roles = a;
            return View(_roleManager.Roles.ToList());
        }
    }
}
