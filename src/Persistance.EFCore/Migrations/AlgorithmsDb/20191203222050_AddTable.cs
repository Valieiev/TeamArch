using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.EFСore.Migrations.AlgorithmsDb
{
    public partial class AddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodeParts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTaskId = table.Column<int>(nullable: false),
                    CodeText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CodeParts_UserTasks_UserTaskId",
                        column: x => x.UserTaskId,
                        principalTable: "UserTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagramms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ImageURL = table.Column<string>(nullable: false),
                    UserTaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagramms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagramms_UserTasks_UserTaskId",
                        column: x => x.UserTaskId,
                        principalTable: "UserTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    UserTaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_UserTasks_UserTaskId",
                        column: x => x.UserTaskId,
                        principalTable: "UserTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CodeParts_UserTaskId",
                table: "CodeParts",
                column: "UserTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagramms_UserTaskId",
                table: "Diagramms",
                column: "UserTaskId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserTaskId",
                table: "Questions",
                column: "UserTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeParts");

            migrationBuilder.DropTable(
                name: "Diagramms");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
