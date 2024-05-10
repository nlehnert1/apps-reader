using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusReader.Domain.EFModel
{
    [Table("ChapterTag", Schema = "dbo")]
    public class ChapterTag
    {
        public int ChapterId { get; set; }
        public int TagId { get; set; }
    }
}
