using OnlineExamProject.Application.DTOs.Configuration;
using OnlineExamProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.DTOs
{
	public class RoleAndEndpointDTO
	{
		public List<AppRole> Roles { get; set; }
		public List<Menu> Menu { get; set; }
		
		//public string[] Roles { get; set; }
		//public string Menu { get; set; }
		public string Code { get; set; }
	}
}
