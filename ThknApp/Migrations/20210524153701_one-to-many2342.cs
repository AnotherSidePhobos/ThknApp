using Microsoft.EntityFrameworkCore.Migrations;

namespace ThknApp.Migrations
{
    public partial class onetomany2342 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FavoriteColor",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoriteColor",
                table: "AspNetUsers");
        }
    }
}
