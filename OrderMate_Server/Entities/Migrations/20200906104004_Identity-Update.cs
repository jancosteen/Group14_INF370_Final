using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class IdentityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "User_User_Role_FK",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_User_Role_Id_FK",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47bb94b9-50b8-4fec-b7ff-613574b3a816");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b23ab7a1-f53c-4ef9-9e0c-4c5274af6624");

            migrationBuilder.DropColumn(
                name: "User_Role_Id_FK",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserRole1",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5444325a-870a-4629-b9b4-708c004584f7", "28a36df0-2813-4768-bdfe-0609ff4b21f9", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c5e2910-d104-4afb-a7ce-76972894713c", "ae0ba015-0303-4b31-a31a-dc3bae66724d", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c5e2910-d104-4afb-a7ce-76972894713c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5444325a-870a-4629-b9b4-708c004584f7");

            migrationBuilder.AddColumn<string>(
                name: "User_Role_Id_FK",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserRole1",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "UserRole1" },
                values: new object[] { "b23ab7a1-f53c-4ef9-9e0c-4c5274af6624", "acf9cd21-6f07-4516-8dbe-975723decc12", "UserRole", "Visitor", "VISITOR", "Visitor" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName", "UserRole1" },
                values: new object[] { "47bb94b9-50b8-4fec-b7ff-613574b3a816", "ef9777ae-5cf7-4560-87a6-e39bf60c21fd", "UserRole", "Administrator", "ADMINISTRATOR", "Administrator" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_User_Role_Id_FK",
                table: "AspNetUsers",
                column: "User_Role_Id_FK");

            migrationBuilder.AddForeignKey(
                name: "User_User_Role_FK",
                table: "AspNetUsers",
                column: "User_Role_Id_FK",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
