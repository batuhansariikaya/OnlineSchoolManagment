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
    public class MenuReadRepository : ReadRepository<Menu>, IMenuReadRepository
    {
        public MenuReadRepository(OnlineExamProjectDbContext context) : base(context)
        {
        }
    }
}
