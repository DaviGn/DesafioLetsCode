using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rebel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GalaxyName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ReportCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rebel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RebelInventory",
                columns: table => new
                {
                    RebelId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RebelInventory", x => new { x.RebelId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_RebelInventory_InventoryItem_ItemId",
                        column: x => x.ItemId,
                        principalTable: "InventoryItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RebelInventory_Rebel_RebelId",
                        column: x => x.RebelId,
                        principalTable: "Rebel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "InventoryItem",
                columns: new[] { "Id", "Name", "Points" },
                values: new object[,]
                {
                    { 1, "Arma", 4 },
                    { 2, "Munição", 3 },
                    { 3, "Água", 2 },
                    { 4, "Comida", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RebelInventory_ItemId",
                table: "RebelInventory",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RebelInventory");

            migrationBuilder.DropTable(
                name: "InventoryItem");

            migrationBuilder.DropTable(
                name: "Rebel");
        }
    }
}
