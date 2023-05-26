using Microsoft.Extensions.Caching.Distributed;
using OnlineExamProject.Application.Abstractions.Services;
using OnlineExamProject.Application.Abstractions.Services.Configuration;
using OnlineExamProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Persistence.Services
{
    public class EndpointCacheService : IEndpointCacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IApplicationService _applicationService;


        public EndpointCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public Task GetDatasFromCache()
        {
            
            throw new NotImplementedException();
        }

       
        public void SetDatasFromCache(List<string> endpoints)
        {
            _distributedCache.SetString("endpointList", endpoints.ToString());
        }
    }
}
