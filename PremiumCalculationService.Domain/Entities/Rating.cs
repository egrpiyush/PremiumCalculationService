using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculationService.Domain.Entities
{
    public class Rating
    {
        public string Name { get; set; }
        public decimal Factor { get; set; }
    }
}
