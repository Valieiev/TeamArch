using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.EFСore.Migrations.AlgorithmsDb
{
    public partial class numberAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "CodeParts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "CodeParts");
        }
    }
}
