﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedBiology : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SubjectTariffes",
                keyColumn: "Id",
                keyValue: 6,
                column: "subjectNameId",
                value: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SubjectTariffes",
                keyColumn: "Id",
                keyValue: 6,
                column: "subjectNameId",
                value: 3);
        }
    }
}
