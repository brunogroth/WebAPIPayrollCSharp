using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIPayrollCSharp.Migrations
{
    public partial class AddFGTSFolha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "impostoFGTS",
                table: "Folha",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "impostoFGTS",
                table: "Folha");
        }
    }
}
