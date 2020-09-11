using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5baad1c4-7626-43a5-923d-894f0f899163");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff04fe0c-8d0f-41e3-a4a4-fcbb50bbbbfd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aa507de3-94cf-4209-9e41-a2a0c1117da0", "1de49c3b-3e31-4b5a-921d-3a7036d5d2f0", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64db2841-861b-4d4f-87f9-bfb179e28304", "79a30c9c-ac58-4959-b801-1b2522e31157", "Administrator", "ADMINISTRATOR" });
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64db2841-861b-4d4f-87f9-bfb179e28304");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa507de3-94cf-4209-9e41-a2a0c1117da0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff04fe0c-8d0f-41e3-a4a4-fcbb50bbbbfd", "e1892ad2-42a9-41d2-a916-096fbb9edd81", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5baad1c4-7626-43a5-923d-894f0f899163", "f61f9c39-fb80-4b51-bb77-aca7084f0851", "Administrator", "ADMINISTRATOR" });
        }
    }
}
