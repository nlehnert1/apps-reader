namespace GeniusReader.WebApp.Features.Series.Shared
{
    public class SeriesDto
    {
        public int SeriesId { get; set; }
        public string? Title { get; set; }
        public List<AuthorOfSeriesDto> Authors { get; set; } = new List<AuthorOfSeriesDto>();

    }
}
