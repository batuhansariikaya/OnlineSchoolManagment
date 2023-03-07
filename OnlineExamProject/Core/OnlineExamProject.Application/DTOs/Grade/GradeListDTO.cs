using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.DTOs.Grade
{
	public class GradeListDTO
	{
		//public int Id { get; set; }
		//public string Name { get; set; }
		//public string Code { get; set; }
		//public DateTime CreatedDate { get; set; }
		//public DateTime UpdatedDate { get; set; }
		public List<Domain.Entities.Grade> Grades { get; set; }
	}
}
