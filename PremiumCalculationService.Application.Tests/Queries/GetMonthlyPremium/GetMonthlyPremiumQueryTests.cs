using AutoFixture;
using Moq;
using PremiumCalculationService.Application.Interfaces;
using PremiumCalculationService.Application.Queries.GetMonthlyPremium;
using PremiumCalculationService.Application.Queries.GetOccupations;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace PremiumCalculationService.Application.Tests.Queries.GetMonthlyPremium
{
    public class GetMonthlyPremiumQueryTests
    {
        private static readonly Fixture Fixture = new Fixture();
        private static readonly CancellationToken CancellationToken = CancellationToken.None;
        /*
         premium amount = (cover amount * Occupation Rating Factor * Age) / 1000 * 12
         */

        [Fact]
        public async void WhenCoverAmountIsZero_MonthlyPremiumShouldBeZero()
        {
            //Arange
            var request = Fixture.Build<GetMonthlyPremiumQuery>()
                .Without(p => p.CoverAmount)
                .Create();
            var occupationRating = new OccupationRatingModel { OccupationId = 1, RatingId = 3 };
            var occupationRatingRepositoryMock = Fixture.Freeze<Mock<IOccupationRatingRepository>>();
            occupationRatingRepositoryMock.Setup(f => f.GetOccupationRating(request.OccupationId))
                .Returns(occupationRating);
            var rating = new RatingModel { Id = 3, Factor = 1.5M };
            var ratingRepositoryMock = Fixture.Freeze<Mock<IRatingRepository>>();
            ratingRepositoryMock.Setup(f => f.GetRating(occupationRating.RatingId))
                .Returns(rating);
            var handler = new GetMonthlyPremiumQuery.Handler(occupationRatingRepositoryMock.Object, ratingRepositoryMock.Object);
            //Act
            var result = await 
                handler.Handle(request, CancellationToken);
            //Assert
            result.Amount.ShouldBe(0);
        }

        [Fact]
        public async void WhenAgeIsZero_MonthlyPremiumShouldBeZero()
        {
            //Arange
            var request = Fixture.Build<GetMonthlyPremiumQuery>()
                .Without(p => p.Age)
                .Create();
            var occupationRating = new OccupationRatingModel { OccupationId = 1, RatingId = 3 };
            var occupationRatingRepositoryMock = Fixture.Freeze<Mock<IOccupationRatingRepository>>();
            occupationRatingRepositoryMock.Setup(f => f.GetOccupationRating(request.OccupationId))
                .Returns(occupationRating);
            var rating = new RatingModel { Id = 3, Factor = 1.5M };
            var ratingRepositoryMock = Fixture.Freeze<Mock<IRatingRepository>>();
            ratingRepositoryMock.Setup(f => f.GetRating(occupationRating.RatingId))
                .Returns(rating);
            var handler = new GetMonthlyPremiumQuery.Handler(occupationRatingRepositoryMock.Object, ratingRepositoryMock.Object);
            //Act
            var result = await
                handler.Handle(request, CancellationToken);
            //Assert
            result.Amount.ShouldBe(0);
        }

        [Fact]
        public async void WhenOccupationHasNoRating_MonthlyPremiumShouldBeZero()
        {
            //Arange
            var request = Fixture.Build<GetMonthlyPremiumQuery>().Create();
            OccupationRatingModel occupationRating = null;
            var occupationRatingRepositoryMock = Fixture.Freeze<Mock<IOccupationRatingRepository>>();
            occupationRatingRepositoryMock.Setup(f => f.GetOccupationRating(request.OccupationId))
                .Returns(occupationRating);
            var rating = new RatingModel { Id = 3, Factor = 1.5M };
            var ratingRepositoryMock = Fixture.Freeze<Mock<IRatingRepository>>();
            ratingRepositoryMock.Setup(f => f.GetRating(It.IsAny<int>()))
                .Returns(rating);
            var handler = new GetMonthlyPremiumQuery.Handler(occupationRatingRepositoryMock.Object, ratingRepositoryMock.Object);
            //Act
            var result = await handler.Handle(request, CancellationToken);
            //Assert
            result.Amount.ShouldBe(0);
        }

        [Fact]
        public async void WhenRatingDoesNotExist_MonthlyPremiumShouldBeZero()
        {
            //Arange
            var request = Fixture.Build<GetMonthlyPremiumQuery>().Create();
            var occupationRating = new OccupationRatingModel { OccupationId = 1, RatingId = 3 };
            var occupationRatingRepositoryMock = Fixture.Freeze<Mock<IOccupationRatingRepository>>();
            occupationRatingRepositoryMock.Setup(f => f.GetOccupationRating(request.OccupationId))
                .Returns(occupationRating);
            RatingModel rating = null;
            var ratingRepositoryMock = Fixture.Freeze<Mock<IRatingRepository>>();
            ratingRepositoryMock.Setup(f => f.GetRating(It.IsAny<int>()))
                .Returns(rating);
            var handler = new GetMonthlyPremiumQuery.Handler(occupationRatingRepositoryMock.Object, ratingRepositoryMock.Object);
            //Act
            var result = await handler.Handle(request, CancellationToken);
            //Assert
            result.Amount.ShouldBe(0);
        }

        [Fact]
        public async void WhenCoverAmountIsOne_MonthlyPremiumShouldNotBeZero()
        {
            //Arange
            var request = Fixture.Build<GetMonthlyPremiumQuery>()
                .With(p => p.CoverAmount, 1)
                .Create();
            var occupationRating = new OccupationRatingModel { OccupationId = 1, RatingId = 3 };
            var occupationRatingRepositoryMock = Fixture.Freeze<Mock<IOccupationRatingRepository>>();
            occupationRatingRepositoryMock.Setup(f => f.GetOccupationRating(request.OccupationId))
                .Returns(occupationRating);
            var rating = new RatingModel { Id = 3, Factor = 1.5M };
            var ratingRepositoryMock = Fixture.Freeze<Mock<IRatingRepository>>();
            ratingRepositoryMock.Setup(f => f.GetRating(occupationRating.RatingId))
                .Returns(rating);
            var handler = new GetMonthlyPremiumQuery.Handler(occupationRatingRepositoryMock.Object, ratingRepositoryMock.Object);
            //Act
            var result = await handler.Handle(request, CancellationToken);
            //Assert
            result.Amount.ShouldNotBe(0);
        }

    }
}
