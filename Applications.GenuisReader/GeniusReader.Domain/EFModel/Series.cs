using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeniusReader.Domain.EFModel
{
    [Table("Series", Schema = "dbo")]
    public class Series
    {
        public int SeriesId { get; set; }
        public string Name { get; set; }
        public bool IsOngoing { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<Author> Authors { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Chapter> Chapters { get; set; }
    }
}
