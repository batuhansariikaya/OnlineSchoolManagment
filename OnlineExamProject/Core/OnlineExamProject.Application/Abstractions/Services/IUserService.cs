using OnlineExamProject.Application.DTOs.User;
using OnlineExamProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<string[]> GetRolesToUserAsync(string userNameOrEmail);
        Task<bool> HasRolePermissionToEndpointAsync(string name, string code);
        Task<AppUser> GetUserInfo();
    }
}
