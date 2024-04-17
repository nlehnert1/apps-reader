using GeniusReader.WebApp.Features.Series.Shared;
using MediatR;

namespace GeniusReader.WebApp.Features.Series.Queries.GetSeriesSummary
{
    public class GetSeriesSummariesQuery : IRequest<List<SeriesDto>>
    {
        internal sealed class Handler : IRequestHandler<GetSeriesSummariesQuery, List<SeriesDto>>
        {
            private ReaderContext _readerContext;
            public Handler(ReaderContext readerContext)
            {
                _readerContext = readerContext;
            }

            public Task<List<SeriesDto>> Handle(GetSeriesSummariesQuery request, CancellationToken cancellationToken)
            {
                var series = _readerContext.Series.Select(s => new SeriesDto
                {
                    Title = s.Name,
                    SeriesId = s.SeriesId,
                    Authors = s.Authors.Select(a => new AuthorOfSeriesDto
                    {
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        AuthorId = a.AuthorId,
                    }).ToList(),
                }).ToList();
                return Task.FromResult(series);
            }
        }
    }
}
