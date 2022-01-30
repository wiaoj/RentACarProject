﻿using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation {
    public class ColorValidator : AbstractValidator<Color> {
        public ColorValidator() {
            RuleFor(c => c.Name).MinimumLength(2);
            RuleFor(c => c.Name).MaximumLength(30);
        }
    }
}