using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Abstractions.Services
{
	public interface IAuthorizationEndpointService
	{
		public Task AssignRoleEndipointAsync(string roles,string menu,string code,Type type);	
	}
}
