using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace GeniusReader.WebApp.Features.Series.Commands.DeleteSeries
{
    public class DeleteSeriesCommand : IRequest<Result>
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }

        internal sealed class Handler : IRequestHandler<DeleteSeriesCommand, Result>
        {
            private readonly ReaderContext _readerContext;

            public Handler(ReaderContext readerContext)
            {
                _readerContext = readerContext;
            }

            public async Task<Result> Handle(DeleteSeriesCommand request, CancellationToken cancellationToken)
            {
                var series = await _readerContext.Series.FirstOrDefaultAsync(x => x.SeriesId == request.Id);
                if (series == null)
                {
                    return Result.Fail($"No series found with id {request.Id}");
                }

                // If series found, need to delete tags for chapters in that series, if any
                // The below logic is faulty, since it will lead to deleting a chapterTag for a chapter that is shared between two series. Need to update this
                //var seriesChapters = _readerContext.Chapters.Where(c => c.Series.Any(s => s.SeriesId == request.Id)).ToList().ConvertAll(chap => chap.ChapterId);
                //await _readerContext.ChapterTags.Where(ct => seriesChapters.Contains(ct.ChapterId)).DeleteAsync(cancellationToken);

                // Then delete chapters for the series. THIS IS ALSO FAULTY, AND WILL DELETE CHAPTERS THAT ARE SHARED BETWEEN SERIES.
                //await _readerContext.Chapters.Where(c => c.Series.Any(s => s.SeriesId == series.SeriesId)).DeleteAsync();
                
                // Then delete SeriesTags entries for the series

                // Then delete AuthorWorks entries so author is no longer associated with series

                // Then delete the series, and save changes!

                //_readerContext.SaveChanges();

                return Result.Ok();
            }
        }
    }
}
