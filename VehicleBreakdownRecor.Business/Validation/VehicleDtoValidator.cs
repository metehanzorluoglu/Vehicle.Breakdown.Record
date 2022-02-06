using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleBreakdownRecord.Entity.DTOs;

namespace VehicleBreakdownRecor.Business.Validation
{
    public class VehicleDtoValidator:AbstractValidator<VehivleDto>
    {
        public VehicleDtoValidator()
        {
            RuleFor(x => x.VehicleName)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.VehicleOwnerName)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.VehicleOwnerLastname)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.VehicleOwnerPhone)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.VehicleChassisNumber)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
