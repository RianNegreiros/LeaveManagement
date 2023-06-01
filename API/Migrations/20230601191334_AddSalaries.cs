using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class AddSalaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Salary_SalaryId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "PersonDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salary",
                table: "Salary");

            migrationBuilder.RenameTable(
                name: "Salary",
                newName: "Salaries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salaries",
                table: "Salaries",
                column: "SalaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Salaries_SalaryId",
                table: "Persons",
                column: "SalaryId",
                principalTable: "Salaries",
                principalColumn: "SalaryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Salaries_SalaryId",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salaries",
                table: "Salaries");

            migrationBuilder.RenameTable(
                name: "Salaries",
                newName: "Salary");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salary",
                table: "Salary",
                column: "SalaryId");

            migrationBuilder.CreateTable(
                name: "PersonDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonCity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonDetail_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonDetail_PersonId",
                table: "PersonDetail",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Salary_SalaryId",
                table: "Persons",
                column: "SalaryId",
                principalTable: "Salary",
                principalColumn: "SalaryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
