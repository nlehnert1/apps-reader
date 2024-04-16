using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeniusReader.Domain.EFModel
{
    [Table("Author", Schema = "dbo")]
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Series> Works { get; set; }
    }
}
