using Castle.DynamicProxy;
using System.Reflection;

namespace Core.Utilities.Interceptors.Autofac {
    public class AspectInterceptorSelector : IInterceptorSelector {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors) {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); default logları eklemeyi sağlıyormuş
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}