using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeniusReader.Domain.EFModel
{
    [Table("SeriesTag")]
    public class SeriesTag
    {
        public int SeriesId { get; set; }
        public int TagId { get; set; }
    }
}
