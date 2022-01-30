using Business.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation {
    public class UserValidator : AbstractValidator<User> {
        public UserValidator() {
            RuleFor(u => u.FirstName).NotNull();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.FirstName).MaximumLength(50);
            RuleFor(u => u.LastName).NotNull();
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.LastName).MaximumLength(50);
            RuleFor(u => u.EmailAdress).NotNull().WithMessage(Messages.EmailAdressInvalidSpaces);
            //RuleFor(u => u.EmailAdress).Empty().WithMessage(Messages.EmailAdressEmpty);
            RuleFor(u => u.EmailAdress).Must(mail => { return mail is not null && !mail.Contains(' '); }).WithMessage(Messages.EmailAdressInvalidSpaces);
            RuleFor(u => u.EmailAdress).Must(mail => { return mail is not null && mail.Contains('@'); }).WithMessage(Messages.EmailAdressInvalid);
            RuleFor(u => u.EmailAdress).MaximumLength(256);
            RuleFor(u => u.Password).NotNull();
            RuleFor(u => u.Password).MinimumLength(8);
            RuleFor(u => u.Password).MaximumLength(50);
        }
    }
}