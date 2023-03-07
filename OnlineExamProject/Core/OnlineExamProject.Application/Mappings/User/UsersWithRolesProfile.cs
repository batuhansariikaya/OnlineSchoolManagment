﻿using OnlineExamProject.Application.DTOs.User;
using OnlineExamProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Mappings.User
{
	public class UsersWithRolesProfile: AutoMapper.Profile
	{
		public UsersWithRolesProfile()
		{
			CreateMap<UsersWithRolesDto, AppUser>().ReverseMap();
		}
	}
}
