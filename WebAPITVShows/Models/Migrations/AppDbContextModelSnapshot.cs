﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPITVShows.Models.Data;

#nullable disable

namespace WebAPITVShows.Models.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPITVShows.Models.Entities.TVShow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Favorite")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TVShows");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Favorite = true,
                            Name = "Drake & Josh"
                        },
                        new
                        {
                            Id = 2,
                            Favorite = false,
                            Name = "Dora la exploradora"
                        },
                        new
                        {
                            Id = 3,
                            Favorite = true,
                            Name = "Los Jóvenes titanes"
                        },
                        new
                        {
                            Id = 4,
                            Favorite = true,
                            Name = "Dr House"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
