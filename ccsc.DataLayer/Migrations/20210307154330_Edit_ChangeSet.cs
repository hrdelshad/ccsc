using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class Edit_ChangeSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_SubSystems_SubSystemId",
                table: "ChangeSets");

            migrationBuilder.DropForeignKey(
                name: "FK_ChangeSets_UserTypes_UserTypeId",
                table: "ChangeSets");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_SubSystemId",
                table: "ChangeSets");

            migrationBuilder.DropIndex(
                name: "IX_ChangeSets_UserTypeId",
                table: "ChangeSets");

            migrationBuilder.DropColumn(
                name: "SubSystemId",
                table: "ChangeSets");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                table: "ChangeSets");

            migrationBuilder.CreateTable(
                name: "ChangeSetSubSystem",
                columns: table => new
                {
                    ChangeSetsChangeSetId = table.Column<int>(type: "int", nullable: false),
                    SubSystemsSubSystemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeSetSubSystem", x => new { x.ChangeSetsChangeSetId, x.SubSystemsSubSystemId });
                    table.ForeignKey(
                        name: "FK_ChangeSetSubSystem_ChangeSets_ChangeSetsChangeSetId",
                        column: x => x.ChangeSetsChangeSetId,
                        principalTable: "ChangeSets",
                        principalColumn: "ChangeSetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChangeSetSubSystem_SubSystems_SubSystemsSubSystemId",
                        column: x => x.SubSystemsSubSystemId,
                        principalTable: "SubSystems",
                        principalColumn: "SubSystemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChangeSetUserType",
                columns: table => new
                {
                    ChangeSetsChangeSetId = table.Column<int>(type: "int", nullable: false),
                    UserTypesUserTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeSetUserType", x => new { x.ChangeSetsChangeSetId, x.UserTypesUserTypeId });
                    table.ForeignKey(
                        name: "FK_ChangeSetUserType_ChangeSets_ChangeSetsChangeSetId",
                        column: x => x.ChangeSetsChangeSetId,
                        principalTable: "ChangeSets",
                        principalColumn: "ChangeSetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChangeSetUserType_UserTypes_UserTypesUserTypeId",
                        column: x => x.UserTypesUserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSetSubSystem_SubSystemsSubSystemId",
                table: "ChangeSetSubSystem",
                column: "SubSystemsSubSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSetUserType_UserTypesUserTypeId",
                table: "ChangeSetUserType",
                column: "UserTypesUserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeSetSubSystem");

            migrationBuilder.DropTable(
                name: "ChangeSetUserType");

            migrationBuilder.AddColumn<int>(
                name: "SubSystemId",
                table: "ChangeSets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                table: "ChangeSets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSets_SubSystemId",
                table: "ChangeSets",
                column: "SubSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeSets_UserTypeId",
                table: "ChangeSets",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_SubSystems_SubSystemId",
                table: "ChangeSets",
                column: "SubSystemId",
                principalTable: "SubSystems",
                principalColumn: "SubSystemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChangeSets_UserTypes_UserTypeId",
                table: "ChangeSets",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
