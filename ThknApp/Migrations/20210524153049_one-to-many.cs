using Microsoft.EntityFrameworkCore.Migrations;

namespace ThknApp.Migrations
{
    public partial class onetomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Items",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ApplicationUserId1",
                table: "Items",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_ApplicationUserId1",
                table: "Items",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_ApplicationUserId1",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ApplicationUserId1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Items");
        }
    }
}
