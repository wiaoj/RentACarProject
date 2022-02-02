using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace Core.CrossCuttingConcerns.Caching.Microsoft {
    public class MemoryCacheManager : ICacheManager {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheManager() => _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();

        public void Add(String key, object value, int duration) {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public Type Get<Type>(String key) {
            return _memoryCache.Get<Type>(key);
        }

        public object Get(string key) {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(String key) {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(String key) {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(String pattern) {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition?.GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new();

            foreach (var cacheItem in cacheEntriesCollection) {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            //cache elemanlarından bu kurala uyanları regex ile seçiyoruz
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove) { 
                _memoryCache.Remove(key);
            } 
        }
    }
}