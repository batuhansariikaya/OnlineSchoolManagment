using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
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
	public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
	{
		readonly private OnlineExamProjectDbContext _context;
		

		public WriteRepository(OnlineExamProjectDbContext context)
		{
			_context = context;
		}

		public DbSet<T> Table => _context.Set<T>();

		public async Task<bool> AddAsync(T model)
		{
			EntityEntry<T> entityEntry = await Table.AddAsync(model);
			return entityEntry.State == EntityState.Added;
			
		}

		public Task<bool> AddRangeAsync(List<T> datas)
		{
			throw new NotImplementedException();
		}

		public void AddT(T model)
		{
			//_context.Add(model);
			Table.AddAsync(model);
		}

        public bool MakeActive(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            model.Status = true;
            return entityEntry.State == EntityState.Modified;

        }

        //public  bool Commit(bool state = true)
        //{
        //	 SaveAsync();
        //	if (state)
        //		transaction.Commit();
        //	else
        //		transaction.Rollback();
        //	Dispose();
        //	return true;
        //}

        //public void Dispose()
        //{
        //	_context.Dispose();
        //}

        public bool Remove(T model)
		{
			//_context.Remove(model);
			//return true;
			
			EntityEntry<T> entityEntry = Table.Update(model);
			model.Status = false;
            return entityEntry.State == EntityState.Modified;
		}

		public Task<bool> RemoveAsync(int id)
		{
			throw new NotImplementedException();
		}

		public bool RemoveRange(List<T> datas)
		{
			throw new NotImplementedException();
		}

		public async Task<int> SaveAsync()
			=> await _context.SaveChangesAsync();

		public bool Update(T model)
		{			
			EntityEntry<T> entityEntry = Table.Update(model);
			return entityEntry.State == EntityState.Modified;
		}
	}
}
