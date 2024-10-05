using Sieve.Attributes;

namespace GeniusReader.WebApp.Features.Series.Shared
{
    public class SeriesDto
    {
        [Sieve(CanFilter = true)]
        public int SeriesId { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public string Title { get; set; }
        public List<AuthorOfSeriesDto> Authors { get; set; } = new List<AuthorOfSeriesDto>();
        [Sieve(CanFilter = true)]
        public List<TagDto> Tags { get; set; }
        public bool IsOngoing { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<ChapterDto> Chapters { get; set; } = new List<ChapterDto>();
    }
}
