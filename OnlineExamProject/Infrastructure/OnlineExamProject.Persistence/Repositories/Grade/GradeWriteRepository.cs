using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Domain.Entities;
using OnlineExamProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Persistence.Repositories
{
    public class GradeWriteRepository : WriteRepository<Grade>, IGradeWriteRepository
    {
        public GradeWriteRepository(OnlineExamProjectDbContext context) : base(context)
        {
        }
    }
}
