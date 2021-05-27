using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallUrlShortener.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UrlMappings",
                columns: table => new
                {
                    URLMappingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OriginalLink = table.Column<string>(type: "TEXT", nullable: false),
                    ShortLinkId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrlMappings", x => x.URLMappingId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UrlMappings_OriginalLink",
                table: "UrlMappings",
                column: "OriginalLink",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UrlMappings_ShortLinkId",
                table: "UrlMappings",
                column: "ShortLinkId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UrlMappings");
        }
    }
}
