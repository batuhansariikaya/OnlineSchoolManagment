using OnlineExamProject.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T>   where T : BaseEntity
    {
        void AddT(T model);
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T model);
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveAsync(int id);
        bool Update(T model);

        Task<int> SaveAsync();
        bool MakeActive(T model);
    }
}
