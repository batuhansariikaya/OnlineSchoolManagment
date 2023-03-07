using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.DTOs.Exam
{
	public class ExamListDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime CreateDate { get; set; }
		public int Time { get; set; }
		public bool Status { get; set; }
	}
}
