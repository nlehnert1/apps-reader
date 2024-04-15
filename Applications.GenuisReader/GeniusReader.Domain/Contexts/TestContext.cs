using GeniusReader.Domain.EFModel;
using Microsoft.EntityFrameworkCore;

public class TestContext : DbContext
{

    public TestContext(DbContextOptions<TestContext> options) : base(options)
    {
    }

    public DbSet<TestTable> TestEntity {  get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestTable>().ToTable("TestTable");
    }

}
