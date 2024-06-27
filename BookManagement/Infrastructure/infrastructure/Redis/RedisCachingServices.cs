﻿using Application.Interfaces.RedisCache;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Redis
{
    public class RedisCachingServices : IRedisCache
    {
        private readonly ConnectionMultiplexer redisConnection;
        private readonly StackExchange.Redis.IDatabase database;
        private readonly RedisCachingSetting settings;
        public RedisCachingServices(IOptions<RedisCachingSetting> options)
        {
            settings = options.Value;
            var opt = ConfigurationOptions.Parse(settings.ConnectionString);
            redisConnection = ConnectionMultiplexer.Connect(opt);
            database = redisConnection.GetDatabase();
        }
        public async Task<T> GetAsync<T>(object key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var stringKey = key.ToString();

            var value = await database.StringGetAsync(stringKey);
            if (value.HasValue)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }

            return default;
        }

        public async Task SetAsync<T>(string key, T value, DateTime? expirationTime = null)
        {
            TimeSpan timeUnitExpiration = expirationTime.Value - DateTime.Now;
            await database.StringSetAsync(key, JsonConvert.SerializeObject(value), timeUnitExpiration);
        }
    }
}
