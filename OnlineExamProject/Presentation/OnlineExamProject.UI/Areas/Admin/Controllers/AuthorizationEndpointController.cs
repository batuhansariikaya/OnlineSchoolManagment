using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineExamProject.Application.Abstractions.Services;
using OnlineExamProject.Application.Abstractions.Services.Configuration;
using OnlineExamProject.Application.Const;
using OnlineExamProject.Application.CustomAttributes;
using OnlineExamProject.Application.Enums;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Domain.Entities.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamProject.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	//[Authorize(Roles = "Admin")]
	[AllowAnonymous]
	public class AuthorizationEndpointController : Controller
	{
		readonly RoleManager<AppRole> _roleManager;
		readonly IAuthorizationEndpointService _authorizationEndpointService;
		readonly IApplicationService _applicationService;
		readonly IMenuReadRepository _menuReadRepository;

        public AuthorizationEndpointController(RoleManager<AppRole> roleManager, IAuthorizationEndpointService authorizationEndpointService, IApplicationService applicationService, IMenuReadRepository menuReadRepository)
        {
            _roleManager = roleManager;
            _authorizationEndpointService = authorizationEndpointService;
            _applicationService = applicationService;
            _menuReadRepository = menuReadRepository;
        }       
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.AuthorizationEndpoint, Definition = "Endpoint List", ActionType = ActionType.Read)]
        public async Task<IActionResult> EndpointsList()
		{
			//var roleList= _roleManager.Roles.ToList();
			//return View(roleList);
			var roles= _roleManager.Roles.ToList();
			var endpoints = await _applicationService.GetAuthorizeDefinitionEndpoints(typeof(Program));		
			
			//var rolesAndEndpoints = (roles, endpoints);
			return View((endpoints,roles));
		}
		[HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.AuthorizationEndpoint, Definition = "Assing Role To Endpoint", ActionType = ActionType.Read)]
        public IActionResult AssignRoletoEndpoint(int id)
		{
			
			return View();
			
		}
		[HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstanst.AuthorizationEndpoint, Definition = "Assign Role To Endpoint Post", ActionType = ActionType.Add)]
        public async Task<IActionResult> AssignRoletoEndpoint(string roles,string menu,string code)
		{			
			await _authorizationEndpointService.AssignRoleEndipointAsync(roles,menu,code, typeof(Program));
			return View();
		}	
	}
}
