namespace GeniusReader.WebApp.Features.Series.Shared
{
    public class TagDto
    {
        public int TagId { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public bool IsSensitive { get; set; }
    }
}
