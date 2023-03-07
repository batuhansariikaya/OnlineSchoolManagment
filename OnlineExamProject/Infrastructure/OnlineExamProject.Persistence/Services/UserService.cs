using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineExamProject.Application.Abstractions.Services;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Domain.Entities;
using OnlineExamProject.Domain.Entities.Identity;
using OnlineExamProject.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Endpoint = OnlineExamProject.Domain.Entities.Endpoint;

namespace OnlineExamProject.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly RoleManager<AppRole> _roleManager;
        readonly IEndpointReadRepository _endpointReadRepository;
        readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(RoleManager<AppRole> roleManager, IEndpointReadRepository endpointReadRepository, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _roleManager = roleManager;
            _endpointReadRepository = endpointReadRepository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string[]> GetRolesToUserAsync(string userNameOrEmail)
        {
            AppUser user = await _userManager.FindByEmailAsync(userNameOrEmail);
            if (user == null)
            {
                user = await _userManager.FindByNameAsync(userNameOrEmail);
            }
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                return userRoles.ToArray();
            }
            return new string[] { };
        }

        public async Task<AppUser> GetUserInfo()
        {
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            AppUser user= await _userManager.FindByNameAsync(userName);         
            return user;
        }

        public async Task<bool> HasRolePermissionToEndpointAsync(string name, string code)
        {
            var userRoles = await GetRolesToUserAsync(name);

            if (!userRoles.Any())
                return false;

            Endpoint endpoint = await _endpointReadRepository.Table
                     .Include(e => e.Roles)
                     .FirstOrDefaultAsync(e => e.Code == code);

            if (endpoint == null)
                return false;

            var hasRole = false;
            var endpointRoles = endpoint.Roles.Select(r => r.Name);

            //foreach (var userRole in userRoles)
            //{
            //    if (!hasRole)
            //    {
            //        foreach (var endpointRole in endpointRoles)
            //            if (userRole == endpointRole)
            //            {
            //                hasRole = true;
            //                break;
            //            }
            //    }
            //    else
            //        break;
            //}

            //return hasRole;

            foreach (var userRole in userRoles)
            {
                foreach (var endpointRole in endpointRoles)
                    if (userRole == endpointRole)
                        return true;
            }

            return false;
        }
    }
}
