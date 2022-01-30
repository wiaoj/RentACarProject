using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation {
    public class CustomerValidator : AbstractValidator<Customer> {
        public CustomerValidator() {
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.UserId).NotNull();
            RuleFor(c => c.CompanyName).MinimumLength(2);
            RuleFor(c => c.CompanyName).MaximumLength(256);
        }
    }
}