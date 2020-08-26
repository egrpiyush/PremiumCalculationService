using AutoFixture;
using FluentValidation.TestHelper;
using PremiumCalculationService.Application.Queries.GetMonthlyPremium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PremiumCalculationService.Application.Tests.Queries.GetMonthlyPremium
{
    public class GetMonthlyPremiumQueryValidatorTests
    {
        private readonly GetMonthlyPremiumQueryValidator _rulesValidator;
        private static readonly Fixture Fixture = new Fixture();
        public GetMonthlyPremiumQueryValidatorTests()
        {
            _rulesValidator = new GetMonthlyPremiumQueryValidator();
        }

        [Fact]
        public void WhenCoverAmountIsLessThanZero_ShouldHaveValidationError()
        {
            var sut = Fixture.Build<GetMonthlyPremiumQuery>()
                    .With(p => p.CoverAmount, -1)
                    .Create();
            _rulesValidator.ShouldHaveValidationErrorFor(p => p.CoverAmount, sut);
        }

        [Fact]
        public void WhenCoverAmountIsZero_ShouldHaveValidationError()
        {
            var sut = Fixture.Build<GetMonthlyPremiumQuery>()
                    .Without(p => p.CoverAmount)
                    .Create();
            _rulesValidator.ShouldHaveValidationErrorFor(p => p.CoverAmount, sut);
        }

        [Fact]
        public void WhenOccupationIdIsInvalid_ShouldHaveValidationError()
        {
            var sut = Fixture.Build<GetMonthlyPremiumQuery>()
                    .Without(p => p.OccupationId)
                    .Create();
            _rulesValidator.ShouldHaveValidationErrorFor(p => p.OccupationId, sut);
        }

        [Fact]
        public void WhenAgeIsInvalid_ShouldHaveValidationError()
        {
            var sut = Fixture.Build<GetMonthlyPremiumQuery>()
                    .Without(p => p.Age)
                    .Create();
            _rulesValidator.ShouldHaveValidationErrorFor(p => p.Age, sut);
        }
    }
}
