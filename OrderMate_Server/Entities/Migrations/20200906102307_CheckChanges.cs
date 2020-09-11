using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class CheckChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "903a0625-c389-4846-87e0-7b9f9fac185a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6f160b9-302f-421e-a1c4-72d7a5658ff5");

            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "UserRole1" },
                values: new object[] { "b23ab7a1-f53c-4ef9-9e0c-4c5274af6624", "acf9cd21-6f07-4516-8dbe-975723decc12", "UserRole", "Visitor", "VISITOR", "Visitor" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "UserRole1" },
                values: new object[] { "47bb94b9-50b8-4fec-b7ff-613574b3a816", "ef9777ae-5cf7-4560-87a6-e39bf60c21fd", "UserRole", "Administrator", "ADMINISTRATOR", "Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47bb94b9-50b8-4fec-b7ff-613574b3a816");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b23ab7a1-f53c-4ef9-9e0c-4c5274af6624");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "UserRole1" },
                values: new object[] { "903a0625-c389-4846-87e0-7b9f9fac185a", "cbe479b3-749b-4f07-8931-43b3cea3d0d5", "UserRole", "Visitor", "VISITOR", "Visitor" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "UserRole1" },
                values: new object[] { "c6f160b9-302f-421e-a1c4-72d7a5658ff5", "7832ac0f-b270-4a8c-9ff7-6d423f3128fa", "UserRole", "Administrator", "ADMINISTRATOR", "Administrator" });
        }
    }
}
