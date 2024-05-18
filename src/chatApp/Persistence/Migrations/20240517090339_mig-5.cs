using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6e2f6555-88a7-46ca-8c64-0a00fc826ae6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a71c601e-58fa-4c91-9f03-cbb61983eb5e"));

            migrationBuilder.DropColumn(
                name: "Users",
                table: "Chats");

            migrationBuilder.CreateTable(
                name: "ChatUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatUsers_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ChatUsers.Admin", null },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ChatUsers.Read", null },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ChatUsers.Write", null },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ChatUsers.Create", null },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ChatUsers.Update", null },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ChatUsers.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "ConnectionId", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("80459ca0-6f42-47e3-a80c-bf47541f9b2b"), 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "", "", new byte[] { 122, 144, 91, 13, 77, 45, 187, 187, 243, 96, 8, 4, 120, 161, 5, 51, 38, 100, 50, 96, 64, 45, 47, 173, 158, 5, 167, 34, 58, 247, 152, 207, 229, 170, 64, 45, 229, 23, 25, 54, 249, 241, 167, 78, 147, 131, 208, 28, 230, 114, 5, 135, 110, 20, 75, 111, 75, 202, 17, 3, 28, 213, 146, 156 }, new byte[] { 83, 250, 70, 140, 137, 77, 72, 73, 50, 228, 4, 190, 247, 151, 96, 80, 90, 38, 149, 195, 141, 141, 87, 17, 194, 63, 14, 99, 25, 232, 142, 16, 151, 29, 124, 154, 57, 127, 239, 117, 101, 225, 166, 130, 255, 197, 120, 164, 118, 96, 111, 137, 57, 57, 147, 120, 11, 152, 146, 93, 202, 240, 187, 15, 200, 246, 155, 116, 201, 117, 162, 17, 130, 160, 6, 164, 86, 108, 99, 35, 19, 186, 120, 93, 244, 37, 210, 59, 172, 1, 57, 178, 234, 190, 246, 15, 218, 94, 164, 221, 217, 178, 131, 81, 121, 183, 160, 218, 201, 101, 33, 215, 58, 53, 23, 63, 115, 32, 218, 131, 7, 224, 254, 88, 180, 125, 38, 11 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("c175d9a7-3663-4117-960b-3861fc59e836"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("80459ca0-6f42-47e3-a80c-bf47541f9b2b") });

            migrationBuilder.CreateIndex(
                name: "IX_ChatUsers_ChatId",
                table: "ChatUsers",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatUsers_UserId",
                table: "ChatUsers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatUsers");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c175d9a7-3663-4117-960b-3861fc59e836"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("80459ca0-6f42-47e3-a80c-bf47541f9b2b"));

            migrationBuilder.AddColumn<string>(
                name: "Users",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "ConnectionId", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("a71c601e-58fa-4c91-9f03-cbb61983eb5e"), 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "", "", new byte[] { 129, 242, 85, 115, 142, 93, 77, 178, 65, 25, 160, 121, 136, 191, 177, 130, 175, 167, 40, 182, 39, 44, 145, 0, 71, 92, 244, 122, 34, 197, 30, 215, 148, 12, 64, 85, 5, 20, 186, 247, 188, 164, 11, 115, 10, 245, 212, 233, 57, 97, 0, 93, 13, 156, 61, 165, 115, 13, 201, 232, 79, 242, 81, 228 }, new byte[] { 48, 20, 56, 78, 92, 203, 39, 253, 222, 145, 157, 63, 25, 6, 206, 27, 201, 145, 163, 75, 248, 42, 159, 194, 76, 239, 49, 214, 129, 36, 149, 122, 246, 6, 122, 44, 211, 187, 70, 16, 172, 187, 30, 111, 67, 26, 201, 211, 96, 199, 125, 48, 39, 73, 119, 85, 200, 218, 183, 66, 33, 15, 171, 202, 197, 230, 137, 69, 241, 122, 37, 33, 52, 245, 173, 61, 247, 46, 63, 158, 101, 101, 215, 253, 254, 112, 177, 248, 158, 20, 141, 31, 126, 152, 205, 56, 224, 75, 23, 82, 241, 111, 140, 29, 233, 5, 227, 40, 93, 207, 55, 21, 123, 102, 152, 96, 63, 172, 140, 239, 106, 111, 188, 198, 96, 142, 252, 163 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("6e2f6555-88a7-46ca-8c64-0a00fc826ae6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("a71c601e-58fa-4c91-9f03-cbb61983eb5e") });
        }
    }
}
