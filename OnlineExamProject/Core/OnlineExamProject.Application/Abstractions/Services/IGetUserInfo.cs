using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Abstractions.Services
{
    public interface IGetUserInfo
    {
        public int GetLoggedInUserId(ClaimsPrincipal principal);               
    }
}
