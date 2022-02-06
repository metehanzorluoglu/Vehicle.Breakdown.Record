using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleBreakdownRecord.Entity.DTOs;

namespace VehicleBreakdownRecor.Business.Validation
{
    public class VehicleCommentDtoValidator:AbstractValidator<VehicleCommentDto>
    {
        public VehicleCommentDtoValidator()
        {
            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
