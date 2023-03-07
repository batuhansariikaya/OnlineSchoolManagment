using OnlineExamProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.ViewModels.Question
{
	public  class VM_QuestionAdd
	{
		public int Id { get; set; }
		public string QuestionHeader { get; set; }
		public string OptionA { get; set; }
		public string OptionB { get; set; }
		public string OptionC { get; set; }
		public string OptionD { get; set; }
		public int AnswerKey { get; set; }
		public int ExamId { get; set; }
		

	}
}
