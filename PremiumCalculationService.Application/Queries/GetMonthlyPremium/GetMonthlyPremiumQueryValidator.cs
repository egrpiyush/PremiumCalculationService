using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculationService.Application.Queries.GetMonthlyPremium
{
    public class GetMonthlyPremiumQueryValidator : AbstractValidator<GetMonthlyPremiumQuery>
    {
        public GetMonthlyPremiumQueryValidator()
        {
            RuleFor(p => p.CoverAmount)
                .GreaterThan(0);
            RuleFor(p => p.OccupationId)
                .GreaterThan(0);
            RuleFor(p => p.Age)
                .GreaterThan(0);
        }
    }
}
