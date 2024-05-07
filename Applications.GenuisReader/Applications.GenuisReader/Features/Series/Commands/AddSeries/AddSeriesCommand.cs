using FluentResults;
using GeniusReader.Domain.EFModel;
using GeniusReader.WebApp.Features.Series.Shared;
using MediatR;
using SeriesEntity = GeniusReader.Domain.EFModel.Series;

namespace GeniusReader.WebApp.Features.Series.Commands.AddSeries
{
    public class AddSeriesCommand : IRequest<Result<SeriesDto>>
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<TagDto> Tags { get; set; }
        public List<AuthorOfSeriesDto> Authors { get; set; }

        internal sealed class Handler : IRequestHandler<AddSeriesCommand, Result<SeriesDto>>
        {
            private readonly ReaderContext _readerContext;
            public Handler(ReaderContext readerContext)
            {
                _readerContext = readerContext;
            }

            public async Task<Result<SeriesDto>> Handle(AddSeriesCommand request, CancellationToken cancellationToken)
            {
                // Check if series already exists, return error if so
                var seriesExists = _readerContext.Series.FirstOrDefault(s => s.Name == request.Title) != null;
                if(seriesExists)
                {
                    var resultObj = Result.Fail($"Series with title {request.Title} already exists");
                    return await Task.FromResult(resultObj);
                }

                // Make new series (set Title, StartDate, and EndDate)
                var newSeries = this.CreateSeries(request);

                // Create SeriesTags records
                this.AddTagsToSeries(request.Tags, newSeries.SeriesId);

                // Check if need to make new author and make new AuthorSeries record(s)
                var author = this.GetOrCreateAuthor(request.Authors[0], newSeries.SeriesId);
                this.AddSeriesToAuthor(author, newSeries.SeriesId);

                var seriesToReturn = _readerContext.Series.Select(s => new SeriesDto
                {
                    SeriesId = s.SeriesId,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    Title = s.Name,
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
                    IsOngoing = s.EndDate == null,
                }).FirstOrDefault(s => s.SeriesId == newSeries.SeriesId);
                return await Task.FromResult(Result.Ok(seriesToReturn));
            }

            private Author GetOrCreateAuthor(AuthorOfSeriesDto author, int seriesId)
            {
                Author authorToReturn = null;
                if (author.FirstName == null)
                {
                    authorToReturn = _readerContext.Authors.FirstOrDefault(a => a.LastName == author.LastName && a.FirstName == null);
                }
                else
                {
                    authorToReturn = _readerContext.Authors.FirstOrDefault(a => a.LastName == author.LastName && a.FirstName == author.FirstName);
                }
                if(authorToReturn == null)
                {
                    authorToReturn = new Author
                    {
                        FirstName = author.FirstName,
                        LastName = author.LastName,
                    };
                    _readerContext.Authors.Add(authorToReturn);
                    _readerContext.SaveChanges();
                }
                return authorToReturn;
            }

            private SeriesEntity CreateSeries(AddSeriesCommand request)
            {
                var newSeries = new SeriesEntity
                {
                    Name = request.Title,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                };

                _readerContext.Series.Add(newSeries);
                _readerContext.SaveChanges();
                return newSeries;
            }

            private void AddTagsToSeries(List<TagDto> tags, int seriesId)
            {
                foreach (var tag in tags)
                {
                    var tagEntity = _readerContext.Tags.First(t => t.Label == tag.Label);
                    var seriesTag = new SeriesTag
                    {
                        SeriesId = seriesId,
                        TagId = tagEntity.TagId,
                    };
                    _readerContext.Add(seriesTag);
                }
                _readerContext.SaveChanges();
            }

            private void AddSeriesToAuthor(Author author, int seriesId)
            {
                var seriesAuthor = new AuthorWork
                {
                    AuthorId = author.AuthorId,
                    SeriesId = seriesId,
                };
                _readerContext.Add(seriesAuthor);
                _readerContext.SaveChanges();
            }
        }
    }
}
