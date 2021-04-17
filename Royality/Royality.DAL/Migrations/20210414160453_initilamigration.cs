using Microsoft.EntityFrameworkCore.Migrations;

namespace Royality.DAL.Migrations
{
    public partial class initilamigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Watches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Size = table.Column<double>(nullable: false),
                    GuaranteePeriod = table.Column<double>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    ManufacturerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Watches_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Rolex" });

            migrationBuilder.InsertData(
                table: "Watches",
                columns: new[] { "Id", "GuaranteePeriod", "Location", "ManufacturerId", "ModelName", "Price", "Size" },
                values: new object[] { 1, 1.5, "Mirabad, Tashkent", 1, "Rolex 123", 25000.0m, 6.5 });

            migrationBuilder.CreateIndex(
                name: "IX_Watches_ManufacturerId",
                table: "Watches",
                column: "ManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Watches");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
