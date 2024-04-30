using GeniusReader.WebApp.Features.Chapter.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GeniusReader.WebApp.Features.Chapter
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChapterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChapterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost]
        //public async Task<ActionResult<AddChapterDto>> AddNewChapter([FromBody] CreateChapterCommand request)
        //    => await _mediator.Send(request);
    }
}
