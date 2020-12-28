﻿// <auto-generated />
using System;
using GemFinder.Services.Stones.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GemFinder.Services.Stones.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201228173003_index")]
    partial class index
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("GemFinder.Services.Stones.Core.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StoneId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StoneId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("GemFinder.Services.Stones.Core.Entities.Stone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Label");

                    b.ToTable("Stone");
                });

            modelBuilder.Entity("GemFinder.Services.Stones.Core.Entities.Image", b =>
                {
                    b.HasOne("GemFinder.Services.Stones.Core.Entities.Stone", null)
                        .WithMany("Images")
                        .HasForeignKey("StoneId");
                });

            modelBuilder.Entity("GemFinder.Services.Stones.Core.Entities.Stone", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
