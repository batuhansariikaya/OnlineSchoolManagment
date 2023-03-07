using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineExamProject.Application.Abstractions.Services.Configuration;

namespace OnlineExamProject.UI.Controllers
{
	[AllowAnonymous]
	public class ApplicationServiceController : Controller
	{
		readonly IApplicationService _applicationService;

		public ApplicationServiceController(IApplicationService applicationService)
		{
			_applicationService = applicationService;
		}

		public IActionResult Index()
		{
			var datas= _applicationService.GetAuthorizeDefinitionEndpoints(typeof(Program));
			return View(datas);
			
		}
	}
}
