using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Abstractions.Services
{
	public interface IRoleService
	{
		 Task<bool> CreateRoleAsync(string name); 
		 Task<bool> DeleteRoleAsync(int id);
		 Task<bool> UpdateRoleAsync(string name);
	}
}
