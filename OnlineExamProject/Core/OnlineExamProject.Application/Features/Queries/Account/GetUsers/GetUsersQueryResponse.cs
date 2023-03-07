using OnlineExamProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Features.Queries.Account.GetUsers
{
	public class GetUsersQueryResponse
	{
		IQueryable<AppUser> users;
	}
}
