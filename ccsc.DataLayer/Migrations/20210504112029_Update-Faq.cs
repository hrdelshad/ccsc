using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class UpdateFaq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faqs_SubSystems_SubSystemId",
                table: "Faqs");

            migrationBuilder.DropForeignKey(
                name: "FK_Faqs_UserTypes_UserTypeId",
                table: "Faqs");

            migrationBuilder.DropIndex(
                name: "IX_Faqs_SubSystemId",
                table: "Faqs");

            migrationBuilder.DropIndex(
                name: "IX_Faqs_UserTypeId",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "SubSystemId",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                table: "Faqs");

            migrationBuilder.CreateTable(
                name: "FaqSubSystem",
                columns: table => new
                {
                    FaqsFaqId = table.Column<int>(type: "int", nullable: false),
                    SubSystemsSubSystemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqSubSystem", x => new { x.FaqsFaqId, x.SubSystemsSubSystemId });
                    table.ForeignKey(
                        name: "FK_FaqSubSystem_Faqs_FaqsFaqId",
                        column: x => x.FaqsFaqId,
                        principalTable: "Faqs",
                        principalColumn: "FaqId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaqSubSystem_SubSystems_SubSystemsSubSystemId",
                        column: x => x.SubSystemsSubSystemId,
                        principalTable: "SubSystems",
                        principalColumn: "SubSystemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaqUserType",
                columns: table => new
                {
                    FaqsFaqId = table.Column<int>(type: "int", nullable: false),
                    UserTypesUserTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqUserType", x => new { x.FaqsFaqId, x.UserTypesUserTypeId });
                    table.ForeignKey(
                        name: "FK_FaqUserType_Faqs_FaqsFaqId",
                        column: x => x.FaqsFaqId,
                        principalTable: "Faqs",
                        principalColumn: "FaqId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaqUserType_UserTypes_UserTypesUserTypeId",
                        column: x => x.UserTypesUserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaqSubSystem_SubSystemsSubSystemId",
                table: "FaqSubSystem",
                column: "SubSystemsSubSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_FaqUserType_UserTypesUserTypeId",
                table: "FaqUserType",
                column: "UserTypesUserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaqSubSystem");

            migrationBuilder.DropTable(
                name: "FaqUserType");

            migrationBuilder.AddColumn<int>(
                name: "SubSystemId",
                table: "Faqs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                table: "Faqs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_SubSystemId",
                table: "Faqs",
                column: "SubSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_UserTypeId",
                table: "Faqs",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faqs_SubSystems_SubSystemId",
                table: "Faqs",
                column: "SubSystemId",
                principalTable: "SubSystems",
                principalColumn: "SubSystemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Faqs_UserTypes_UserTypeId",
                table: "Faqs",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
