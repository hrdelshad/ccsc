using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class Add_Version : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Videos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Publish",
                table: "Faqs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                table: "Faqs",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                table: "ChangeSets",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Publish",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Faqs");

            migrationBuilder.AlterColumn<string>(
                name: "Version",
                table: "ChangeSets",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
