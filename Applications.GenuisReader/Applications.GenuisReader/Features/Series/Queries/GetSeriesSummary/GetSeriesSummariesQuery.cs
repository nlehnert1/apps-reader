using FluentResults;
using GeniusReader.WebApp.Features.Series.Shared;
using MediatR;

namespace GeniusReader.WebApp.Features.Series.Queries.GetSeriesSummary
{
    public class GetSeriesSummariesQuery : IRequest<Result<List<SeriesDto>>>
    {
        internal sealed class Handler : IRequestHandler<GetSeriesSummariesQuery, Result<List<SeriesDto>>>
        {
            private readonly ReaderContext _readerContext;
            public Handler(ReaderContext readerContext)
            {
                _readerContext = readerContext;
            }

            public async Task<Result<List<SeriesDto>>> Handle(GetSeriesSummariesQuery request, CancellationToken cancellationToken)
            {
                var series = _readerContext.Series.Select(s => new SeriesDto
                {
                    Title = s.Name,
                    SeriesId = s.SeriesId,
                    IsOngoing = s.IsOngoing,
                    Authors = s.Authors.Select(a => new AuthorOfSeriesDto
                    {
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        AuthorId = a.AuthorId,
                    }).ToList(),
                    Tags = s.Tags.Select(t => new TagDto
                    {
                        Label = t.Label,
                    }).ToList(),
                }).ToList();
                return await Task.FromResult(Result.Ok(series));
            }
        }
    }
}
