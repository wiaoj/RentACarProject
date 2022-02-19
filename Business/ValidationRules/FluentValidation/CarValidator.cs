﻿using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation {
    public class CarValidator : AbstractValidator<Car> {
        public CarValidator() {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);
            RuleFor(c => c.Name).MaximumLength(30);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.ModelYear).LessThanOrEqualTo(DateTime.Now.Year + 1);
            //GreaterThanOrEqualTo(10).When(c => c.brandId == 1);
            //Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı"); oluşturulan metod
        }
    }
}
