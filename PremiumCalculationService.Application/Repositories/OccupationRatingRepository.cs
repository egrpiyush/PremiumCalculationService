using PremiumCalculationService.Application.Interfaces;
using PremiumCalculationService.Application.Queries.GetOccupations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculationService.Application.Repositories
{
    public class OccupationRatingRepository : IOccupationRatingRepository
    {
        public IList<OccupationRatingModel> GetOccupationRatings()
        {
            return new List<OccupationRatingModel>
            {
                new OccupationRatingModel{ OccupationId= 1, RatingId = 3 },
                new OccupationRatingModel{ OccupationId= 2, RatingId = 1 },
                new OccupationRatingModel{ OccupationId= 3, RatingId = 2 },
                new OccupationRatingModel{ OccupationId= 4, RatingId = 4 },
                new OccupationRatingModel{ OccupationId= 5, RatingId = 4 },
                new OccupationRatingModel{ OccupationId= 6, RatingId = 3 }
            };
        }
    }
}
