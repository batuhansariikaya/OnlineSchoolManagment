using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineExamProject.Application.DTOs.Role;
using OnlineExamProject.Application.ViewModels.User.Role;
using OnlineExamProject.Domain.Entities.Identity;
using System.Linq;
using System.Threading.Tasks;
using System;
using OnlineExamProject.Application.CustomAttributes;
using OnlineExamProject.Application.Const;
using OnlineExamProject.Application.Enums;
using OnlineExamProject.Persistence.Repositories;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OnlineExamProject.Application.Abstractions.Services;
using SmartBreadcrumbs.Attributes;

namespace OnlineExamProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    [Route("/Admin/[controller]/[action]")]

    public class RoleController : Controller
    {
        readonly RoleManager<AppRole> _roleManager;
        readonly IMapper _mapper;
        readonly IRoleService _roleService;
        public RoleController(RoleManager<AppRole> roleManager, IMapper mapper, IRoleService roleService)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _roleService = roleService;
        }
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Role, Definition = "Role List", ActionType = ActionType.Read)]
        public IActionResult RoleList()
        {
            return View(_roleManager.Roles.ToList());
        }
        [HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Role, Definition = "GET CreateRole", ActionType = ActionType.Read)]

        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Role, Definition = "Create Role", ActionType = ActionType.Add)]
        public IActionResult CreateRole(CreateRoleDTO createRole)
        {
            var map = _mapper.Map<AppRole>(createRole);
            map.CreatedDate = DateTime.Now;
            _roleManager.CreateAsync(map);
            return RedirectToAction("RoleList", "Role", new {@area="Admin"});
        }
        [HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Role, Definition = "Get Update Role", ActionType = ActionType.Read)]
        public IActionResult UpdateRole() 
        {
            return View();
        }
        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Role, Definition = "Update Role", ActionType = ActionType.Update)]       
        public async Task<IActionResult> UpdateRole(int id)
        {
            AppRole role=await _roleManager.FindByIdAsync(id.ToString());
            await _roleService.UpdateRoleAsync(role.Name);
            return View();
        }

        [HttpGet("{id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.Role, Definition = "Delete Role", ActionType = ActionType.Delete)]
        public async Task<IActionResult> DeleteRole(int id)
        {
           
            await _roleService.DeleteRoleAsync(id);
            return RedirectToAction("RoleList", "Role",new {@Area="Admin"});
        }
    }
}
