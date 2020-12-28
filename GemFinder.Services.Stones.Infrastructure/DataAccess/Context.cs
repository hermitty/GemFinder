using GemFinder.Services.Stones.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GemFinder.Services.Stones.Infrastructure.DataAccess
{
    public class Context : DbContext
    {
        public DbSet<Stone> Stones { get; set; }
        DbSet<Image> Images { get; set; }

        public Context(DbContextOptions<Context> options)
              : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //TODO remove ef core design from api
            builder.Entity<Stone>().ToTable("Image");
            builder.Entity<Stone>().ToTable("Stone").HasMany(c => c.Images);
            builder.Entity<Stone>().HasIndex(x => x.Label);
            //builder.Entity<Vehicle>().ToTable("Vehicle").HasOne(v => v.Owner);
            //builder.Entity<User>().ToTable("User").HasData(
            //    new User() { Id = 1, Login = "admin", Password = "12345", Role = Role.Admin },
            //    new User() { Id = 2, Name = "Worker1", Role = Role.Worker },
            //    new User() { Id = 3, Name = "Worker2", Role = Role.Worker }
            //    );
            //builder.Entity<Job>().ToTable("Job").HasOne(v => v.Assignee);
            //builder.Entity<Job>().ToTable("Job").HasOne(v => v.Vehicle);

            //base.OnModelCreating(builder);
            //modelBuilder.Entity<Car>().ToTable("Car").HasOne(p => p.CarType);
            //modelBuilder.Entity<CarType>().ToTable("CarType").HasData(
            //    new CarType() { Id = 1, Name = "Sedan" },
            //    new CarType() { Id = 2, Name = "Combi" }
            //    );
        }
    }
}
