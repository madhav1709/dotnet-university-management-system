using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManagementSystem.Data.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Books",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Books", x => x.Id); });

            migrationBuilder.CreateTable(
                "Campuses",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Campuses", x => x.Id); });

            migrationBuilder.CreateTable(
                "Modules",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Modules", x => x.Id); });

            migrationBuilder.CreateTable(
                "Rentals",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckoutDate =
                        table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    ReturnDate = table.Column<DateTimeOffset>(nullable: false),
                    StudentId = table.Column<string>(nullable: true),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        "FK_Rentals_Books_BookId",
                        x => x.BookId,
                        "Books",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Courses",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CampusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        "FK_Courses_Campuses_CampusId",
                        x => x.CampusId,
                        "Campuses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Halls",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CampusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.Id);
                    table.ForeignKey(
                        "FK_Halls_Campuses_CampusId",
                        x => x.CampusId,
                        "Campuses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Libraries",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CampusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                    table.ForeignKey(
                        "FK_Libraries_Campuses_CampusId",
                        x => x.CampusId,
                        "Campuses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Rooms",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CampusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        "FK_Rooms_Campuses_CampusId",
                        x => x.CampusId,
                        "Campuses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Runs",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(nullable: false),
                    Semester = table.Column<string>(nullable: true),
                    ModuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runs", x => x.Id);
                    table.ForeignKey(
                        "FK_Runs_Modules_ModuleId",
                        x => x.ModuleId,
                        "Modules",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "CourseModules",
                table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseModules", x => new {x.CourseId, x.ModuleId});
                    table.ForeignKey(
                        "FK_CourseModules_Courses_CourseId",
                        x => x.CourseId,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CourseModules_Modules_ModuleId",
                        x => x.ModuleId,
                        "Modules",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "CourseStudents",
                table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudents", x => new {x.CourseId, x.StudentId});
                    table.ForeignKey(
                        "FK_CourseStudents_Courses_CourseId",
                        x => x.CourseId,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Graduations",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(nullable: false),
                    StudentId = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graduations", x => x.Id);
                    table.ForeignKey(
                        "FK_Graduations_Courses_CourseId",
                        x => x.CourseId,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "HallStudents",
                table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    HallId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallStudents", x => new {x.HallId, x.StudentId});
                    table.ForeignKey(
                        "FK_HallStudents_Halls_HallId",
                        x => x.HallId,
                        "Halls",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "LibraryBooks",
                table => new
                {
                    LibraryId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryBooks", x => new {x.LibraryId, x.BookId});
                    table.ForeignKey(
                        "FK_LibraryBooks_Books_BookId",
                        x => x.BookId,
                        "Books",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_LibraryBooks_Libraries_LibraryId",
                        x => x.LibraryId,
                        "Libraries",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Assignments",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    Deadline = table.Column<DateTimeOffset>(nullable: false),
                    RunId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        "FK_Assignments_Runs_RunId",
                        x => x.RunId,
                        "Runs",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Enrolments",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(nullable: false),
                    StudentId = table.Column<string>(nullable: true),
                    RunId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolments", x => x.Id);
                    table.ForeignKey(
                        "FK_Enrolments_Runs_RunId",
                        x => x.RunId,
                        "Runs",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Lectures",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTimeOffset>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    RunId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                    table.ForeignKey(
                        "FK_Lectures_Rooms_RoomId",
                        x => x.RoomId,
                        "Rooms",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Lectures_Runs_RunId",
                        x => x.RunId,
                        "Runs",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Results",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Grade = table.Column<int>(nullable: false),
                    Feedback = table.Column<string>(nullable: true),
                    StudentId = table.Column<string>(nullable: true),
                    AssignmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        "FK_Results_Assignments_AssignmentId",
                        x => x.AssignmentId,
                        "Assignments",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Assignments_RunId",
                "Assignments",
                "RunId");

            migrationBuilder.CreateIndex(
                "IX_CourseModules_ModuleId",
                "CourseModules",
                "ModuleId");

            migrationBuilder.CreateIndex(
                "IX_Courses_CampusId",
                "Courses",
                "CampusId");

            migrationBuilder.CreateIndex(
                "IX_Enrolments_RunId",
                "Enrolments",
                "RunId");

            migrationBuilder.CreateIndex(
                "IX_Graduations_CourseId",
                "Graduations",
                "CourseId");

            migrationBuilder.CreateIndex(
                "IX_Halls_CampusId",
                "Halls",
                "CampusId");

            migrationBuilder.CreateIndex(
                "IX_Lectures_RoomId",
                "Lectures",
                "RoomId");

            migrationBuilder.CreateIndex(
                "IX_Lectures_RunId",
                "Lectures",
                "RunId");

            migrationBuilder.CreateIndex(
                "IX_Libraries_CampusId",
                "Libraries",
                "CampusId");

            migrationBuilder.CreateIndex(
                "IX_LibraryBooks_BookId",
                "LibraryBooks",
                "BookId");

            migrationBuilder.CreateIndex(
                "IX_Rentals_BookId",
                "Rentals",
                "BookId");

            migrationBuilder.CreateIndex(
                "IX_Results_AssignmentId",
                "Results",
                "AssignmentId");

            migrationBuilder.CreateIndex(
                "IX_Rooms_CampusId",
                "Rooms",
                "CampusId");

            migrationBuilder.CreateIndex(
                "IX_Runs_ModuleId",
                "Runs",
                "ModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "CourseModules");

            migrationBuilder.DropTable(
                "CourseStudents");

            migrationBuilder.DropTable(
                "Enrolments");

            migrationBuilder.DropTable(
                "Graduations");

            migrationBuilder.DropTable(
                "HallStudents");

            migrationBuilder.DropTable(
                "Lectures");

            migrationBuilder.DropTable(
                "LibraryBooks");

            migrationBuilder.DropTable(
                "Rentals");

            migrationBuilder.DropTable(
                "Results");

            migrationBuilder.DropTable(
                "Courses");

            migrationBuilder.DropTable(
                "Halls");

            migrationBuilder.DropTable(
                "Rooms");

            migrationBuilder.DropTable(
                "Libraries");

            migrationBuilder.DropTable(
                "Books");

            migrationBuilder.DropTable(
                "Assignments");

            migrationBuilder.DropTable(
                "Campuses");

            migrationBuilder.DropTable(
                "Runs");

            migrationBuilder.DropTable(
                "Modules");
        }
    }
}