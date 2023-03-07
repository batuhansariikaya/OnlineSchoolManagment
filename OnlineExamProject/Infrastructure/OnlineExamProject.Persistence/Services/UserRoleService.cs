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
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Persistence.Services
{
    public class UserRoleService : IUserRoleService
    {
        readonly IEndpointReadRepository _endpointReadRepository;
        readonly UserManager<AppUser> _userManager;
        public UserRoleService(IEndpointReadRepository endpointReadRepository, UserManager<AppUser> userManager)
        {
            _endpointReadRepository = endpointReadRepository;
            _userManager = userManager;
        }


        public async Task<string[]> GetRolesToUserAsync(string userIdOrName)
        {
            AppUser user = await _userManager.FindByIdAsync(userIdOrName);
            if (user == null)
                user = await _userManager.FindByNameAsync(userIdOrName);

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                return userRoles.ToArray();
            }
            return new string[] { };
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
