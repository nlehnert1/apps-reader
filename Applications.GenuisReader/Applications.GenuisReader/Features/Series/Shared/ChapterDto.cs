namespace GeniusReader.WebApp.Features.Series.Shared
{
    public class ChapterDto
    {
        public int ChapterId { get; set; }
        public string Title {  get; set; }
        public List<TagDto> Tags { get; set; }
    }
}
