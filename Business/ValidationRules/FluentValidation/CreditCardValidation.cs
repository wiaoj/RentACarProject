using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation {
    public class CreditCardValidation : AbstractValidator<CreditCard> {
        public CreditCardValidation() {
            RuleFor(c => c.CustomerId).NotEmpty();
            RuleFor(c => c.FullName).NotEmpty();
            RuleFor(c => c.CardNumber).NotEmpty();
            RuleFor(c => c.ExpirationMounth).NotEmpty();
            RuleFor(c => c.ExpirationYear).NotEmpty();
            RuleFor(c => c.Cvv).NotEmpty();
        }
    }
}