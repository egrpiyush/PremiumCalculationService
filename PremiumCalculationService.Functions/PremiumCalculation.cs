using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using PremiumCalculationService.Application.Queries.GetOccupations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PremiumCalculationService.Functions
{
    public class PremiumCalculation
    {
        private readonly IMediator _mediator;
        public PremiumCalculation(IMediator mediator)
        {
            _mediator = mediator;
        }

        [FunctionName(nameof(GetOccupations))]
        public async Task<IActionResult> GetOccupations(
            [HttpTrigger(AuthorizationLevel.Function, "get")]
            HttpRequest req,
            ILogger log,
            CancellationToken cancellationToken)
        {
            var occupations = await _mediator.Send(new GetOccupationsQuery(), cancellationToken);
            return new OkObjectResult(occupations);
        }
    }
}
