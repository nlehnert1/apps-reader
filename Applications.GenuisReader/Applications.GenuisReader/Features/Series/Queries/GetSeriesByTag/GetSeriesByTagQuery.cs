using Microsoft.AspNetCore.Mvc;

namespace GeniusReader.WebApp.Features.Series.Queries.GetSeriesByTag
{
    public class GetSeriesByTagQuery
    {
        [FromRoute(Name = "TagId")]
        public int TagId { get; set; }
    }
}
