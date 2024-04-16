using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeniusReader.Domain.EFModel
{
    [Table("Series", Schema = "dbo")]
    public class Series
    {
        public int SeriesId { get; set; }
        public string Name { get; set; }
        public List<Author> Authors { get; set; }
    }
}
