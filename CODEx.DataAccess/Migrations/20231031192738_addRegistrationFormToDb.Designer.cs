﻿// <auto-generated />
using System;
using CODEx.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CODEx.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231031192738_addRegistrationFormToDb")]
    partial class addRegistrationFormToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-rc.2.23480.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CODEx.Model.Coordinator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Batch")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Coordinator");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Batch = "2021-2025",
                            Description = "This was a Technical Event",
                            Designation = "President",
                            Name = "Da-Vinci Code 3.0"
                        },
                        new
                        {
                            Id = 2,
                            Batch = "2021-2025",
                            Description = "This was a Technical Event",
                            Designation = "Vice-President",
                            Name = "X-QuizIT 3.0"
                        },
                        new
                        {
                            Id = 3,
                            Batch = "2021-2025",
                            Description = "This was a Technical Event",
                            Designation = "Secretary",
                            Name = "Edge Map "
                        },
                        new
                        {
                            Id = 4,
                            Batch = "2021-2025",
                            Description = "This was a Technical Event",
                            Designation = "Vice-Secretary",
                            Name = "TechNode"
                        });
                });

            modelBuilder.Entity("CODEx.Model.Events", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacebookUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Glimpse1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstagramPostUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkdinUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosterUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalParticipant")
                        .HasColumnType("int");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Event");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateOnly(1, 1, 1),
                            Description = "This was a Technical Event",
                            Name = "Da-Vinci Code 3.0",
                            TotalParticipant = 70
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateOnly(1, 1, 1),
                            Description = "This was a Technical Event",
                            Name = "X-QuizIT 3.0",
                            TotalParticipant = 90
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateOnly(1, 1, 1),
                            Description = "This was a Technical Event",
                            Name = "Edge Map ",
                            TotalParticipant = 60
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateOnly(1, 1, 1),
                            Description = "This was a Technical Event",
                            Name = "TechNode",
                            TotalParticipant = 120
                        });
                });

            modelBuilder.Entity("CODEx.Model.RegistrationForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("College")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeaderEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeaderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Member2Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Member2Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Member3Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Member3Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Member4Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Member4Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProblemStatment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamLeaderNanme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Theme")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RegistrationForm");
                });
#pragma warning restore 612, 618
        }
    }
}
