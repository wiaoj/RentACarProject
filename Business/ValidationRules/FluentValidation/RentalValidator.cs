using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation {
    public class RentalValidator : AbstractValidator<Rental> {
        public RentalValidator() {
            RuleFor(r => r.Id).NotNull();
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.CarId).NotNull();
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CustomerId).NotNull();
            RuleFor(r => r.CustomerId).NotEmpty();
        }
    }
}