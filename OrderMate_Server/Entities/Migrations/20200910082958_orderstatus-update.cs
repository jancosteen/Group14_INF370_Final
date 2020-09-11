using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class orderstatusupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97d8293b-e275-4f73-91b7-7760158068db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6a181d2-a51f-495c-bb56-d575f76c255d");

            migrationBuilder.DropColumn(
                name: "orderStatus",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "orderStatus1",
                table: "Order",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderStatus1",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "orderStatus",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97d8293b-e275-4f73-91b7-7760158068db", "fcc3065e-a459-47e3-b138-730e717b4905", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d6a181d2-a51f-495c-bb56-d575f76c255d", "b5638934-b2fe-4cb4-bba0-d2ca374a4339", "Administrator", "ADMINISTRATOR" });
        }
    }
}
