using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("38a72e5d-e575-43ae-b59e-45e3b8fd25aa"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4d303260-51fa-4781-8829-246602742b85"));

            migrationBuilder.AddColumn<string>(
                name: "ConnectionId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Users = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Messages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chats.Admin", null },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chats.Read", null },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chats.Write", null },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chats.Create", null },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chats.Update", null },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Chats.Delete", null },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Groups.Admin", null },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Groups.Read", null },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Groups.Write", null },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Groups.Create", null },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Groups.Update", null },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Groups.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "ConnectionId", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("a71c601e-58fa-4c91-9f03-cbb61983eb5e"), 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "", "", new byte[] { 129, 242, 85, 115, 142, 93, 77, 178, 65, 25, 160, 121, 136, 191, 177, 130, 175, 167, 40, 182, 39, 44, 145, 0, 71, 92, 244, 122, 34, 197, 30, 215, 148, 12, 64, 85, 5, 20, 186, 247, 188, 164, 11, 115, 10, 245, 212, 233, 57, 97, 0, 93, 13, 156, 61, 165, 115, 13, 201, 232, 79, 242, 81, 228 }, new byte[] { 48, 20, 56, 78, 92, 203, 39, 253, 222, 145, 157, 63, 25, 6, 206, 27, 201, 145, 163, 75, 248, 42, 159, 194, 76, 239, 49, 214, 129, 36, 149, 122, 246, 6, 122, 44, 211, 187, 70, 16, 172, 187, 30, 111, 67, 26, 201, 211, 96, 199, 125, 48, 39, 73, 119, 85, 200, 218, 183, 66, 33, 15, 171, 202, 197, 230, 137, 69, 241, 122, 37, 33, 52, 245, 173, 61, 247, 46, 63, 158, 101, 101, 215, 253, 254, 112, 177, 248, 158, 20, 141, 31, 126, 152, 205, 56, 224, 75, 23, 82, 241, 111, 140, 29, 233, 5, 227, 40, 93, 207, 55, 21, 123, 102, 152, 96, 63, 172, 140, 239, 106, 111, 188, 198, 96, 142, 252, 163 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("6e2f6555-88a7-46ca-8c64-0a00fc826ae6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("a71c601e-58fa-4c91-9f03-cbb61983eb5e") });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ChatId",
                table: "Groups",
                column: "ChatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6e2f6555-88a7-46ca-8c64-0a00fc826ae6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a71c601e-58fa-4c91-9f03-cbb61983eb5e"));

            migrationBuilder.DropColumn(
                name: "ConnectionId",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("4d303260-51fa-4781-8829-246602742b85"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "", "", new byte[] { 109, 152, 165, 22, 223, 162, 107, 109, 188, 169, 126, 126, 99, 250, 85, 225, 81, 2, 132, 234, 146, 55, 117, 54, 138, 81, 183, 191, 195, 18, 242, 44, 204, 57, 55, 237, 178, 27, 6, 62, 201, 216, 113, 175, 31, 225, 122, 238, 206, 9, 27, 139, 76, 25, 136, 190, 135, 52, 192, 24, 80, 92, 126, 97 }, new byte[] { 131, 130, 204, 247, 125, 197, 81, 69, 159, 253, 24, 226, 221, 168, 195, 22, 204, 42, 100, 115, 228, 61, 74, 32, 80, 58, 254, 68, 214, 94, 92, 28, 16, 71, 168, 219, 176, 40, 1, 211, 145, 15, 128, 240, 109, 55, 4, 13, 244, 228, 47, 142, 50, 83, 155, 165, 90, 202, 227, 242, 173, 107, 239, 247, 136, 248, 239, 172, 152, 241, 154, 147, 36, 0, 138, 154, 101, 182, 229, 136, 116, 8, 31, 102, 48, 219, 15, 94, 231, 242, 34, 10, 102, 30, 122, 88, 217, 18, 35, 146, 107, 116, 38, 208, 66, 225, 243, 109, 240, 72, 215, 10, 0, 201, 177, 198, 108, 92, 4, 159, 164, 11, 223, 79, 214, 165, 177, 220 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("38a72e5d-e575-43ae-b59e-45e3b8fd25aa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("4d303260-51fa-4781-8829-246602742b85") });
        }
    }
}
