using GemFinder.Services.Stores.Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace GemFinder.Services.Stores.Infrastructure.DataAccess
{
    public class Context : DbContext
    {
        public DbSet<Store> Stores { get; set; }

        public Context(DbContextOptions<Context> options)
              : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Opinion>().ToTable("Opinion");
            //builder.Entity<Stone>().ToTable("Stone");
            builder.Entity<StoreStone>().ToTable("StoreStone");
            builder.Entity<Reference>().ToTable("Reference");
            builder.Entity<StoreImage>().ToTable("StoreImage");

            builder.Entity<Store>().ToTable("Store");
            builder.Entity<Store>().HasMany(x => x.Opinions);
            builder.Entity<Store>().HasMany(x => x.StoreStones);
            builder.Entity<Store>().HasMany(x => x.References);
            builder.Entity<Store>().HasMany(x => x.StoreImages);
        }
    }
}
