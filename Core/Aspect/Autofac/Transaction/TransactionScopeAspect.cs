using Castle.DynamicProxy;
using Core.Utilities.Interceptors.Autofac;
using System.Transactions;

namespace Core.Aspect.Autofac.Transaction {
    public class TransactionScopeAspect : MethodInterception {
        public override void Intercept(IInvocation invocation) {
            using TransactionScope transactionScope = new();
            try {
                invocation.Proceed();
                transactionScope.Complete();
            } catch (Exception exception) {
                transactionScope.Dispose();
                throw;
            }
        }
    }
}