using FluentResults;
using GeniusReader.WebApp.Features.Series.Shared;
using MediatR;

namespace GeniusReader.WebApp.Features.Tag.Queries
{
    public class GetAllTagsQuery : IRequest<Result<List<TagDto>>>
    {
        internal sealed class Handler : IRequestHandler<GetAllTagsQuery, Result<List<TagDto>>>
        {
            private readonly ReaderContext _readerContext;
            public Handler(ReaderContext readerContext)
            {
                _readerContext = readerContext;
            }

            public async Task<Result<List<TagDto>>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
            {
                var tags = _readerContext.Tags.Select(t => new TagDto
                {
                    TagId = t.TagId,
                    Label = t.Label,
                    Description = t.Description,
                }).OrderBy(t => t.Label).ToList();
                return await Task.FromResult(Result.Ok(tags));
            }
        }

    }
}
