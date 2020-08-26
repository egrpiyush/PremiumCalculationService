using PremiumCalculationService.Application.Queries.GetOccupations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculationService.Application.Interfaces
{
    public interface IRatingRepository
    {
        IList<RatingModel> GetRatings();
        RatingModel GetRating(int ratingId);
    }
}
