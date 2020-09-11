using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class orderupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c5e2910-d104-4afb-a7ce-76972894713c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5444325a-870a-4629-b9b4-708c004584f7");

            migrationBuilder.AddColumn<int>(
                name: "orderStatus",
                table: "Order",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5444325a-870a-4629-b9b4-708c004584f7", "28a36df0-2813-4768-bdfe-0609ff4b21f9", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c5e2910-d104-4afb-a7ce-76972894713c", "ae0ba015-0303-4b31-a31a-dc3bae66724d", "Administrator", "ADMINISTRATOR" });
        }
    }
}
