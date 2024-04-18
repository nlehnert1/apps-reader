namespace GeniusReader.WebApp.Features.Series.Shared
{
    public class SeriesDto
    {
        public int SeriesId { get; set; }
        public string? Title { get; set; }
        public List<AuthorOfSeriesDto> Authors { get; set; } = new List<AuthorOfSeriesDto>();
        public List<TagDto> Tags { get; set; }
        public bool IsOngoing { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<ChapterDto> Chapters { get; set; } = new List<ChapterDto>();
    }
}
