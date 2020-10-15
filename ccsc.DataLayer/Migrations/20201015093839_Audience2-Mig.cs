using Microsoft.EntityFrameworkCore.Migrations;

namespace ccsc.DataLayer.Migrations
{
    public partial class Audience2Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audiences",
                columns: table => new
                {
                    AudienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audiences", x => x.AudienceId);
                });

            migrationBuilder.CreateTable(
                name: "AudienceVideo",
                columns: table => new
                {
                    AudiencesAudienceId = table.Column<int>(type: "int", nullable: false),
                    VideosVideoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudienceVideo", x => new { x.AudiencesAudienceId, x.VideosVideoId });
                    table.ForeignKey(
                        name: "FK_AudienceVideo_Audiences_AudiencesAudienceId",
                        column: x => x.AudiencesAudienceId,
                        principalTable: "Audiences",
                        principalColumn: "AudienceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AudienceVideo_Videos_VideosVideoId",
                        column: x => x.VideosVideoId,
                        principalTable: "Videos",
                        principalColumn: "VideoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AudienceVideo_VideosVideoId",
                table: "AudienceVideo",
                column: "VideosVideoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudienceVideo");

            migrationBuilder.DropTable(
                name: "Audiences");
        }
    }
}
