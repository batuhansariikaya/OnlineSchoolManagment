using Microsoft.EntityFrameworkCore;
using OnlineExamProject.Application.Repositories;
using OnlineExamProject.Domain.Entities.Common;
using OnlineExamProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Persistence.Repositories
{
	public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
	{
		readonly private OnlineExamProjectDbContext _context;
		public ReadRepository(OnlineExamProjectDbContext context)
		{
			_context = context;
		}
		public DbSet<T> Table => _context.Set<T>();

		
		public IQueryable<T> GetAll(bool tracking = true)
		{
			var query = Table.AsQueryable();
			if (!tracking)
				query = query.AsNoTracking();
			return query;
		}

        public IQueryable<T> GetAllActive(bool tracking = true)
        {
            var query = Table.AsQueryable().Where(x=>x.Status==true);
            if (!tracking)
                query = query.AsNoTracking();
            return query; ;
        }

        public IQueryable<T> GetAllPassive(bool tracking = true)
        {
            var query = Table.AsQueryable().Where(x => x.Status == false);
            if (!tracking)
                query = query.AsNoTracking();
            return query; ;
        }

        public async Task<T> GetByIdAsync(int id, bool tracking = true)
		{
			return await Table.FirstOrDefaultAsync(x=>x.Id==id);
		}

		public T GetIdInfo(int id)
		{
			return Table.FirstOrDefault(x => x.Id == id);
		}

		public async  Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
		{
			var query = Table.AsQueryable();
			if (!tracking)
				query = query.AsNoTracking();
			return await query.SingleOrDefaultAsync(method);
		}

		public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
		{
			var query = Table.Where(method);
			if (!tracking)
				query = query.AsNoTracking();
			return query;

		}
	}
}
