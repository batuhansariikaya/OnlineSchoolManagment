using Microsoft.AspNetCore.Identity;
using OnlineExamProject.Application.Abstractions.Services;
using OnlineExamProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Persistence.Services
{
	public class RoleService : IRoleService
	{
		readonly RoleManager<AppRole> _roleManager;

		public RoleService(RoleManager<AppRole> roleManager)
		{
			_roleManager = roleManager;
		}

		public async Task<bool> CreateRoleAsync(string name)
		{
			IdentityResult result = await _roleManager.CreateAsync(new()
			{
				Name = name
			});
			return result.Succeeded;
		}

		public async Task<bool> DeleteRoleAsync(int id)
		{
			AppRole appRole = await _roleManager.FindByIdAsync(id.ToString());
            IdentityResult result = await _roleManager.DeleteAsync(appRole);
            return result.Succeeded;

        }

        public async Task<bool> UpdateRoleAsync(string name)
        {
			AppRole role = await _roleManager.FindByNameAsync(name);
			IdentityResult result=await _roleManager.UpdateAsync(role);
			return result.Succeeded;
        }
    }
}
