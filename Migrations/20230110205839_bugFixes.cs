using Microsoft.EntityFrameworkCore.Migrations;

namespace virtualReality.Migrations
{
    public partial class bugFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pictures_games_Id",
                table: "Pictures");

            migrationBuilder.AddColumn<int>(
                name: "Game_Id",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "orderId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_games_Id",
                table: "Pictures",
                column: "games_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_orderId",
                table: "Games",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Orders_orderId",
                table: "Games",
                column: "orderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Orders_orderId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_games_Id",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Games_orderId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Game_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "Games");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_games_Id",
                table: "Pictures",
                column: "games_Id");
        }
    }
}
