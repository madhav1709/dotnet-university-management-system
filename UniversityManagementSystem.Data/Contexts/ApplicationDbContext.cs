using Microsoft.EntityFrameworkCore;
using UniversityManagementSystem.Data.Entities;

namespace UniversityManagementSystem.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Campus> Campuses { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseModule> CourseModules { get; set; }

        public DbSet<CourseStudent> CourseStudents { get; set; }

        public DbSet<Enrolment> Enrolments { get; set; }

        public DbSet<Graduation> Graduations { get; set; }

        public DbSet<Hall> Halls { get; set; }

        public DbSet<HallStudent> HallStudents { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<Library> Libraries { get; set; }

        public DbSet<LibraryBook> LibraryBooks { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        public DbSet<Result> Results { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Run> Runs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Composite Primary Keys

            modelBuilder.Entity<CourseModule>()
                .HasKey(courseModule => new {courseModule.CourseId, courseModule.ModuleId});

            modelBuilder.Entity<CourseStudent>()
                .HasKey(courseStudent => new {courseStudent.CourseId, courseStudent.StudentId});

            modelBuilder.Entity<HallStudent>()
                .HasKey(hallStudent => new {hallStudent.HallId, hallStudent.StudentId});

            modelBuilder.Entity<LibraryBook>()
                .HasKey(libraryBook => new {libraryBook.LibraryId, libraryBook.BookId});

            #endregion

            #region Default Values

            modelBuilder.Entity<Rental>()
                .Property(rental => rental.CheckoutDate)
                .HasDefaultValueSql("SYSDATETIMEOFFSET()");

            #endregion
        }
    }
}