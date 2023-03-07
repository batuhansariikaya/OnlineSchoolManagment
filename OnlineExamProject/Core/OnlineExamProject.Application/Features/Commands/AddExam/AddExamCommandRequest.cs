using MediatR;
using OnlineExamProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Features.Commands.AddExam
{
	public class AddExamCommandRequest:IRequest<AddExamCommandResponse>
	{
		//public string name { get; set; }
		//public string description { get; set; }
		//public int time { get; set; }
		//public int teacherId { get; set; }
		//public DateTime createdDate { get; set; }
		//public DateTime updatedDate { get; set; }
		public Exam Exam { get; set; }

	}
}
