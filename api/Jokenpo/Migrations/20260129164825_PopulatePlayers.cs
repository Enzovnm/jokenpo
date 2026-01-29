using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jokenpo.Migrations
{
    /// <inheritdoc />
    public partial class PopulatePlayers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Players\" (\"Id\", \"Name\") VALUES (1,'Test One')");
            migrationBuilder.Sql("INSERT INTO \"Players\" (\"Id\", \"Name\") VALUES (2,'Test Two')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Players\"");
        }
    }
}
