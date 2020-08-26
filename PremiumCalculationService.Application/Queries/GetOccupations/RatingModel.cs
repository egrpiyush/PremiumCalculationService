using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculationService.Application.Queries.GetOccupations
{
    public class RatingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Factor { get; set; }
    }
}
