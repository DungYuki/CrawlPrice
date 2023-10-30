using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetPriceUrl.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToLaptopURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LaptopURL",
                columns: table => new
                {
                    LaptopURLID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaptopID = table.Column<int>(type: "int", nullable: true),
                    WebsiteID = table.Column<int>(type: "int", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaptopURL", x => x.LaptopURLID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaptopURL");
        }
    }
}
