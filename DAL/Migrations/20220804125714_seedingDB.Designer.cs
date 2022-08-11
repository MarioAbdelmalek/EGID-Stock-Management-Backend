﻿// <auto-generated />
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DAL.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    [Migration("20220804125714_seedingDB")]
    partial class seedingDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DAL.Models.Broker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Brokers");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Marwan"
                        },
                        new
                        {
                            ID = 2,
                            Name = "George"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Youssef"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Nadim"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Begad"
                        });
                });

            modelBuilder.Entity("DAL.Models.Order", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BrokerID")
                        .HasColumnType("integer");

                    b.Property<int>("ClientID")
                        .HasColumnType("integer");

                    b.Property<double>("Commission")
                        .HasColumnType("double precision");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("StockID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DAL.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BrokerID")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            BrokerID = 2,
                            Name = "Mario"
                        },
                        new
                        {
                            ID = 2,
                            BrokerID = 2,
                            Name = "Mark"
                        },
                        new
                        {
                            ID = 3,
                            BrokerID = 4,
                            Name = "Ali"
                        },
                        new
                        {
                            ID = 4,
                            BrokerID = 3,
                            Name = "Fady"
                        },
                        new
                        {
                            ID = 5,
                            BrokerID = 3,
                            Name = "Tarek"
                        });
                });

            modelBuilder.Entity("DAL.Models.Stock", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("ID");

                    b.ToTable("Stocks");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "APPL",
                            Price = 1000.0
                        },
                        new
                        {
                            ID = 2,
                            Name = "BAC",
                            Price = 2000.0
                        },
                        new
                        {
                            ID = 3,
                            Name = "ROCK",
                            Price = 3000.0
                        },
                        new
                        {
                            ID = 4,
                            Name = "FUN",
                            Price = 4000.0
                        },
                        new
                        {
                            ID = 5,
                            Name = "AVCTW",
                            Price = 5000.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
