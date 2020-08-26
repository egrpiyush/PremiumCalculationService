using AutoFixture;
using Moq;
using PremiumCalculationService.Application.Interfaces;
using PremiumCalculationService.Application.Queries.GetOccupations;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace PremiumCalculationService.Application.Tests.Queries.GetOccupations
{
    public class GetOccupationsQueryTests
    {
        private static readonly Fixture Fixture = new Fixture();
        private static readonly CancellationToken CancellationToken = CancellationToken.None;

        [Fact]
        public async void WhenNoOccupationsExist_ShouldReturnNull()
        {
            //Arange
            var request = Fixture.Build<GetOccupationsQuery>()
                .Create();
            IList<OccupationModel> occupations = null;
            var repositoryMock = Fixture.Freeze<Mock<IOccupationRepository>>();
            repositoryMock.Setup(f => f.GetOccupations())
                .Returns(occupations); ;
            var handler = new GetOccupationsQuery.Handler(repositoryMock.Object);
            //Act
            var result = await handler.Handle(request, CancellationToken);
            //Assert
            result.ShouldBeNull();
        }

        [Fact]
        public async void WhenOneOccupationExists_ShouldReturnOneOccupation()
        {
            //Arange
            var request = Fixture.Build<GetOccupationsQuery>()
                .Create();
            var repositoryMock = Fixture.Freeze<Mock<IOccupationRepository>>();
            repositoryMock.Setup(f => f.GetOccupations())
                .Returns(new List<OccupationModel>
                {
                    Fixture.Build<OccupationModel>().Create()
                });
            var handler = new GetOccupationsQuery.Handler(repositoryMock.Object);
            //Act
            var result = await handler.Handle(request, CancellationToken);
            //Assert
            result.Count.ShouldBe(1);
        }
    }
}
