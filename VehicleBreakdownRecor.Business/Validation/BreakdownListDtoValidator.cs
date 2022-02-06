using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleBreakdownRecord.Entity.DTOs;

namespace VehicleBreakdownRecor.Business.Validation
{
    public class BreakdownListDtoValidator:AbstractValidator<BreakdownListDto>
    {
        public BreakdownListDtoValidator()
        {
            RuleFor(x => x.BreakdownName).NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
