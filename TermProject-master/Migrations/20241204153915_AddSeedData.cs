using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TermProject.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Designers",
                columns: new[] { "DesignerId", "Email", "First Name", "Last Name" },
                values: new object[] { 6, "ugh@test.org", "CRUD", "Testing" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Designers",
                keyColumn: "DesignerId",
                keyValue: 6);
        }
    }
}
