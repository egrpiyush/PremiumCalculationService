using MediatR;
using PremiumCalculationService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PremiumCalculationService.Application.Queries.GetOccupations
{
    public class GetOccupationsQuery : IRequest<IList<OccupationModel>>
    {
        public class Handler : IRequestHandler<GetOccupationsQuery, IList<OccupationModel>>
        {
            private readonly IOccupationRepository _repository;
            public Handler(IOccupationRepository repository)
            {
                _repository = repository;
            }
            public async Task<IList<OccupationModel>> Handle(GetOccupationsQuery request, CancellationToken cancellationToken)
            {
                return _repository.GetOccupations();
            }
        }
    }
}
