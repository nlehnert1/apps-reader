namespace GeniusReader.WebApp.Features.Series.Shared
{
    public class SeriesDto
    {
        public int SeriesId { get; set; }
        public string? Title { get; set; }
        public List<AuthorOfSeriesDto> Authors { get; set; } = new List<AuthorOfSeriesDto>();

        public bool IsOngoing { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
