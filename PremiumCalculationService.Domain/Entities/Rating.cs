﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculationService.Domain.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Factor { get; set; }
    }
}
