using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coefficient = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QualificationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTariffes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PricePerHour = table.Column<float>(type: "real", nullable: false),
                    subjectNameId = table.Column<int>(type: "int", nullable: false),
                    subjectTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTariffes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectTariffes_SubjectNames_subjectNameId",
                        column: x => x.subjectNameId,
                        principalTable: "SubjectNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTariffes_SubjectTypes_subjectTypeId",
                        column: x => x.subjectTypeId,
                        principalTable: "SubjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkedHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkedHoursPlanned = table.Column<int>(type: "int", nullable: false),
                    WorkedHoursDone = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    SubjectTariffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkedHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkedHours_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkedHours_SubjectTariffes_SubjectTariffId",
                        column: x => x.SubjectTariffId,
                        principalTable: "SubjectTariffes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkedHours_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salarys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherSalary = table.Column<float>(type: "real", nullable: false),
                    WorkedHoursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salarys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salarys_WorkedHours_WorkedHoursId",
                        column: x => x.WorkedHoursId,
                        principalTable: "WorkedHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "6.04.01" },
                    { 2, "6.04.02" },
                    { 3, "6.04.03" }
                });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "Coefficient", "Name" },
                values: new object[,]
                {
                    { 1, 2f, "Professor" },
                    { 2, 1.5f, "Doctor" },
                    { 3, 1f, "Master" }
                });

            migrationBuilder.InsertData(
                table: "SubjectNames",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Math" },
                    { 2, "Literature" },
                    { 3, "Chemistry" },
                    { 4, "Biology" }
                });

            migrationBuilder.InsertData(
                table: "SubjectTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Practice" },
                    { 2, "Lecture" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Email", "GroupId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Street 1", "andriy@example.com", 1, "Andriy", "+380999999991" },
                    { 2, "Street 2", "alex@example.com", 1, "Alex", "+380999999992" },
                    { 3, "Street 3", "anna@example.com", 1, "Anna", "+380999999993" },
                    { 4, "Street 4", "boris@example.com", 2, "Boris", "+380999999994" },
                    { 5, "Street 5", "bella@example.com", 2, "Bella", "+380999999995" },
                    { 6, "Street 6", "ben@example.com", 2, "Ben", "+380999999996" },
                    { 7, "Street 7", "charlie@example.com", 3, "Charlie", "+380999999997" },
                    { 8, "Street 8", "chloe@example.com", 3, "Chloe", "+380999999998" },
                    { 9, "Street 9", "chris@example.com", 3, "Chris", "+380999999999" }
                });

            migrationBuilder.InsertData(
                table: "SubjectTariffes",
                columns: new[] { "Id", "PricePerHour", "subjectNameId", "subjectTypeId" },
                values: new object[,]
                {
                    { 1, 400f, 1, 1 },
                    { 2, 350f, 2, 1 },
                    { 3, 300f, 1, 2 },
                    { 4, 250f, 2, 2 },
                    { 5, 200f, 3, 1 },
                    { 6, 150f, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Address", "Email", "Experience", "Name", "PhoneNumber", "QualificationId" },
                values: new object[,]
                {
                    { 1, "Gagarina Street 3", "shev1@gmail.com", "3 years", "Shevchenko D.I", "+380999999991", 1 },
                    { 2, "Lenina Street 4", "ivan1@gmail.com", "5 years", "Ivanenko A.V", "+380999999992", 1 },
                    { 3, "Pushkina Street 5", "petro1@gmail.com", "2 years", "Petrova L.M", "+380999999993", 2 },
                    { 4, "Kirova Street 6", "sidor1@gmail.com", "4 years", "Sidorov G.P", "+380999999994", 2 },
                    { 5, "Chekhova Street 7", "kuzne1@gmail.com", "1 year", "Kuznetsova S.I", "+380999999995", 3 },
                    { 6, "Tolstogo Street 8", "moroz1@gmail.com", "6 years", "Morozov V.K", "+380999999996", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salarys_WorkedHoursId",
                table: "Salarys",
                column: "WorkedHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTariffes_subjectNameId",
                table: "SubjectTariffes",
                column: "subjectNameId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTariffes_subjectTypeId",
                table: "SubjectTariffes",
                column: "subjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_QualificationId",
                table: "Teachers",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkedHours_GroupId",
                table: "WorkedHours",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkedHours_SubjectTariffId",
                table: "WorkedHours",
                column: "SubjectTariffId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkedHours_TeacherId",
                table: "WorkedHours",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salarys");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "WorkedHours");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "SubjectTariffes");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "SubjectNames");

            migrationBuilder.DropTable(
                name: "SubjectTypes");

            migrationBuilder.DropTable(
                name: "Qualifications");
        }
    }
}
