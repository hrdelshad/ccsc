using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class AddChangeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChangeTypeId",
                table: "ChangeSets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChangeType",
                columns: table => new
                {
                    ChangeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeType", x => x.ChangeTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSets_ChangeTypeId",
                table: "ChangeSets",
                column: "ChangeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_ChangeType_ChangeTypeId",
                table: "ChangeSets",
                column: "ChangeTypeId",
                principalTable: "ChangeType",
                principalColumn: "ChangeTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_ChangeType_ChangeTypeId",
                table: "ChangeSets");

            migrationBuilder.DropTable(
                name: "ChangeType");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_ChangeTypeId",
                table: "ChangeSets");

            migrationBuilder.DropColumn(
                name: "ChangeTypeId",
                table: "ChangeSets");
        }
    }
}
