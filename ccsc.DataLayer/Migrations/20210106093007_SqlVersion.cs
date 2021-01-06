using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class SqlVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SqlVersionId",
                table: "Servers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SqlVersions",
                columns: table => new
                {
                    SqlVersionId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SqlVersions", x => x.SqlVersionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servers_SqlVersionId",
                table: "Servers",
                column: "SqlVersionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servers_SqlVersions_SqlVersionId",
                table: "Servers",
                column: "SqlVersionId",
                principalTable: "SqlVersions",
                principalColumn: "SqlVersionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servers_SqlVersions_SqlVersionId",
                table: "Servers");

            migrationBuilder.DropTable(
                name: "SqlVersions");

            migrationBuilder.DropIndex(
                name: "IX_Servers_SqlVersionId",
                table: "Servers");

            migrationBuilder.DropColumn(
                name: "SqlVersionId",
                table: "Servers");
        }
    }
}
