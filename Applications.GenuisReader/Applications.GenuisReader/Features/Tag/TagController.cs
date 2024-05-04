using FluentResults.Extensions.AspNetCore;
using GeniusReader.WebApp.Features.Series.Shared;
using GeniusReader.WebApp.Features.Tag.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GeniusReader.WebApp.Features.Tag
{
    [ApiController]
    [Route("api/[controller]s")]
    public class TagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<TagDto>>> GetAllTags([FromQuery] GetAllTagsQuery request)
            => await _mediator.Send(request).ToActionResult();
    }
}
