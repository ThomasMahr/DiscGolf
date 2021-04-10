﻿// <auto-generated />
using System;
using DiscGolf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiscGolf.Migrations
{
    [DbContext(typeof(DiscGolfContext))]
    [Migration("20210410203240_IDValueReset")]
    partial class IDValueReset
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DiscGolf.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("ZipCode")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseID = 1,
                            CourseName = "Capitol Technology University",
                            ZipCode = 20708
                        },
                        new
                        {
                            CourseID = 2,
                            CourseName = "Turkey Hill Park",
                            ZipCode = 20646
                        });
                });

            modelBuilder.Entity("DiscGolf.Models.GamePlayed", b =>
                {
                    b.Property<int>("GamePlayedID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<bool>("GameFinished")
                        .HasColumnType("bit");

                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("StartedByPlayerID")
                        .HasColumnType("int");

                    b.HasKey("GamePlayedID");

                    b.HasIndex("CourseID");

                    b.HasIndex("PlayerID");

                    b.ToTable("GamesPlayed");

                    b.HasData(
                        new
                        {
                            GamePlayedID = 1,
                            CourseID = 1,
                            GameFinished = true,
                            PlayerID = 2,
                            Score = 26,
                            StartedByPlayerID = 1
                        },
                        new
                        {
                            GamePlayedID = 2,
                            CourseID = 1,
                            GameFinished = true,
                            PlayerID = 2,
                            Score = 31,
                            StartedByPlayerID = 1
                        },
                        new
                        {
                            GamePlayedID = 3,
                            CourseID = 1,
                            GameFinished = true,
                            PlayerID = 3,
                            Score = 29,
                            StartedByPlayerID = 1
                        },
                        new
                        {
                            GamePlayedID = 4,
                            CourseID = 2,
                            GameFinished = true,
                            PlayerID = 3,
                            Score = 62,
                            StartedByPlayerID = 1
                        },
                        new
                        {
                            GamePlayedID = 5,
                            CourseID = 1,
                            GameFinished = true,
                            PlayerID = 4,
                            Score = 26,
                            StartedByPlayerID = 1
                        });
                });

            modelBuilder.Entity("DiscGolf.Models.Hole", b =>
                {
                    b.Property<int>("HoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<double?>("Distance")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<int?>("Par")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("SequenceNumber")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("HoleID");

                    b.HasIndex("CourseID");

                    b.ToTable("Holes");

                    b.HasData(
                        new
                        {
                            HoleID = 1,
                            CourseID = 1,
                            Distance = 317.01999999999998,
                            Par = 3,
                            SequenceNumber = 1
                        },
                        new
                        {
                            HoleID = 2,
                            CourseID = 1,
                            Distance = 305.48000000000002,
                            Par = 3,
                            SequenceNumber = 2
                        },
                        new
                        {
                            HoleID = 3,
                            CourseID = 1,
                            Distance = 297.37,
                            Par = 3,
                            SequenceNumber = 3
                        },
                        new
                        {
                            HoleID = 4,
                            CourseID = 1,
                            Distance = 188.97,
                            Par = 3,
                            SequenceNumber = 4
                        },
                        new
                        {
                            HoleID = 5,
                            CourseID = 1,
                            Distance = 253.03999999999999,
                            Par = 2,
                            SequenceNumber = 5
                        },
                        new
                        {
                            HoleID = 6,
                            CourseID = 1,
                            Distance = 360.47000000000003,
                            Par = 4,
                            SequenceNumber = 6
                        },
                        new
                        {
                            HoleID = 7,
                            CourseID = 1,
                            Distance = 172.59,
                            Par = 3,
                            SequenceNumber = 7
                        },
                        new
                        {
                            HoleID = 8,
                            CourseID = 1,
                            Distance = 348.94,
                            Par = 4,
                            SequenceNumber = 8
                        },
                        new
                        {
                            HoleID = 9,
                            CourseID = 1,
                            Distance = 186.06,
                            Par = 3,
                            SequenceNumber = 9
                        },
                        new
                        {
                            HoleID = 10,
                            CourseID = 2,
                            Distance = 285.0,
                            Par = 3,
                            SequenceNumber = 1
                        },
                        new
                        {
                            HoleID = 11,
                            CourseID = 2,
                            Distance = 246.0,
                            Par = 3,
                            SequenceNumber = 2
                        },
                        new
                        {
                            HoleID = 12,
                            CourseID = 2,
                            Distance = 266.0,
                            Par = 3,
                            SequenceNumber = 3
                        },
                        new
                        {
                            HoleID = 13,
                            CourseID = 2,
                            Distance = 154.0,
                            Par = 3,
                            SequenceNumber = 4
                        },
                        new
                        {
                            HoleID = 14,
                            CourseID = 2,
                            Distance = 203.0,
                            Par = 3,
                            SequenceNumber = 5
                        },
                        new
                        {
                            HoleID = 15,
                            CourseID = 2,
                            Distance = 262.0,
                            Par = 3,
                            SequenceNumber = 6
                        },
                        new
                        {
                            HoleID = 16,
                            CourseID = 2,
                            Distance = 213.0,
                            Par = 3,
                            SequenceNumber = 7
                        },
                        new
                        {
                            HoleID = 17,
                            CourseID = 2,
                            Distance = 420.0,
                            Par = 4,
                            SequenceNumber = 8
                        },
                        new
                        {
                            HoleID = 18,
                            CourseID = 2,
                            Distance = 256.0,
                            Par = 3,
                            SequenceNumber = 9
                        },
                        new
                        {
                            HoleID = 19,
                            CourseID = 2,
                            Distance = 164.0,
                            Par = 3,
                            SequenceNumber = 10
                        },
                        new
                        {
                            HoleID = 20,
                            CourseID = 2,
                            Distance = 141.0,
                            Par = 3,
                            SequenceNumber = 11
                        },
                        new
                        {
                            HoleID = 21,
                            CourseID = 2,
                            Distance = 141.0,
                            Par = 3,
                            SequenceNumber = 12
                        },
                        new
                        {
                            HoleID = 22,
                            CourseID = 2,
                            Distance = 266.0,
                            Par = 3,
                            SequenceNumber = 13
                        },
                        new
                        {
                            HoleID = 23,
                            CourseID = 2,
                            Distance = 203.0,
                            Par = 3,
                            SequenceNumber = 14
                        },
                        new
                        {
                            HoleID = 24,
                            CourseID = 2,
                            Distance = 246.0,
                            Par = 3,
                            SequenceNumber = 15
                        },
                        new
                        {
                            HoleID = 25,
                            CourseID = 2,
                            Distance = 226.0,
                            Par = 3,
                            SequenceNumber = 16
                        },
                        new
                        {
                            HoleID = 26,
                            CourseID = 2,
                            Distance = 417.0,
                            Par = 4,
                            SequenceNumber = 17
                        },
                        new
                        {
                            HoleID = 27,
                            CourseID = 2,
                            Distance = 269.0,
                            Par = 3,
                            SequenceNumber = 18
                        });
                });

            modelBuilder.Entity("DiscGolf.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("PlayerID");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            PlayerID = 1,
                            Name = "Admin",
                            Password = "DiscGolf",
                            Username = "Admin"
                        },
                        new
                        {
                            PlayerID = 2,
                            Name = "Ichabod Fletchman",
                            Password = "Password",
                            Username = "IFletchman"
                        },
                        new
                        {
                            PlayerID = 3,
                            Name = "Jimmy Craig",
                            Password = "Hockey",
                            Username = "JCraig"
                        },
                        new
                        {
                            PlayerID = 4,
                            Name = "Kerri Strug",
                            Password = "Vault",
                            Username = "KStrug"
                        },
                        new
                        {
                            PlayerID = 5,
                            Name = "Jesse Owens",
                            Password = "Track",
                            Username = "JOwens"
                        });
                });

            modelBuilder.Entity("DiscGolf.Models.GamePlayed", b =>
                {
                    b.HasOne("DiscGolf.Models.Course", "Course")
                        .WithMany("GamesPlayed")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiscGolf.Models.Player", "Player")
                        .WithMany("GamesPlayed")
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("DiscGolf.Models.Hole", b =>
                {
                    b.HasOne("DiscGolf.Models.Course", "Course")
                        .WithMany("Holes")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("DiscGolf.Models.Course", b =>
                {
                    b.Navigation("GamesPlayed");

                    b.Navigation("Holes");
                });

            modelBuilder.Entity("DiscGolf.Models.Player", b =>
                {
                    b.Navigation("GamesPlayed");
                });
#pragma warning restore 612, 618
        }
    }
}
