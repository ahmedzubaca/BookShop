using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShopWebb.Migrations
{
    public partial class CorrectedOrderStatusandTrackingNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrakingNumber",
                table: "OrderHeaders",
                newName: "TrackingNumber");

            migrationBuilder.RenameColumn(
                name: "OrgerStatus",
                table: "OrderHeaders",
                newName: "OrderStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrackingNumber",
                table: "OrderHeaders",
                newName: "TrakingNumber");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "OrderHeaders",
                newName: "OrgerStatus");
        }
    }
}
