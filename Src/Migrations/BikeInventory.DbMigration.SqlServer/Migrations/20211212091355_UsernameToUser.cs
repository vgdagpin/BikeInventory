using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeInventory.DbMigration.SqlServer.Migrations
{
    public partial class UsernameToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                schema: "dbo",
                table: "tbl_UserCredential");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "tbl_User",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                schema: "dbo",
                table: "tbl_User",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "tbl_User",
                keyColumn: "ID",
                keyValue: -1,
                column: "Email",
                value: "admin@bike.com");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "tbl_User",
                keyColumn: "ID",
                keyValue: 1,
                column: "Email",
                value: "staff1@bike.com");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "tbl_User",
                keyColumn: "ID",
                keyValue: 2,
                column: "Email",
                value: "staff2@bike.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "dbo",
                table: "tbl_User");

            migrationBuilder.DropColumn(
                name: "Username",
                schema: "dbo",
                table: "tbl_User");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                schema: "dbo",
                table: "tbl_UserCredential",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "tbl_UserCredential",
                keyColumn: "ID",
                keyValue: -1,
                column: "Username",
                value: "admin@bike.com");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "tbl_UserCredential",
                keyColumn: "ID",
                keyValue: 1,
                column: "Username",
                value: "staff1@bike.com");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "tbl_UserCredential",
                keyColumn: "ID",
                keyValue: 2,
                column: "Username",
                value: "staff2@bike.com");
        }
    }
}
