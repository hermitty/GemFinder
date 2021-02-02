using GemFinder.Identity.Entity;
using Microsoft.EntityFrameworkCore;

namespace GemFinder.Identity.DataAccess
{
    public class Context : DbContext
    {
        public DbSet<User> Stones { get; set; }

        public Context(DbContextOptions<Context> options)
              : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("User");
        }
    }
}
