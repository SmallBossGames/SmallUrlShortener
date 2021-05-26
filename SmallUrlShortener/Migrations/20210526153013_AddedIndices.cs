using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallUrlShortener.Migrations
{
    public partial class AddedIndices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UrlMappings_DirectLink_ShortLink",
                table: "UrlMappings",
                columns: new[] { "DirectLink", "ShortLink" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UrlMappings_DirectLink_ShortLink",
                table: "UrlMappings");
        }
    }
}
