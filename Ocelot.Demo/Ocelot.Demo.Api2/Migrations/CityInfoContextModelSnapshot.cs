﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ocelot.Demo.Api2.DB_Context;

#nullable disable

namespace Ocelot.Demo.Api2.Migrations
{
    [DbContext(typeof(CityInfoContext))]
    partial class CityInfoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ocelot.Demo.Api2.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "City known for CN Tower",
                            Name = "Toronto"
                        },
                        new
                        {
                            Id = 2,
                            Description = "City known for Bollywood",
                            Name = "Mumbai"
                        },
                        new
                        {
                            Id = 3,
                            Description = "City known for rich culture and diversity",
                            Name = "Delhi"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Fashion and Financial capital",
                            Name = "New York"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Fashion capital",
                            Name = "Paris"
                        });
                });

            modelBuilder.Entity("Ocelot.Demo.Api2.Entities.PointOfInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PointOfInterests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Description = "An incredible tower",
                            Name = "CN Tower"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Description = "A city surrounded by the lake",
                            Name = "Lake Ontario"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 2,
                            Description = "An iconic hotel and pride of India",
                            Name = "Taj Hotel"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 3,
                            Description = "A historic monument",
                            Name = "Qutub Minar"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 4,
                            Description = "Iconic towers to replace twin towers",
                            Name = "One World"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 4,
                            Description = "An extraordinary Art Museum",
                            Name = "Guggenheim Museum"
                        },
                        new
                        {
                            Id = 7,
                            CityId = 5,
                            Description = "An iconic French tower",
                            Name = "Eifel Tower"
                        },
                        new
                        {
                            Id = 8,
                            CityId = 5,
                            Description = "Attest the greatness of many civilizations",
                            Name = "The Louvre"
                        });
                });

            modelBuilder.Entity("Ocelot.Demo.Api2.Entities.PointOfInterest", b =>
                {
                    b.HasOne("Ocelot.Demo.Api2.Entities.City", "City")
                        .WithMany("PointsOfInterest")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Ocelot.Demo.Api2.Entities.City", b =>
                {
                    b.Navigation("PointsOfInterest");
                });
#pragma warning restore 612, 618
        }
    }
}
