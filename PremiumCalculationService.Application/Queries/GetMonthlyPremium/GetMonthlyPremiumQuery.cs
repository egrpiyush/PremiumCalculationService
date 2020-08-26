using MediatR;
using System;
using System.Collections.Generic;
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
            public Handler()
            {

            }
            public Task<MonthlyPremium> Handle(GetMonthlyPremiumQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
