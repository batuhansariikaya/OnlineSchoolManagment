using OnlineExamProject.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Persistence.Services
{
    public class GetUserInfo : IGetUserInfo
    {
        public int GetLoggedInUserId(ClaimsPrincipal principal)
        {
            var userId = int.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier));            
            return userId;
           
        }
    }
}
