using OnlineExamProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Application.Abstractions.Services
{
    public interface IEndpointCacheService
    {
        Task GetDatasFromCache();
        void SetDatasFromCache(List<string> endpoints);

    }
}
