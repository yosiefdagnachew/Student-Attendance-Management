using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAS.Migrations
{
    /// <inheritdoc />
    public partial class migration01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Academic_Year",
                columns: table => new
                {
                    Academic_y_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Academic_year = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academic_Year", x => x.Academic_y_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Class_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Building_number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Class_id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Course_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Course_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Course_credit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Course_descrption = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Course_id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department_code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Department_id);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    Semester_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    semester = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.Semester_id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Teacher_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher_fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Teacher_lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Teacher_id);
                });

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    Year_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year", x => x.Year_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faculities",
                columns: table => new
                {
                    Faculity_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_id = table.Column<int>(type: "int", nullable: false),
                    Faculty_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Faculty_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Faculty_email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculities", x => x.Faculity_id);
                    table.ForeignKey(
                        name: "FK_Faculities_Department_Department_id",
                        column: x => x.Department_id,
                        principalTable: "Department",
                        principalColumn: "Department_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department_course",
                columns: table => new
                {
                    Dept_course_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_id = table.Column<int>(type: "int", nullable: false),
                    Course_id = table.Column<int>(type: "int", nullable: false),
                    Year_id = table.Column<int>(type: "int", nullable: false),
                    Semester_id = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department_course", x => x.Dept_course_id);
                    table.ForeignKey(
                        name: "FK_Department_course_Course_Course_id",
                        column: x => x.Course_id,
                        principalTable: "Course",
                        principalColumn: "Course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Department_course_Department_Department_id",
                        column: x => x.Department_id,
                        principalTable: "Department",
                        principalColumn: "Department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Department_course_Semester_Semester_id",
                        column: x => x.Semester_id,
                        principalTable: "Semester",
                        principalColumn: "Semester_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Department_course_Year_Year_id",
                        column: x => x.Year_id,
                        principalTable: "Year",
                        principalColumn: "Year_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Stud_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Academic_y_id = table.Column<int>(type: "int", nullable: false),
                    Year_id = table.Column<int>(type: "int", nullable: false),
                    Stud_fname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stud_lname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Stud_id);
                    table.ForeignKey(
                        name: "FK_Student_Academic_Year_Academic_y_id",
                        column: x => x.Academic_y_id,
                        principalTable: "Academic_Year",
                        principalColumn: "Academic_y_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Year_Year_id",
                        column: x => x.Year_id,
                        principalTable: "Year",
                        principalColumn: "Year_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Class_program",
                columns: table => new
                {
                    ClassProgram_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Class_id = table.Column<int>(type: "int", nullable: false),
                    Course_id = table.Column<int>(type: "int", nullable: false),
                    Faculity_id = table.Column<int>(type: "int", nullable: false),
                    Teacher_id = table.Column<int>(type: "int", nullable: false),
                    Period = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class_program", x => x.ClassProgram_id);
                    table.ForeignKey(
                        name: "FK_Class_program_Class_Class_id",
                        column: x => x.Class_id,
                        principalTable: "Class",
                        principalColumn: "Class_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Class_program_Course_Course_id",
                        column: x => x.Course_id,
                        principalTable: "Course",
                        principalColumn: "Course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Class_program_Faculities_Faculity_id",
                        column: x => x.Faculity_id,
                        principalTable: "Faculities",
                        principalColumn: "Faculity_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Class_program_Teacher_Teacher_id",
                        column: x => x.Teacher_id,
                        principalTable: "Teacher",
                        principalColumn: "Teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course_teacher",
                columns: table => new
                {
                    Course_teacher_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Teacher_id = table.Column<int>(type: "int", nullable: false),
                    Academic_y_id = table.Column<int>(type: "int", nullable: false),
                    Semester_id = table.Column<int>(type: "int", nullable: false),
                    Faculity_id = table.Column<int>(type: "int", nullable: false),
                    Department_id = table.Column<int>(type: "int", nullable: false),
                    Course_id = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_teacher", x => x.Course_teacher_id);
                    table.ForeignKey(
                        name: "FK_Course_teacher_Academic_Year_Academic_y_id",
                        column: x => x.Academic_y_id,
                        principalTable: "Academic_Year",
                        principalColumn: "Academic_y_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_teacher_Course_Course_id",
                        column: x => x.Course_id,
                        principalTable: "Course",
                        principalColumn: "Course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_teacher_Department_Department_id",
                        column: x => x.Department_id,
                        principalTable: "Department",
                        principalColumn: "Department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_teacher_Faculities_Faculity_id",
                        column: x => x.Faculity_id,
                        principalTable: "Faculities",
                        principalColumn: "Faculity_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Course_teacher_Semester_Semester_id",
                        column: x => x.Semester_id,
                        principalTable: "Semester",
                        principalColumn: "Semester_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_teacher_Teacher_Teacher_id",
                        column: x => x.Teacher_id,
                        principalTable: "Teacher",
                        principalColumn: "Teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    Enrollement_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stud_id = table.Column<int>(type: "int", nullable: false),
                    Academic_y_id = table.Column<int>(type: "int", nullable: false),
                    Course_id = table.Column<int>(type: "int", nullable: false),
                    Faculity_id = table.Column<int>(type: "int", nullable: false),
                    Semester_id = table.Column<int>(type: "int", nullable: false),
                    Department_id = table.Column<int>(type: "int", nullable: false),
                    Enrollment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.Enrollement_id);
                    table.ForeignKey(
                        name: "FK_Enrollment_Academic_Year_Academic_y_id",
                        column: x => x.Academic_y_id,
                        principalTable: "Academic_Year",
                        principalColumn: "Academic_y_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Course_Course_id",
                        column: x => x.Course_id,
                        principalTable: "Course",
                        principalColumn: "Course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Department_Department_id",
                        column: x => x.Department_id,
                        principalTable: "Department",
                        principalColumn: "Department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Faculities_Faculity_id",
                        column: x => x.Faculity_id,
                        principalTable: "Faculities",
                        principalColumn: "Faculity_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Enrollment_Semester_Semester_id",
                        column: x => x.Semester_id,
                        principalTable: "Semester",
                        principalColumn: "Semester_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Student_Stud_id",
                        column: x => x.Stud_id,
                        principalTable: "Student",
                        principalColumn: "Stud_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Student_course",
                columns: table => new
                {
                    Stud_course_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stud_id = table.Column<int>(type: "int", nullable: false),
                    Course_id = table.Column<int>(type: "int", nullable: false),
                    Academic_y_id = table.Column<int>(type: "int", nullable: false),
                    Department_id = table.Column<int>(type: "int", nullable: false),
                    Faculity_id = table.Column<int>(type: "int", nullable: false),
                    Semester_id = table.Column<int>(type: "int", nullable: false),
                    Year_id = table.Column<int>(type: "int", nullable: false),
                    Attendance_time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_course", x => x.Stud_course_id);
                    table.ForeignKey(
                        name: "FK_Student_course_Academic_Year_Academic_y_id",
                        column: x => x.Academic_y_id,
                        principalTable: "Academic_Year",
                        principalColumn: "Academic_y_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_course_Course_Course_id",
                        column: x => x.Course_id,
                        principalTable: "Course",
                        principalColumn: "Course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_course_Department_Department_id",
                        column: x => x.Department_id,
                        principalTable: "Department",
                        principalColumn: "Department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_course_Faculities_Faculity_id",
                        column: x => x.Faculity_id,
                        principalTable: "Faculities",
                        principalColumn: "Faculity_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Student_course_Semester_Semester_id",
                        column: x => x.Semester_id,
                        principalTable: "Semester",
                        principalColumn: "Semester_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_course_Student_Stud_id",
                        column: x => x.Stud_id,
                        principalTable: "Student",
                        principalColumn: "Stud_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Student_course_Year_Year_id",
                        column: x => x.Year_id,
                        principalTable: "Year",
                        principalColumn: "Year_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student_class",
                columns: table => new
                {
                    Student_Class_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stud_id = table.Column<int>(type: "int", nullable: false),
                    Academic_y_id = table.Column<int>(type: "int", nullable: false),
                    ClassProgram_id = table.Column<int>(type: "int", nullable: false),
                    Department_id = table.Column<int>(type: "int", nullable: false),
                    Faculity_id = table.Column<int>(type: "int", nullable: false),
                    Semester_id = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_class", x => x.Student_Class_id);
                    table.ForeignKey(
                        name: "FK_Student_class_Academic_Year_Academic_y_id",
                        column: x => x.Academic_y_id,
                        principalTable: "Academic_Year",
                        principalColumn: "Academic_y_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_class_Class_program_ClassProgram_id",
                        column: x => x.ClassProgram_id,
                        principalTable: "Class_program",
                        principalColumn: "ClassProgram_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_class_Department_Department_id",
                        column: x => x.Department_id,
                        principalTable: "Department",
                        principalColumn: "Department_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Student_class_Faculities_Faculity_id",
                        column: x => x.Faculity_id,
                        principalTable: "Faculities",
                        principalColumn: "Faculity_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Student_class_Semester_Semester_id",
                        column: x => x.Semester_id,
                        principalTable: "Semester",
                        principalColumn: "Semester_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_class_Student_Stud_id",
                        column: x => x.Stud_id,
                        principalTable: "Student",
                        principalColumn: "Stud_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    Attendance_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stud_id = table.Column<int>(type: "int", nullable: false),
                    Academic_y_id = table.Column<int>(type: "int", nullable: false),
                    Department_id = table.Column<int>(type: "int", nullable: false),
                    Enrollment_id = table.Column<int>(type: "int", nullable: false),
                    Faculity_id = table.Column<int>(type: "int", nullable: false),
                    Semister_id = table.Column<int>(type: "int", nullable: false),
                    Attendance_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Attendance_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.Attendance_id);
                    table.ForeignKey(
                        name: "FK_Attendance_Academic_Year_Academic_y_id",
                        column: x => x.Academic_y_id,
                        principalTable: "Academic_Year",
                        principalColumn: "Academic_y_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendance_Department_Department_id",
                        column: x => x.Department_id,
                        principalTable: "Department",
                        principalColumn: "Department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendance_Enrollment_Enrollment_id",
                        column: x => x.Enrollment_id,
                        principalTable: "Enrollment",
                        principalColumn: "Enrollement_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Attendance_Faculities_Faculity_id",
                        column: x => x.Faculity_id,
                        principalTable: "Faculities",
                        principalColumn: "Faculity_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Attendance_Semester_Semister_id",
                        column: x => x.Semister_id,
                        principalTable: "Semester",
                        principalColumn: "Semester_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendance_Student_Stud_id",
                        column: x => x.Stud_id,
                        principalTable: "Student",
                        principalColumn: "Stud_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_Academic_y_id",
                table: "Attendance",
                column: "Academic_y_id");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_Department_id",
                table: "Attendance",
                column: "Department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_Enrollment_id",
                table: "Attendance",
                column: "Enrollment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_Faculity_id",
                table: "Attendance",
                column: "Faculity_id");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_Semister_id",
                table: "Attendance",
                column: "Semister_id");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_Stud_id",
                table: "Attendance",
                column: "Stud_id");

            migrationBuilder.CreateIndex(
                name: "IX_Class_program_Class_id",
                table: "Class_program",
                column: "Class_id");

            migrationBuilder.CreateIndex(
                name: "IX_Class_program_Course_id",
                table: "Class_program",
                column: "Course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Class_program_Faculity_id",
                table: "Class_program",
                column: "Faculity_id");

            migrationBuilder.CreateIndex(
                name: "IX_Class_program_Teacher_id",
                table: "Class_program",
                column: "Teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_Course_teacher_Academic_y_id",
                table: "Course_teacher",
                column: "Academic_y_id");

            migrationBuilder.CreateIndex(
                name: "IX_Course_teacher_Course_id",
                table: "Course_teacher",
                column: "Course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Course_teacher_Department_id",
                table: "Course_teacher",
                column: "Department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Course_teacher_Faculity_id",
                table: "Course_teacher",
                column: "Faculity_id");

            migrationBuilder.CreateIndex(
                name: "IX_Course_teacher_Semester_id",
                table: "Course_teacher",
                column: "Semester_id");

            migrationBuilder.CreateIndex(
                name: "IX_Course_teacher_Teacher_id",
                table: "Course_teacher",
                column: "Teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_Department_course_Course_id",
                table: "Department_course",
                column: "Course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Department_course_Department_id",
                table: "Department_course",
                column: "Department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Department_course_Semester_id",
                table: "Department_course",
                column: "Semester_id");

            migrationBuilder.CreateIndex(
                name: "IX_Department_course_Year_id",
                table: "Department_course",
                column: "Year_id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_Academic_y_id",
                table: "Enrollment",
                column: "Academic_y_id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_Course_id",
                table: "Enrollment",
                column: "Course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_Department_id",
                table: "Enrollment",
                column: "Department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_Faculity_id",
                table: "Enrollment",
                column: "Faculity_id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_Semester_id",
                table: "Enrollment",
                column: "Semester_id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_Stud_id",
                table: "Enrollment",
                column: "Stud_id");

            migrationBuilder.CreateIndex(
                name: "IX_Faculities_Department_id",
                table: "Faculities",
                column: "Department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Academic_y_id",
                table: "Student",
                column: "Academic_y_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Year_id",
                table: "Student",
                column: "Year_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_class_Academic_y_id",
                table: "Student_class",
                column: "Academic_y_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_class_ClassProgram_id",
                table: "Student_class",
                column: "ClassProgram_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_class_Department_id",
                table: "Student_class",
                column: "Department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_class_Faculity_id",
                table: "Student_class",
                column: "Faculity_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_class_Semester_id",
                table: "Student_class",
                column: "Semester_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_class_Stud_id",
                table: "Student_class",
                column: "Stud_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_course_Academic_y_id",
                table: "Student_course",
                column: "Academic_y_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_course_Course_id",
                table: "Student_course",
                column: "Course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_course_Department_id",
                table: "Student_course",
                column: "Department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_course_Faculity_id",
                table: "Student_course",
                column: "Faculity_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_course_Semester_id",
                table: "Student_course",
                column: "Semester_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_course_Stud_id",
                table: "Student_course",
                column: "Stud_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_course_Year_id",
                table: "Student_course",
                column: "Year_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "Course_teacher");

            migrationBuilder.DropTable(
                name: "Department_course");

            migrationBuilder.DropTable(
                name: "Student_class");

            migrationBuilder.DropTable(
                name: "Student_course");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Class_program");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Faculities");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Academic_Year");

            migrationBuilder.DropTable(
                name: "Year");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
