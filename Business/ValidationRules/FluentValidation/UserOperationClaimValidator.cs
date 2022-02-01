using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation {
    public class UserOperationClaimValidator : AbstractValidator<UserOperationClaim> {
        public UserOperationClaimValidator() {
            RuleFor(b => b.Id).NotEmpty();
            RuleFor(b => b.UserId).NotEmpty();
        }
    }
}