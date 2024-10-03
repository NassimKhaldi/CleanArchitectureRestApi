using Application.Common.Constants;
using Application.Common.Validator;
using Application.Features.ProductFeature.Commands;
using Application.Features.TestFeature.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeature.Validators
{
    public class AddProductCommandValidator : ValidatorBase<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty()
                .WithMessage(ValidationConstants.NameMustHasValue);

            RuleFor(v => v.Description).NotEmpty()
                .WithMessage(ValidationConstants.DescriptionMustHasValue);

            RuleFor(v => v.Price).NotEmpty();

            RuleFor(v => v.Price).NotEmpty();
        }
    }
}
