using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusReader.Domain.EFModel
{
    [Table("Tag", Schema = "dbo")]
    public class Tag
    {
        public int TagId { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public bool? IsSensitive { get; set; }
        public List<Chapter> ChaptersTagIsUsedIn { get; set; }
        public List<Series> SeriesTagIsUsedIn { get; set; }
    }
}
