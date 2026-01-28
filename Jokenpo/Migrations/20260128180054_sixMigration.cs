using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokenpo.Migrations
{
    /// <inheritdoc />
    public partial class sixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Movements_MoveId",
                table: "Movements");

            migrationBuilder.DropIndex(
                name: "IX_Movements_MoveId",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "MoveId",
                table: "Movements");

            migrationBuilder.CreateTable(
                name: "MoveWinners",
                columns: table => new
                {
                    MoveId = table.Column<int>(type: "integer", nullable: false),
                    WinnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoveWinners", x => new { x.MoveId, x.WinnerId });
                    table.ForeignKey(
                        name: "FK_MoveWinners_Movements_MoveId",
                        column: x => x.MoveId,
                        principalTable: "Movements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoveWinners_Movements_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Movements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoveWinners_WinnerId",
                table: "MoveWinners",
                column: "WinnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoveWinners");

            migrationBuilder.AddColumn<int>(
                name: "MoveId",
                table: "Movements",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movements_MoveId",
                table: "Movements",
                column: "MoveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Movements_MoveId",
                table: "Movements",
                column: "MoveId",
                principalTable: "Movements",
                principalColumn: "Id");
        }
    }
}
