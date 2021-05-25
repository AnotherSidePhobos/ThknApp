using Microsoft.EntityFrameworkCore.Migrations;

namespace ThknApp.Migrations
{
    public partial class onetomany23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Items",
                newName: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Items",
                newName: "UserId");
        }
    }
}
