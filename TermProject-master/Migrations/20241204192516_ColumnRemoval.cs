using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TermProject.Migrations
{
    /// <inheritdoc />
    public partial class ColumnRemoval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Designers_DesignerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DesignerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DesignerId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesignerId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "DesignerId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "DesignerId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "DesignerId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "DesignerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "DesignerId",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_Products_DesignerId",
                table: "Products",
                column: "DesignerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Designers_DesignerId",
                table: "Products",
                column: "DesignerId",
                principalTable: "Designers",
                principalColumn: "DesignerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
