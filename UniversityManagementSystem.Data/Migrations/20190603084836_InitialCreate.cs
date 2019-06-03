using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityManagementSystem.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Books",
                table => new
                {
                    Id = table.Column<int>()
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
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Campuses", x => x.Id); });

            migrationBuilder.CreateTable(
                "Modules",
                table => new
                {
                    Id = table.Column<int>()
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
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckoutDate =
                        table.Column<DateTimeOffset>(nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    ReturnDate = table.Column<DateTimeOffset>(),
                    StudentId = table.Column<string>(nullable: true),
                    BookId = table.Column<int>()
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
                "Buildings",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CampusId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        "FK_Buildings_Campuses_CampusId",
                        x => x.CampusId,
                        "Campuses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Schools",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CampusId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                    table.ForeignKey(
                        "FK_Schools_Campuses_CampusId",
                        x => x.CampusId,
                        "Campuses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Runs",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(),
                    Semester = table.Column<string>(nullable: true),
                    LecturerId = table.Column<string>(nullable: true),
                    ModuleId = table.Column<int>()
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
                "Libraries",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BuildingId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                    table.ForeignKey(
                        "FK_Libraries_Buildings_BuildingId",
                        x => x.BuildingId,
                        "Buildings",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Refectories",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BuildingId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refectories", x => x.Id);
                    table.ForeignKey(
                        "FK_Refectories_Buildings_BuildingId",
                        x => x.BuildingId,
                        "Buildings",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Rooms",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BuildingId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        "FK_Rooms_Buildings_BuildingId",
                        x => x.BuildingId,
                        "Buildings",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Courses",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SchoolId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        "FK_Courses_Schools_SchoolId",
                        x => x.SchoolId,
                        "Schools",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Assignments",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    Deadline = table.Column<DateTimeOffset>(),
                    RunId = table.Column<int>()
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
                "RunStudents",
                table => new
                {
                    StudentId = table.Column<string>(),
                    RunId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunStudents", x => new {x.RunId, x.StudentId});
                    table.ForeignKey(
                        "FK_RunStudents_Runs_RunId",
                        x => x.RunId,
                        "Runs",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "LibraryBooks",
                table => new
                {
                    LibraryId = table.Column<int>(),
                    BookId = table.Column<int>()
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
                "Lectures",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTimeOffset>(),
                    Duration = table.Column<TimeSpan>(),
                    RunId = table.Column<int>(),
                    RoomId = table.Column<int>()
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
                "CourseModules",
                table => new
                {
                    CourseId = table.Column<int>(),
                    ModuleId = table.Column<int>()
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
                    StudentId = table.Column<string>(),
                    CourseId = table.Column<int>()
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
                "Enrolments",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(),
                    StudentId = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolments", x => x.Id);
                    table.ForeignKey(
                        "FK_Enrolments_Courses_CourseId",
                        x => x.CourseId,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Graduations",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(),
                    StudentId = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>()
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
                "Results",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Grade = table.Column<int>(),
                    Feedback = table.Column<string>(nullable: true),
                    StudentId = table.Column<string>(nullable: true),
                    AssignmentId = table.Column<int>()
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
                "IX_Buildings_CampusId",
                "Buildings",
                "CampusId");

            migrationBuilder.CreateIndex(
                "IX_CourseModules_ModuleId",
                "CourseModules",
                "ModuleId");

            migrationBuilder.CreateIndex(
                "IX_Courses_SchoolId",
                "Courses",
                "SchoolId");

            migrationBuilder.CreateIndex(
                "IX_Enrolments_CourseId",
                "Enrolments",
                "CourseId");

            migrationBuilder.CreateIndex(
                "IX_Graduations_CourseId",
                "Graduations",
                "CourseId");

            migrationBuilder.CreateIndex(
                "IX_Lectures_RoomId",
                "Lectures",
                "RoomId");

            migrationBuilder.CreateIndex(
                "IX_Lectures_RunId",
                "Lectures",
                "RunId");

            migrationBuilder.CreateIndex(
                "IX_Libraries_BuildingId",
                "Libraries",
                "BuildingId");

            migrationBuilder.CreateIndex(
                "IX_LibraryBooks_BookId",
                "LibraryBooks",
                "BookId");

            migrationBuilder.CreateIndex(
                "IX_Refectories_BuildingId",
                "Refectories",
                "BuildingId");

            migrationBuilder.CreateIndex(
                "IX_Rentals_BookId",
                "Rentals",
                "BookId");

            migrationBuilder.CreateIndex(
                "IX_Results_AssignmentId",
                "Results",
                "AssignmentId");

            migrationBuilder.CreateIndex(
                "IX_Rooms_BuildingId",
                "Rooms",
                "BuildingId");

            migrationBuilder.CreateIndex(
                "IX_Runs_ModuleId",
                "Runs",
                "ModuleId");

            migrationBuilder.CreateIndex(
                "IX_Schools_CampusId",
                "Schools",
                "CampusId");
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
                "Lectures");

            migrationBuilder.DropTable(
                "LibraryBooks");

            migrationBuilder.DropTable(
                "Refectories");

            migrationBuilder.DropTable(
                "Rentals");

            migrationBuilder.DropTable(
                "Results");

            migrationBuilder.DropTable(
                "RunStudents");

            migrationBuilder.DropTable(
                "Courses");

            migrationBuilder.DropTable(
                "Rooms");

            migrationBuilder.DropTable(
                "Libraries");

            migrationBuilder.DropTable(
                "Books");

            migrationBuilder.DropTable(
                "Assignments");

            migrationBuilder.DropTable(
                "Schools");

            migrationBuilder.DropTable(
                "Buildings");

            migrationBuilder.DropTable(
                "Runs");

            migrationBuilder.DropTable(
                "Campuses");

            migrationBuilder.DropTable(
                "Modules");
        }
    }
}