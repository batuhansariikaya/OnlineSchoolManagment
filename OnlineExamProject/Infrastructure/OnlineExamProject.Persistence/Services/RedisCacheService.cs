using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Newtonsoft.Json;
using OnlineExamProject.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamProject.Persistence.Services
{

    public class RedisCacheService : IRedisService
    {
        private readonly RedisCache _redisCache;

        public RedisCacheService(RedisCache redisCache)
        {
            _redisCache = redisCache;
        }

        public bool Any(string key)
        {
            return _redisCache.Get(key) != null;
        }

        public byte[] Get(string key)
        {
            return _redisCache.Get(key);
        }

        public T Get<T>(string key)
        {
            var utf8String = Encoding.UTF8.GetString(Get(key));
            var result = JsonConvert.DeserializeObject<T>(utf8String);
            return result;
        }

        public void Refresh(string key)
        {
            _redisCache.Refresh(key);
        }

        public void Remove(string key)
        {
            _redisCache.Remove(key);
        }

        public void Set(string key, object value)
        {                  
            _redisCache.SetString(key, (string)value);
            
        }
    }
}
