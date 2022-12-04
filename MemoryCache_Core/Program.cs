using System;

namespace MemoryCache_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("设置永不过期");
            MemoryCacheDemo.SetNeverExpire("NeverExpire", "1");
            Console.WriteLine("设置绝对过期");
            MemoryCacheDemo.SetAbsoluteExpiration("AbsoluteExpiration", "2", new DateTime(2022, 12, 04, 18, 30, 00));
            Console.WriteLine("设置相对过期");
            MemoryCacheDemo.SetExpirationTimeRelativeToThePresent("ExpirationTimeRelativeToThePresent", "3", new TimeSpan(0, 0, 1));
            Console.WriteLine("设置滑动过期");
            MemoryCacheDemo.SetSlidingExpiration("SlidingExpiration", "4", new TimeSpan(0, 0, 1), DateTimeOffset.Now.AddMinutes(1));

            Console.WriteLine("获取{0}缓存值：{1}", "NeverExpire", MemoryCacheDemo.GetCacheByKey("NeverExpire"));
            Console.WriteLine("获取{0}缓存值：{1}", "AbsoluteExpiration", MemoryCacheDemo.GetCacheByKey("AbsoluteExpiration"));
            Console.WriteLine("获取{0}缓存值：{1}", "ExpirationTimeRelativeToThePresent", MemoryCacheDemo.GetCacheByKey("ExpirationTimeRelativeToThePresent"));
            Console.WriteLine("获取{0}缓存值：{1}", "SlidingExpiration", MemoryCacheDemo.GetCacheByKey("SlidingExpiration"));

            Console.WriteLine("删除缓存");
            MemoryCacheDemo.RemoveCacheByKey("NeverExpire");
            MemoryCacheDemo.RemoveCacheByKey("AbsoluteExpiration");
            MemoryCacheDemo.RemoveCacheByKey("ExpirationTimeRelativeToThePresent");
            MemoryCacheDemo.RemoveCacheByKey("SlidingExpiration");

            Console.ReadKey();
        }
    }
}
