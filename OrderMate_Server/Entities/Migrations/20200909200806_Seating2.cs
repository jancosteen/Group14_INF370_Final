using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Seating2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c788b4a-2dd0-40d5-a386-3536eaf23e8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0173d26-8965-4174-9da1-561c8d2805a7");

            migrationBuilder.DropColumn(
                name: "SeatingTime",
                table: "Seating");
           /*
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f350ae72-afdb-4bda-a06f-c8ef05530137", "4c79e162-a3ef-401c-bdca-91e5965ae101", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "713f0e57-318a-4476-b1a9-106277bb0a4b", "c4660d36-2411-40bc-94e6-320256052a3f", "Administrator", "ADMINISTRATOR" });
       */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "713f0e57-318a-4476-b1a9-106277bb0a4b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f350ae72-afdb-4bda-a06f-c8ef05530137");

            migrationBuilder.AddColumn<string>(
                name: "SeatingTime",
                table: "Seating",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b0173d26-8965-4174-9da1-561c8d2805a7", "089aaaf1-0d76-4e30-80d3-2fd6c76a204d", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c788b4a-2dd0-40d5-a386-3536eaf23e8b", "cdd13b8e-663d-496c-a872-c71b3b017da3", "Administrator", "ADMINISTRATOR" });
        }
    }
}
