using GeniusReader.WebApp.Features.Series.Queries.GetSeriesSummary;
using GeniusReader.WebApp.Features.Series.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GeniusReader.WebApp.Features.Series
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeriesController : ControllerBase
    {
        private IMediator _mediator;

        public SeriesController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("Summaries")]
        public async Task<List<SeriesDto>> GetSeriesSummaries([FromQuery] GetSeriesSummariesQuery request)
            => await _mediator.Send(request);

    }
}
