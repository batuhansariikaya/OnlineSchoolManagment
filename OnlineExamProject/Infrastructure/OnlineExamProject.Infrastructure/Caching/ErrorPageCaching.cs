using Microsoft.Extensions.Caching.Distributed;
using OnlineExamProject.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Infrastructure.Caching
{
    public class ErrorPageCaching:ICacheService
    {
        private readonly IDistributedCache _distributedCache;

        public ErrorPageCaching(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

       public void CachePage(Type type)
        {
            string path = Path.Combine(type.ToString(), "Views/Error/Error401.cshtml");
            byte[] fileByte = System.IO.File.ReadAllBytes(path);
            _distributedCache.Set("htmlFile", fileByte);
        }

        public Task Clear(string key)
        {
            throw new NotImplementedException();
        }

        public void ClearAll()
        {
            throw new NotImplementedException();
        }

        public T GetOrAdd<T>(string key, Func<T> action) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> action) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<string> GetValueAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetValueAsync(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}
