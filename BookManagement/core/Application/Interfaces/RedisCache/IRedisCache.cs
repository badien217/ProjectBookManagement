﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.RedisCache
{
    public interface IRedisCache
    {
        Task<T> GetAsync<T>(object key);
        Task SetAsync<T>(string key, T value, DateTime? expirationTime = null);
    }
}
