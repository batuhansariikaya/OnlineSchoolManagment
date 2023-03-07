using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.DTOs.User
{
	public class UsersWithRolesDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public bool EmailConfirmed { get; set; }
		public string Role { get; set; }
	}
}
