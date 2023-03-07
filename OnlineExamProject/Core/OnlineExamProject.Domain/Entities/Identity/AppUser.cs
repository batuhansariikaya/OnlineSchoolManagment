using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Domain.Entities.Identity
{
	public class AppUser:IdentityUser<int>
	{
		public string Name  { get; set; }
		public string Surname  { get; set; }
		public bool IsActive { get; set; }
		public ICollection<Exam> Exams { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
