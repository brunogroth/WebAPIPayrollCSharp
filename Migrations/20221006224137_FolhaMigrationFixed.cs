using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIPayrollCSharp.Migrations
{
    public partial class FolhaMigrationFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folha",
                columns: table => new
                {
                    folhaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    valorHora = table.Column<double>(type: "REAL", nullable: false),
                    quantidadeHoras = table.Column<double>(type: "REAL", nullable: false),
                    salarioBruto = table.Column<double>(type: "REAL", nullable: false),
                    impostoRenda = table.Column<double>(type: "REAL", nullable: false),
                    impostoInss = table.Column<double>(type: "REAL", nullable: false),
                    salarioLiquido = table.Column<double>(type: "REAL", nullable: false),
                    employeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folha", x => x.folhaId);
                    table.ForeignKey(
                        name: "FK_Folha_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folha_employeeId",
                table: "Folha",
                column: "employeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folha");
        }
    }
}
