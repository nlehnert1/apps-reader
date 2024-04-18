using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusReader.Domain.EFModel
{
    [Table("SeriesChapter", Schema = "dbo")]
    public class SeriesChapter
    {
        public int SeriesId { get; set; }
        public int ChapterId { get; set; }
        public short ChapterOrder {  get; set; }
    }
}
