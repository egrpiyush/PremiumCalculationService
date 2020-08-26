using MediatR;
using PremiumCalculationService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PremiumCalculationService.Application.Queries.GetMonthlyPremium
{
    public class GetMonthlyPremiumQuery : IRequest<MonthlyPremium>
    {
        public decimal CoverAmount { get; set; }
        public int OccupationId { get; set; }
        public decimal Age { get; set; }

        public class Handler : IRequestHandler<GetMonthlyPremiumQuery, MonthlyPremium>
        {
            private readonly IOccupationRatingRepository _occupationRatingRepository;
            private readonly IRatingRepository _ratingRepository;
            public Handler(IOccupationRatingRepository occupationRatingRepository, IRatingRepository ratingRepository)
            {
                _occupationRatingRepository = occupationRatingRepository;
                _ratingRepository = ratingRepository;
            }
            public async Task<MonthlyPremium> Handle(GetMonthlyPremiumQuery request, CancellationToken cancellationToken)
            {
                var monthlyPremium = new MonthlyPremium();
                var occupationRating = _occupationRatingRepository.GetOccupationRating(request.OccupationId);
                var occupationRatingFactor = _ratingRepository.GetRating(occupationRating.RatingId).Factor;
                monthlyPremium.Amount = (request.CoverAmount * occupationRatingFactor * request.Age) / 1000 * 12;
                return monthlyPremium;
            }
        }
    }
}
