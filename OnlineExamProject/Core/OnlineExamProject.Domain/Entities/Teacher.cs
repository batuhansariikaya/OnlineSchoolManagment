using OnlineExamProject.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Domain.Entities
{
	public class Teacher:BaseEntity
	{
		//public Teacher()
		//{
		//	Exams = new HashSet<Exam>();
		//}
		public string Name { get; set; }
		public string Surname { get; set; }
		//public ICollection<Exam> Exams { get; set; }
	
		// bir hoca birden fazla sınav yapabilir.
		
		
		
	}
}
