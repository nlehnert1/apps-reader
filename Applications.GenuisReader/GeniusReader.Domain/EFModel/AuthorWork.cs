using System.ComponentModel.DataAnnotations.Schema;

namespace GeniusReader.Domain.EFModel
{
    [Table("AuthorWorks")]
    public class AuthorWork
    {
        public int AuthorId { get; set; }
        public int SeriesId { get; set; }
    }
}
