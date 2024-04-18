﻿using GeniusReader.WebApp.Features.Series.Queries.GetSeriesSummary;
using GeniusReader.WebApp.Features.Series.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GeniusReader.WebApp.Features.Series.Queries.GetSeriesDetails
{
    public class GetSeriesDetailsQuery : IRequest<SeriesDto?>
    {
        [FromRoute(Name = "SeriesId")]
        public int SeriesId { get; set; }

        internal sealed class Handler : IRequestHandler<GetSeriesDetailsQuery, SeriesDto?>
        {
            private ReaderContext _readerContext;
            public Handler(ReaderContext readerContext)
            {
                _readerContext = readerContext;
            }
            public Task<SeriesDto?> Handle(GetSeriesDetailsQuery request, CancellationToken cancellationToken)
            {
                var result = _readerContext.Series.Select(s => new SeriesDto
                {
                    IsOngoing = s.IsOngoing,
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
                        Tags = c.Tags.Select(t => new TagDto {
                            Label = t.Label
                        }).ToList(),
                    }).ToList(),
                }).Where(s => s.SeriesId == request.SeriesId).FirstOrDefault();

                return Task.FromResult(result);
            }
        }
    }
}
