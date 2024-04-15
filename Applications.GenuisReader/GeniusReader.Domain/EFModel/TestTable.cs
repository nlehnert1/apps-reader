using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GeniusReader.Domain.EFModel
{
    public class TestTable
    {
        [Key]
        public int TestId { get; set; }
        public string? Contents { get; set; }
    }
}
