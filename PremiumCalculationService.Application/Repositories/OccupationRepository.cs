using PremiumCalculationService.Application.Interfaces;
using PremiumCalculationService.Application.Queries.GetOccupations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremiumCalculationService.Application.Repositories
{
    public class OccupationRepository : IOccupationRepository
    {
        public IList<OccupationModel> GetOccupations()
        {
            return new List<OccupationModel>
            {
                new OccupationModel{ Id= 1, Name = "Cleaner"},
                new OccupationModel{ Id= 2, Name = "Doctor"},
                new OccupationModel{ Id= 3, Name = "Author"},
                new OccupationModel{ Id= 4, Name = "Farmer"},
                new OccupationModel{ Id= 5, Name = "Mechanic"},
                new OccupationModel{ Id= 6, Name = "Florist"}
            };
        }
    }
}
