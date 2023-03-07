using OnlineExamProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Abstractions.Services.Configuration
{
	public interface IApplicationService
	{
		Task<List<Menu>> GetAuthorizeDefinitionEndpoints(Type type);		
	}
}
