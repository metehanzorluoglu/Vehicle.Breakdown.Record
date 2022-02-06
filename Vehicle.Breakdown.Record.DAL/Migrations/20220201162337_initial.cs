using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleBreakdownRecord.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreakdownLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    BreakdownName = table.Column<string>(type: "nvarchar", maxLength: 50, nullable: false),
                    IsValid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakdownLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    VehicleName = table.Column<string>(type: "nvarchar", maxLength: 50, nullable: false),
                    VehicleOwnerName = table.Column<string>(type: "nvarchar", maxLength: 50, nullable: false),
                    VehicleOwnerLastname = table.Column<string>(type: "nvarchar", maxLength: 50, nullable: false),
                    VehicleOwnerPhone = table.Column<string>(type: "nvarchar", maxLength: 15, nullable: false),
                    VehicleChassisNumber = table.Column<string>(type: "nvarchar", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    DeleteDate = table.Column<DateTime>(nullable: true),
                    Comment = table.Column<string>(type: "nvarchar", maxLength: 250, nullable: false),
                    VehicleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleComments_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleComments_VehicleId",
                table: "VehicleComments",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreakdownLists");

            migrationBuilder.DropTable(
                name: "VehicleComments");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
