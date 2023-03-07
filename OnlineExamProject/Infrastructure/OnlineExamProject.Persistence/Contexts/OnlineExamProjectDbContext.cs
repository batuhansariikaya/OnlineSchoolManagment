
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineExamProject.Domain.Entities;
using OnlineExamProject.Domain.Entities.Common;
using OnlineExamProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineExamProject.Persistence.Contexts
{
	public class OnlineExamProjectDbContext:IdentityDbContext<AppUser,AppRole,int>
	{
		public OnlineExamProjectDbContext(DbContextOptions options) : base(options)
		{
             
		}

		public DbSet<Exam> Exams { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<Endpoint> Endpoints { get; set; }
		public DbSet<Menu> Menus { get; set; }
	    public DbSet<Grade> Grades { get; set; }
	

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
