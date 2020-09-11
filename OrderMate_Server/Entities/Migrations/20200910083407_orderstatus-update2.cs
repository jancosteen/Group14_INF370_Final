using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class orderstatusupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a6cecabe-f5e7-414b-ad89-01749121472a", "e185c758-65bf-45c4-9b05-efa106f29caf", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e2158619-dd22-49cb-b6c1-5cdb86c3024e", "c1e05f1e-5bdc-4657-8d41-5c1932aabcda", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6cecabe-f5e7-414b-ad89-01749121472a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2158619-dd22-49cb-b6c1-5cdb86c3024e");
        }
    }
}
