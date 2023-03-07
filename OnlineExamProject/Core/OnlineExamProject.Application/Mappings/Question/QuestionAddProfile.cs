using AutoMapper;
using OnlineExamProject.Application.ViewModels.Question;
using OnlineExamProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Mappings
{
	public class QuestionAddProfile:Profile
	{
		public QuestionAddProfile()
		{
			CreateMap<Question, VM_QuestionAdd>().ReverseMap();
		}
	}
}
