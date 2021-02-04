using GemFinder.Services.Stones.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GemFinder.Services.Stones.Infrastructure.DataAccess
{
    public class Context : DbContext
    {
        public DbSet<Stone> Stones { get; set; }
        public DbSet<Image> Images { get; set; }

        public Context(DbContextOptions<Context> options)
              : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Stone>().ToTable("Image");
            builder.Entity<Stone>().ToTable("Stone").HasMany(c => c.Images);
            builder.Entity<Stone>().HasIndex(x => x.Label);
        }
    }
}
