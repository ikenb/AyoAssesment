using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConvertMetricUnits.Core.Helpers
{
    public static class RedisHelper
    {
        //public static async Task SetRecordAsync<T>(this IDistributedCache cache,string recordId,T data, TimeSpan? absoluteExpireTime = null,TimeSpan? unusedExpireTime = null)
        //{
        //    var options = new DistributedCacheEntryOptions();

        //    options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60);
        //    options.SlidingExpiration = unusedExpireTime;

        //    var jsonData = JsonSerializer.Serialize(data);
             
        //}

        //public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordId)
        //{
        //    var jsonData = await cache.GetStringAsync(recordId);

        //    if (jsonData is null)
        //    {
        //        return default(T);
        //    }

        //    return jsonData;
        //}

       
    }
}
