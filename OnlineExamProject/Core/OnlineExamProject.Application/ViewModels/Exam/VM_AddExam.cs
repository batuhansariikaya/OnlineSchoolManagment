using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.ViewModels.Exam
{
	public class VM_AddExam
	{
		public string name { get; set; }
		public string description { get; set; }
		public int time { get; set; }
		public int teacherId { get; set; }
		//public DateTime createdDate { get; set; }
		//public DateTime updatedDate { get; set; }
		
	}
}
