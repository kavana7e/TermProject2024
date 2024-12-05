using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TermProject.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Designers",
                columns: table => new
                {
                    DesignerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(name: "First Name", type: "nvarchar(35)", maxLength: 35, nullable: false),
                    LastName = table.Column<string>(name: "Last Name", type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designers", x => x.DesignerId);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    SeasonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.SeasonId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DesignerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Designers_DesignerId",
                        column: x => x.DesignerId,
                        principalTable: "Designers",
                        principalColumn: "DesignerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Designers",
                columns: new[] { "DesignerId", "Email", "First Name", "Last Name" },
                values: new object[,]
                {
                    { 1, "eschall@calliopezoisite.com", "Elia", "Schall" },
                    { 2, "rlinder@calliopezoisite.com", "Romy", "Linder" },
                    { 3, "hkarlen@calliopezoisite.com", "Hugo", "Karlen" },
                    { 4, "efelix@calliopezoisite.com", "Elinora", "Felix" },
                    { 5, "tabeline@calliopezoisite.com", "Tessa", "Abeline" }
                });

            migrationBuilder.InsertData(
                table: "Seasons",
                columns: new[] { "SeasonId", "Name" },
                values: new object[,]
                {
                    { "F", "Fall/Winter" },
                    { "S", "Spring/Summer" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "DesignerId", "Name", "SeasonId", "Type", "Year" },
                values: new object[,]
                {
                    { 1, 3, "Caviar Dreams Asymmetrical", "S", "Skirt", 2022 },
                    { 2, 2, "Effervescent Halter Wrap", "F", "Top", 2022 },
                    { 3, 5, "Nephilim Winged Bomber", "F", "Jacket", 2023 },
                    { 4, 1, "Counterculture Bootcut", "S", "Pants", 2024 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_DesignerId",
                table: "Products",
                column: "DesignerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SeasonId",
                table: "Products",
                column: "SeasonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Designers");

            migrationBuilder.DropTable(
                name: "Seasons");
        }
    }
}
