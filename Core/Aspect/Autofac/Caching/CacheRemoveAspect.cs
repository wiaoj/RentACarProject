using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors.Autofac;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspect.Autofac.Caching {
    public class CacheRemoveAspect : MethodInterception {
        private readonly String _pattern;
        private readonly ICacheManager _cacheManager;
        public CacheRemoveAspect(String pattern) {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation) {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}