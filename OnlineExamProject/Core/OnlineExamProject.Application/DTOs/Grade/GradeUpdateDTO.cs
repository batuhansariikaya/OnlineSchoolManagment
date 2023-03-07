using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.DTOs.Grade
{
    public class GradeUpdateDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
