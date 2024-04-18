using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusReader.Domain.EFModel
{
    [Table("Chapter", Schema = "dbo")]
    public class Chapter
    {
        public int ChapterId { get; set; }
        public string ChapterTitle { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Series> Series { get; set; }
    }
}
