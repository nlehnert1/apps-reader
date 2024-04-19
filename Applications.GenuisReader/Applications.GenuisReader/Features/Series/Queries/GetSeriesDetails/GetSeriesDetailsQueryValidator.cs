using FluentValidation;

namespace GeniusReader.WebApp.Features.Series.Queries.GetSeriesDetails
{
    public class GetSeriesDetailsQueryValidator : AbstractValidator<GetSeriesDetailsQuery>
    {
        public GetSeriesDetailsQueryValidator()
        {
            RuleFor(seriesDetailQuery => seriesDetailQuery.SeriesId).GreaterThanOrEqualTo(1);
        }
    }
}
