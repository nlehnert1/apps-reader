using FluentResults;
using GeniusReader.WebApp.Features.Series.Shared;
using MediatR;
using Sieve.Models;
using Sieve.Services;

namespace GeniusReader.WebApp.Features.Series.Queries.GetBySieve
{
    public class GetSeriesBySieveQuery : SieveModel, IRequest<Result<List<SeriesDto>>>
    {
        internal sealed class Handler : IRequestHandler<GetSeriesBySieveQuery, Result<List<SeriesDto>>>
        {
            private readonly ISieveProcessor _sieveProcessor;
            private readonly ReaderContext _readerContext;

            public Handler(ISieveProcessor sieveProcessor, ReaderContext readerContext)
            {
                _sieveProcessor = sieveProcessor;
                _readerContext = readerContext;
            }

            public async Task<Result<List<SeriesDto>>> Handle(GetSeriesBySieveQuery request, CancellationToken cancellationToken)
            {
                var result = _readerContext.Series.Select(s => new SeriesDto
                {
                    IsOngoing = s.EndDate == null,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    Authors = s.Authors.Select(a => new AuthorOfSeriesDto
                    {
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        AuthorId = a.AuthorId,
                    }).ToList(),
                    SeriesId = s.SeriesId,
                    Title = s.Name,
                    Tags = s.Tags.Select(t => new TagDto
                    {
                        Label = t.Label,
                    }).ToList(),
                    Chapters = s.Chapters.Select(c => new ChapterDto
                    {
                        ChapterId = c.ChapterId,
                        Title = c.ChapterTitle,
                        Tags = c.Tags.Select(t => new TagDto
                        {
                            Label = t.Label
                        }).ToList(),
                    }).ToList(),
                });

                var whatever = _sieveProcessor.Apply(request, result).ToList();
                return await Task.FromResult(Result.Ok(whatever));

            }
        }
    }
}
