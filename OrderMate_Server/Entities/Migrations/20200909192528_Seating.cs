using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Seating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Order_Status_Order_FK",
                table: "Order_Status");

            migrationBuilder.DropIndex(
                name: "IX_Order_Status_Order_Id_FK",
                table: "Order_Status");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64db2841-861b-4d4f-87f9-bfb179e28304");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa507de3-94cf-4209-9e41-a2a0c1117da0");

           /* migrationBuilder.DropColumn(
                name: "orderStatus",
                table: "Order");*/

            migrationBuilder.AlterColumn<string>(
                name: "SeatingTime",
                table: "Seating",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<int>(
                name: "OrderIdFkNavigationOrderId",
                table: "Order_Status",
                nullable: true);
            /*
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b0173d26-8965-4174-9da1-561c8d2805a7", "089aaaf1-0d76-4e30-80d3-2fd6c76a204d", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c788b4a-2dd0-40d5-a386-3536eaf23e8b", "cdd13b8e-663d-496c-a872-c71b3b017da3", "Administrator", "ADMINISTRATOR" });
            */
            migrationBuilder.CreateIndex(
                name: "IX_Order_Status_OrderIdFkNavigationOrderId",
                table: "Order_Status",
                column: "OrderIdFkNavigationOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Status_Order_OrderIdFkNavigationOrderId",
                table: "Order_Status",
                column: "OrderIdFkNavigationOrderId",
                principalTable: "Order",
                principalColumn: "Order_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Status_Order_OrderIdFkNavigationOrderId",
                table: "Order_Status");

            migrationBuilder.DropIndex(
                name: "IX_Order_Status_OrderIdFkNavigationOrderId",
                table: "Order_Status");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c788b4a-2dd0-40d5-a386-3536eaf23e8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0173d26-8965-4174-9da1-561c8d2805a7");

            migrationBuilder.DropColumn(
                name: "OrderIdFkNavigationOrderId",
                table: "Order_Status");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "SeatingTime",
                table: "Seating",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "orderStatus",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aa507de3-94cf-4209-9e41-a2a0c1117da0", "1de49c3b-3e31-4b5a-921d-3a7036d5d2f0", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64db2841-861b-4d4f-87f9-bfb179e28304", "79a30c9c-ac58-4959-b801-1b2522e31157", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_Status_Order_Id_FK",
                table: "Order_Status",
                column: "Order_Id_FK");

            migrationBuilder.AddForeignKey(
                name: "Order_Status_Order_FK",
                table: "Order_Status",
                column: "Order_Id_FK",
                principalTable: "Order",
                principalColumn: "Order_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
