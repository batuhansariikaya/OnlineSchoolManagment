using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamProject.Domain.Entities;
using OnlineExamProject.Application.ViewModels.Teacher;
using OnlineExamProject.Application.ViewModels.Exam;
using OnlineExamProject.Application.DTOs.Exam;
using OnlineExamProject.Application.DTOs.Grade;

namespace OnlineExamProject.Application.Mappings
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			CreateMap<Teacher, VM_TeacherAdd>().ForMember(x => x.fullName, opt =>
			{
				opt.MapFrom(src => src.Name + "" + src.Surname);
			}).ReverseMap(); ;			
			CreateMap<Exam,ExamListDTO>().ReverseMap();
			CreateMap<Menu, Application.DTOs.Configuration.Menu>().ReverseMap();
			CreateMap<Grade, GradeAddDTO>().ReverseMap();
			//CreateMap<Grade, GradeListDTO>().ReverseMap();
			//CreateMap<VM_TeacherAdd, Teacher>()

			/* bu yöntem haricinden ReverseMap ile de tersine eşleme yapılabilir
			 * CreateMap<VM_TeacherAdd, Teacher>().ReverseMap();
			 */
			//CreateMap<VM_ListExam, Exam>();
			//CreateMap<Exam, VM_ListExam>();
		}
	}
}
