using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeInventory.DbMigration.SqlServer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "tbl_BikeModel",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_BikeModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Customer",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PaymentHandler",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LongDesc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TaskAssembly = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TaskClass = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    HandlerAssembly = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    HandlerClass = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PaymentHandler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PaymentHandlerSetting",
                schema: "dbo",
                columns: table => new
                {
                    Environment = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PaymentHandlerSetting", x => new { x.Environment, x.Type, x.Code });
                });

            migrationBuilder.CreateTable(
                name: "tbl_User",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserCredit",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    RecordStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Credit = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserCredit", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Bike",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelID = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Bike", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_Bike_tbl_BikeModel_ModelID",
                        column: x => x.ModelID,
                        principalSchema: "dbo",
                        principalTable: "tbl_BikeModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserCredential",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FailedLoginCount = table.Column<int>(type: "int", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsTemporaryPassword = table.Column<bool>(type: "bit", nullable: false),
                    TemporaryPassword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserCredential", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_UserCredential_tbl_User_ID",
                        column: x => x.ID,
                        principalSchema: "dbo",
                        principalTable: "tbl_User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserRole",
                schema: "dbo",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    ExpireOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserRole", x => new { x.UserID, x.Role });
                    table.ForeignKey(
                        name: "FK_tbl_UserRole_tbl_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "dbo",
                        principalTable: "tbl_User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_BikeRate",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikeID = table.Column<int>(type: "int", nullable: false),
                    RatePerMinute = table.Column<decimal>(type: "DECIMAL(20,6)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_BikeRate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_BikeRate_tbl_Bike_BikeID",
                        column: x => x.BikeID,
                        principalSchema: "dbo",
                        principalTable: "tbl_Bike",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RentalTransaction",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BikeID = table.Column<int>(type: "int", nullable: false),
                    BikeRateID = table.Column<int>(type: "int", nullable: false),
                    AttendantID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CheckedOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckedIn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RentalTransaction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_RentalTransaction_tbl_Bike_BikeID",
                        column: x => x.BikeID,
                        principalSchema: "dbo",
                        principalTable: "tbl_Bike",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_tbl_RentalTransaction_tbl_BikeRate_BikeRateID",
                        column: x => x.BikeRateID,
                        principalSchema: "dbo",
                        principalTable: "tbl_BikeRate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_RentalTransaction_tbl_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "dbo",
                        principalTable: "tbl_Customer",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_tbl_RentalTransaction_tbl_User_AttendantID",
                        column: x => x.AttendantID,
                        principalSchema: "dbo",
                        principalTable: "tbl_User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tbl_Receipt",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalTransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Receipt", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_Receipt_tbl_RentalTransaction_RentalTransactionID",
                        column: x => x.RentalTransactionID,
                        principalSchema: "dbo",
                        principalTable: "tbl_RentalTransaction",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tbl_BikeModel",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { (short)1, "A1" },
                    { (short)2, "A2" },
                    { (short)3, "A3" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tbl_Customer",
                columns: new[] { "ID", "FirstName", "LastName", "MiddleName" },
                values: new object[] { 1, "Customer", "A", null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tbl_PaymentHandler",
                columns: new[] { "ID", "HandlerAssembly", "HandlerClass", "IsActive", "LongDesc", "ShortDesc", "TaskAssembly", "TaskClass" },
                values: new object[,]
                {
                    { (short)1, "BikeInventory.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "BikeInventory.Application.Handlers.Commands.PaymentCmds.PaymentCmdHandler_GCash", true, "GCash", "GCash", "BikeInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "BikeInventory.Commands.PaymentCmds.PaymentCmd" },
                    { (short)2, "BikeInventory.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "BikeInventory.Application.Handlers.Commands.PaymentCmds.PaymentCmdHandler_Paymaya", true, "Paymaya", "Paymaya", "BikeInventory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "BikeInventory.Commands.PaymentCmds.PaymentCmd" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tbl_PaymentHandlerSetting",
                columns: new[] { "Code", "Environment", "Type", "Value" },
                values: new object[,]
                {
                    { "Url", "Dev", "PSC_GCash", "https://localhost:44357" },
                    { "Url", "Dev", "PSC_Paymaya", "https://localhost:44343" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tbl_User",
                columns: new[] { "ID", "Email", "FirstName", "LastName", "MiddleName", "Username" },
                values: new object[,]
                {
                    { -1, "admin@bike.com", "Super", "Admin", null, null },
                    { 1, "staff1@bike.com", "User", "Staff 1", null, null },
                    { 2, "staff2@bike.com", "User", "Staff 2", null, null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tbl_Bike",
                columns: new[] { "ID", "ModelID", "Status" },
                values: new object[,]
                {
                    { 1, (short)1, "Available" },
                    { 2, (short)1, "Available" },
                    { 3, (short)1, "Available" },
                    { 4, (short)1, "Available" },
                    { 5, (short)1, "Available" },
                    { 6, (short)2, "Available" },
                    { 7, (short)2, "Available" },
                    { 8, (short)2, "Available" },
                    { 9, (short)2, "Available" },
                    { 10, (short)2, "Available" },
                    { 11, (short)3, "Available" },
                    { 12, (short)3, "Available" },
                    { 13, (short)3, "Available" },
                    { 14, (short)3, "Available" },
                    { 15, (short)3, "Available" },
                    { 16, (short)3, "Available" },
                    { 17, (short)3, "Available" },
                    { 18, (short)3, "Available" },
                    { 19, (short)3, "Available" },
                    { 20, (short)3, "Available" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tbl_UserCredential",
                columns: new[] { "ID", "ExpiresOn", "FailedLoginCount", "IsTemporaryPassword", "Password", "Salt", "TemporaryPassword" },
                values: new object[,]
                {
                    { -1, null, 0, true, new byte[] { 197, 40, 2, 90, 195, 172, 59, 213, 107, 18, 99, 83, 234, 145, 48, 189, 29, 176, 237, 67, 47, 52, 136, 9, 49, 71, 105, 191, 181, 159, 172, 16 }, new byte[] { 48, 48, 48, 48, 48, 48, 48, 48, 45, 48, 48, 48, 48, 45, 48, 48, 48, 48, 45, 48, 48, 48, 48, 45, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 49 }, "admin" },
                    { 1, null, 0, true, new byte[] { 90, 222, 117, 211, 129, 107, 119, 212, 114, 215, 46, 244, 111, 193, 91, 50, 203, 40, 111, 221, 232, 118, 35, 171, 190, 224, 194, 94, 137, 102, 121, 47 }, new byte[] { 48, 48, 48, 48, 48, 48, 48, 48, 45, 48, 48, 48, 48, 45, 48, 48, 48, 48, 45, 48, 48, 48, 48, 45, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 50 }, "staff1" },
                    { 2, null, 0, true, new byte[] { 165, 4, 10, 239, 119, 73, 236, 58, 52, 216, 234, 65, 60, 50, 223, 115, 7, 187, 190, 113, 118, 243, 224, 206, 147, 255, 240, 178, 214, 97, 168, 37 }, new byte[] { 48, 48, 48, 48, 48, 48, 48, 48, 45, 48, 48, 48, 48, 45, 48, 48, 48, 48, 45, 48, 48, 48, 48, 45, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 50 }, "staff2" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tbl_UserRole",
                columns: new[] { "Role", "UserID", "ExpireOn", "IsEnabled" },
                values: new object[,]
                {
                    { "admin", -1, null, true },
                    { "staff", 1, null, true },
                    { "staff", 2, null, true }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "tbl_BikeRate",
                columns: new[] { "ID", "BikeID", "IsActive", "RatePerMinute" },
                values: new object[,]
                {
                    { 1, 1, true, 0.25m },
                    { 2, 2, true, 0.25m },
                    { 3, 3, true, 0.25m },
                    { 4, 4, true, 0.25m },
                    { 5, 5, true, 0.25m },
                    { 6, 6, true, 0.25m },
                    { 7, 7, true, 0.25m },
                    { 8, 8, true, 0.25m },
                    { 9, 9, true, 0.25m },
                    { 10, 10, true, 0.25m },
                    { 11, 11, true, 0.25m },
                    { 12, 12, true, 0.25m },
                    { 13, 13, true, 0.25m },
                    { 14, 14, true, 0.25m },
                    { 15, 15, true, 0.25m },
                    { 16, 16, true, 0.25m },
                    { 17, 17, true, 0.25m },
                    { 18, 18, true, 0.25m },
                    { 19, 19, true, 0.25m },
                    { 20, 20, true, 0.25m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Bike_ModelID",
                schema: "dbo",
                table: "tbl_Bike",
                column: "ModelID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_BikeRate_BikeID",
                schema: "dbo",
                table: "tbl_BikeRate",
                column: "BikeID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Receipt_RentalTransactionID",
                schema: "dbo",
                table: "tbl_Receipt",
                column: "RentalTransactionID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RentalTransaction_AttendantID",
                schema: "dbo",
                table: "tbl_RentalTransaction",
                column: "AttendantID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RentalTransaction_BikeID",
                schema: "dbo",
                table: "tbl_RentalTransaction",
                column: "BikeID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RentalTransaction_BikeRateID",
                schema: "dbo",
                table: "tbl_RentalTransaction",
                column: "BikeRateID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_RentalTransaction_CustomerID",
                schema: "dbo",
                table: "tbl_RentalTransaction",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_PaymentHandler",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_PaymentHandlerSetting",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_Receipt",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_UserCredential",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_UserCredit",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_UserRole",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_RentalTransaction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_BikeRate",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_Customer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_Bike",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_BikeModel",
                schema: "dbo");
        }
    }
}
