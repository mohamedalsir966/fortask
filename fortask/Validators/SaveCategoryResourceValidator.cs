﻿using fortask.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fortask.Validators
{
    public class SaveCategoryResourceValidator : AbstractValidator<SaveCategoryResource>
    {
        public SaveCategoryResourceValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("name from alisr is required");
        }
    }
}
