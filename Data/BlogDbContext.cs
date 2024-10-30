using Microsoft.EntityFrameworkCore;
using BlogAPI.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlogAPI.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

    public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Author).IsRequired();
                entity.Property(e => e.Content).IsRequired().HasMaxLength(100);

                entity.Property(e => e.Tags)
                    .HasConversion(
                        v => v == null ? null: string.Join(',', v),
                        v => v == null ? new List<string>() : v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                    )
                    .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                        (c1, c2) => (c1 == null && c2 == null) || (c1 != null && c2 != null && c1.SequenceEqual(c2)),
                        c => c == null ? 0 : c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c == null ? new List<string>() : c.ToList()));
            });
        }
    }
}