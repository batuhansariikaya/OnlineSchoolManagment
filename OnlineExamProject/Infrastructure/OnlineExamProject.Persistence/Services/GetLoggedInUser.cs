using Microsoft.AspNetCore.Http;
using OnlineExamProject.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Persistence.Services
{
	public class GetLoggedInUser 
	{
		//readonly HttpContext _httpContext;
		//readonly ClaimsPrincipal _userId;
		//public GetLoggedInUser(HttpContext httpContext, ClaimsPrincipal userId)
		//{
		//	_httpContext = httpContext;
		//	_userId = _httpContext.User;
		//}
		//public int GetLoggedInUserId()
		//{
		//	var userId = _userId.FindFirstValue(ClaimTypes.NameIdentifier);
			
		//	return int.Parse(userId);
		//}



		//public string GetLoggedInUserInfo()
  //      {
		//	var userName = _httpContext.User.Identity.Name;
		//	return userName;
  //      }
    }
}
