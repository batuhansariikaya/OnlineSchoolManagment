using OnlineExamProject.Domain.Entities.Common;
using OnlineExamProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Domain.Entities
{
    public class Grade:BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
