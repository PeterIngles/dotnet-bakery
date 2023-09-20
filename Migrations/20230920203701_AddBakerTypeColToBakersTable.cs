using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetBakery.Migrations
{
    /// <inheritdoc />
    public partial class AddBakerTypeColToBakersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bakerType",
                table: "Bakers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bakerType",
                table: "Bakers");
        }
    }
}
