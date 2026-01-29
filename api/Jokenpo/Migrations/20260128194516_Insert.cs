using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokenpo.Migrations
{
    /// <inheritdoc />
    public partial class Insert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Movements\" (\"Id\", \"Name\") VALUES (1,'PEDRA')");
            migrationBuilder.Sql("INSERT INTO \"Movements\" (\"Id\", \"Name\") VALUES (2,'PAPEL')");
            migrationBuilder.Sql("INSERT INTO \"Movements\" (\"Id\", \"Name\") VALUES (3,'TESOURA')");

            migrationBuilder.Sql("INSERT INTO \"MoveWinners\" (\"MoveId\", \"WinnerId\") VALUES (1,3)");
            migrationBuilder.Sql("INSERT INTO \"MoveWinners\" (\"MoveId\", \"WinnerId\") VALUES (2,1)");
            migrationBuilder.Sql("INSERT INTO \"MoveWinners\" (\"MoveId\", \"WinnerId\") VALUES (3,2)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"MoveWinners\"");
            migrationBuilder.Sql("DELETE FROM \"Movements\"");

        }
    }
}
