using PremiumCalculationService.Application.Queries.GetOccupations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculationService.Application.Repositories
{
    public class RatingRepository
    {
        public IList<RatingModel> GetRatings()
        {
            return new List<RatingModel>
            {
                new RatingModel{ Id= 1, Name = "Professional", Factor = 1},
                new RatingModel{ Id= 2, Name = "White Collar", Factor = 1.25M},
                new RatingModel{ Id= 3, Name = "Light Manual", Factor = 1.5M},
                new RatingModel{ Id= 4, Name = "Light Manual", Factor = 1.75M}
            };
        }
    }
}
