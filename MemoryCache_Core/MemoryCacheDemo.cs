using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryCache_Core
{
    public class MemoryCacheDemo
    {
        private static IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        #region 缓存过期时间类型
        /// <summary>
        /// 永不过期
        /// 不清理该缓存，该缓存就一直有效
        /// </summary>
        public static void SetNeverExpire(string key, string value)
        {
            _cache.Set(key, value);
        }

        /// <summary>
        /// 绝对过期
        /// </summary>
        public static void SetAbsoluteExpiration(string key, string value, DateTime absoluteTime)
        {
            _cache.Set(key, value, absoluteTime);
        }

        /// <summary>
        /// 相对过期
        /// </summary>
        public static void SetExpirationTimeRelativeToThePresent(string key, string value, TimeSpan timeSpan)
        {
            _cache.Set(key, value, timeSpan);
        }

        /// <summary>
        /// 滑动过期
        /// 设定的时间内未被使用则失效，使用后过期时间则被重新刷新
        /// </summary>
        public static void SetSlidingExpiration(string key, string value, TimeSpan slidTimeSpan, DateTimeOffset absoluteDateTimeOffset)
        {
            _cache.Set(key, value, new MemoryCacheEntryOptions()
            {
                SlidingExpiration = slidTimeSpan,
                // 设置缓存项的绝对到期日期，为当前缓存设置后的10分钟
                AbsoluteExpiration = absoluteDateTimeOffset
            });
        }
        #endregion

        #region 获取缓存值
        public static string GetCacheByKey(string key)
        {
           return _cache.Get(key).ToString();
        }

        public static void GetCacheByKey(string key, out string value)
        {
            if(!_cache.TryGetValue(key, out value))
            {
                throw new Exception("该缓存不存在或者已过期");
            }
        }
        #endregion

        #region 清除缓存值
        public static void RemoveCacheByKey(string key)
        {
            if(!_cache.TryGetValue(key, out _))
            {
                _cache.Remove(key);
            }
        }
        #endregion
    }
}
