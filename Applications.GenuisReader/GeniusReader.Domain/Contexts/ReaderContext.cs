using GeniusReader.Domain.EFModel;
using Microsoft.EntityFrameworkCore;

public class ReaderContext : DbContext
{

    public ReaderContext(DbContextOptions<ReaderContext> options) : base(options)
    {
    }

    public DbSet<TestTable> TestEntity { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Series> Series { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestTable>().ToTable("TestTable");

        // Configure Author <-> Series M2M
        modelBuilder.Entity<Author>().HasMany(a => a.Works).WithMany(s => s.Authors)
            .UsingEntity<AuthorWork>();
        modelBuilder.Entity<Series>().HasMany(s => s.Authors).WithMany(a => a.Works)
            .UsingEntity<AuthorWork>();

        // Configure Series <-> Tag M2M
        modelBuilder.Entity<Series>().HasMany(s => s.Tags).WithMany(t => t.SeriesTagIsUsedIn)
            .UsingEntity<SeriesTag>();
        modelBuilder.Entity<Tag>().HasMany(t => t.SeriesTagIsUsedIn).WithMany(s => s.Tags)
            .UsingEntity<SeriesTag>();

        // Configure Chapter <-> Tag M2M
        modelBuilder.Entity<Chapter>().HasMany(c => c.Tags).WithMany(t => t.ChaptersTagIsUsedIn)
            .UsingEntity<ChapterTag>();
        modelBuilder.Entity<Tag>().HasMany(t => t.ChaptersTagIsUsedIn).WithMany(c => c.Tags)
            .UsingEntity<ChapterTag>();

        // Configure Series <-> Chapter M2M (really only comes up in crossover chapters)
        modelBuilder.Entity<Chapter>().HasMany(c => c.Series).WithMany(s => s.Chapters)
            .UsingEntity<SeriesChapter>();
        modelBuilder.Entity<Series>().HasMany(s => s.Chapters).WithMany(c => c.Series)
            .UsingEntity<SeriesChapter>();
    }
}
