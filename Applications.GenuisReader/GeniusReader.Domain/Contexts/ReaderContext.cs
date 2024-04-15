using GeniusReader.Domain.EFModel;
using Microsoft.EntityFrameworkCore;

public class ReaderContext : DbContext
{

    public ReaderContext(DbContextOptions<ReaderContext> options) : base(options)
    {
    }

    public DbSet<TestTable> TestEntity {  get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestTable>().ToTable("TestTable");
    }

}
