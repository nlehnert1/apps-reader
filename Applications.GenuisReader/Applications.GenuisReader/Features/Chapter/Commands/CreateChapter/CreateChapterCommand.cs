using FluentResults;
using GeniusReader.WebApp.Features.Chapter.Shared;
using MediatR;

namespace GeniusReader.WebApp.Features.Chapter.Commands.CreateChapter
{
    public class CreateChapterCommand : IRequest<Result<AddChapterDto>>
    {
        public string Title { get; set; }
        //public int? SeriesId
    }
}
