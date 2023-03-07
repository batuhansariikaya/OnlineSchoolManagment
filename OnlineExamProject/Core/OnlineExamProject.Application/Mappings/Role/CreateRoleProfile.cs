using AutoMapper;
using OnlineExamProject.Application.DTOs.Role;
using OnlineExamProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Mappings.Role
{
	public class CreateRoleProfile:Profile
	{
		public CreateRoleProfile()
		{
			CreateMap<AppRole,CreateRoleDTO>().ReverseMap();
		}
	}
}
