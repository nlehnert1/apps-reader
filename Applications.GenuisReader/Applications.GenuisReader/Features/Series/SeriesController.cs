using FluentResults;
using FluentResults.Extensions.AspNetCore;
using GeniusReader.WebApp.Features.Series.Queries.GetSeriesDetails;
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
        private readonly IMediator _mediator;

        public SeriesController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("Summaries")]
        public async Task<ActionResult<List<SeriesDto>>> GetSeriesSummaries([FromQuery] GetSeriesSummariesQuery request)
            => await _mediator.Send(request).ToActionResult();

        [HttpGet("Details/{SeriesId}")]
        public async Task<ActionResult<SeriesDto>> GetSeriesDetails([FromRoute] GetSeriesDetailsQuery request)
           => await _mediator.Send(request).ToActionResult();
    }
}
