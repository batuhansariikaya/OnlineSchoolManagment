using OnlineExamProject.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Domain.Entities
{
	public class Question:BaseEntity
	{
		public string QuestionHeader { get; set; }
		public string OptionA { get; set; }
		public string OptionB { get; set; }
		public string OptionC { get; set; }
		public string OptionD { get; set; }
		public int AnswerKey { get; set; }
		public int ExamId { get; set; }
		public Exam Exam { get; set; }
		// bir sınavın birden fazla sorusu vardır.
		
	}
}
