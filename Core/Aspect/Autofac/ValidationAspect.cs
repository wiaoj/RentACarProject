using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors.Autofac;
using Core.Utilities.Messages;
using FluentValidation;

namespace Core.Aspect.Autofac {
    public class ValidationAspect : MethodInterception {
        private readonly Type _validatorType;
        public ValidationAspect(Type validatorType) {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new System.Exception(Messages.WrongValidationType);
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation) {
            var validator = Activator.CreateInstance(_validatorType) as IValidator;
            var entityType = _validatorType?.BaseType?.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(type => type.GetType().Equals(entityType));

            foreach (var entity in entities)
                ValidationTool.Validate(validator, entity);
        }
    }
}