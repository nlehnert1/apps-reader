using GeniusReader.Domain.EFModel;
using Microsoft.EntityFrameworkCore;

public class TestContext : DbContext
{

    public TestContext(DbContextOptions<TestContext> options) : base(options)
    {
    }

    public DbSet<TestTable> TestEntity { get; set; }
    public DbSet<Author> Author { get; set; }
    public DbSet<Series> Series { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestTable>().ToTable("TestTable");
        modelBuilder.Entity<Author>().HasMany(a => a.Works).WithMany(a => a.Authors)
            .UsingEntity<AuthorWork>();
        modelBuilder.Entity<Series>().HasMany(s => s.Authors).WithMany(s => s.Works)
            .UsingEntity<AuthorWork>();

    }
}
