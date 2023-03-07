using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.DTOs.User
{
	public class UserUpdateDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Username { get; set; }
		public string EMail { get; set; }
		public string PhoneNumber { get; set; }
		public string Role { get; set; }
		//public string Grade { get; set; }
	}
}
