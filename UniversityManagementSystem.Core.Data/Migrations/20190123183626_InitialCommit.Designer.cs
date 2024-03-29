﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityManagementSystem.Core.Data.Contexts;

namespace UniversityManagementSystem.Core.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190123183626_InitialCommit")]
    partial class InitialCommit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview.18572.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("Deadline");

                    b.Property<string>("Details");

                    b.Property<int>("RunId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("RunId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Campus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Campuses");
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CampusId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CampusId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.CourseModule", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("ModuleId");

                    b.HasKey("CourseId", "ModuleId");

                    b.HasIndex("ModuleId");

                    b.ToTable("CourseModules");
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.CourseStudent", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<string>("StudentId");

                    b.HasKey("CourseId", "StudentId");

                    b.ToTable("CourseStudents");
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Enrolment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RunId");

                    b.Property<string>("StudentId");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("RunId");

                    b.ToTable("Enrolments");
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Graduation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<string>("StudentId");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Graduations");
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Hall", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CampusId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CampusId");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.HallStudent", b =>
                {
                    b.Property<int>("HallId");

                    b.Property<string>("StudentId");

                    b.HasKey("HallId", "StudentId");

                    b.ToTable("HallStudents");
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("DateTime");

                    b.Property<TimeSpan>("Duration");

                    b.Property<int>("RoomId");

                    b.Property<int>("RunId");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("RunId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CampusId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CampusId");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.LibraryBook", b =>
                {
                    b.Property<int>("LibraryId");

                    b.Property<int>("BookId");

                    b.HasKey("LibraryId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("LibraryBooks");
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<DateTimeOffset>("CheckoutDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("SYSDATETIMEOFFSET()");

                    b.Property<DateTimeOffset>("ReturnDate");

                    b.Property<string>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignmentId");

                    b.Property<string>("Feedback");

                    b.Property<int>("Grade");

                    b.Property<string>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CampusId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CampusId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Run", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ModuleId");

                    b.Property<string>("Semester");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Runs");
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Assignment", b =>
                {
                    b.HasOne("UniversityManagementSystem.Core.Data.Entities.Run", "Run")
                        .WithMany("Assignments")
                        .HasForeignKey("RunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Course", b =>
                {
                    b.HasOne("UniversityManagementSystem.Core.Data.Entities.Campus", "Campus")
                        .WithMany("Courses")
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.CourseModule", b =>
                {
                    b.HasOne("UniversityManagementSystem.Core.Data.Entities.Course", "Course")
                        .WithMany("CourseModules")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UniversityManagementSystem.Core.Data.Entities.Module", "Module")
                        .WithMany("CourseModules")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.CourseStudent", b =>
                {
                    b.HasOne("UniversityManagementSystem.Core.Data.Entities.Course", "Course")
                        .WithMany("CourseStudents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Enrolment", b =>
                {
                    b.HasOne("UniversityManagementSystem.Core.Data.Entities.Run", "Run")
                        .WithMany("Enrolments")
                        .HasForeignKey("RunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Graduation", b =>
                {
                    b.HasOne("UniversityManagementSystem.Core.Data.Entities.Course", "Course")
                        .WithMany("Graduations")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Hall", b =>
                {
                    b.HasOne("UniversityManagementSystem.Core.Data.Entities.Campus", "Campus")
                        .WithMany("Halls")
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.HallStudent", b =>
                {
                    b.HasOne("UniversityManagementSystem.Core.Data.Entities.Hall", "Hall")
                        .WithMany("HallStudents")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Lecture", b =>
                {
                    b.HasOne("UniversityManagementSystem.Core.Data.Entities.Room", "Room")
                        .WithMany("Lectures")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UniversityManagementSystem.Core.Data.Entities.Run", "Run")
                        .WithMany("Lectures")
                        .HasForeignKey("RunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Library", b =>
                {
                    b.HasOne("UniversityManagementSystem.Core.Data.Entities.Campus", "Campus")
                        .WithMany("Libraries")
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.LibraryBook", b =>
                {
                    b.HasOne("UniversityManagementSystem.Core.Data.Entities.Book", "Book")
                        .WithMany("LibraryBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("UniversityManagementSystem.Core.Data.Entities.Library", "Library")
                        .WithMany("LibraryBooks")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Rental", b =>
                {
                    b.HasOne("UniversityManagementSystem.Core.Data.Entities.Book", "Book")
                        .WithMany("Rentals")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Result", b =>
                {
                    b.HasOne("UniversityManagementSystem.Core.Data.Entities.Assignment", "Assignment")
                        .WithMany("Results")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Room", b =>
                {
                    b.HasOne("UniversityManagementSystem.Core.Data.Entities.Campus", "Campus")
                        .WithMany("Rooms")
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UniversityManagementSystem.Core.Data.Entities.Run", b =>
                {
                    b.HasOne("UniversityManagementSystem.Core.Data.Entities.Module", "Module")
                        .WithMany("Runs")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
