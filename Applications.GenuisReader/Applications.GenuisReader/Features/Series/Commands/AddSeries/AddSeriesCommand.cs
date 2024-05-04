using FluentResults;
using GeniusReader.WebApp.Features.Series.Shared;
using MediatR;

namespace GeniusReader.WebApp.Features.Series.Commands.AddSeries
{
    public class AddSeriesCommand : IRequest<Result<SeriesDto>>
    {
        public AddSeriesCommand() { }
    }
}
