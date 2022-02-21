using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation {
    public class AuthValidator :AbstractValidator<User> {
        public AuthValidator() { }
    }
}
