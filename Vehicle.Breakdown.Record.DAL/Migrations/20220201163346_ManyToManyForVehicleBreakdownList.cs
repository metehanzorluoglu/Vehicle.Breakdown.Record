using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleBreakdownRecord.DAL.Migrations
{
    public partial class ManyToManyForVehicleBreakdownList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleBreakdownLists",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false),
                    BreakdowListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBreakdownLists", x => new { x.VehicleId, x.BreakdowListId });
                    table.ForeignKey(
                        name: "FK_VehicleBreakdownLists_BreakdownLists_BreakdowListId",
                        column: x => x.BreakdowListId,
                        principalTable: "BreakdownLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleBreakdownLists_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBreakdownLists_BreakdowListId",
                table: "VehicleBreakdownLists",
                column: "BreakdowListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleBreakdownLists");
        }
    }
}
