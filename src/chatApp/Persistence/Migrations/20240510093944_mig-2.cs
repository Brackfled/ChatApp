using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("09cfce53-77ef-48bd-bc15-05ce7665ff05"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20d5598d-ae53-4dd0-bcca-054cd6006f5d"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("4d303260-51fa-4781-8829-246602742b85"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "", "", new byte[] { 109, 152, 165, 22, 223, 162, 107, 109, 188, 169, 126, 126, 99, 250, 85, 225, 81, 2, 132, 234, 146, 55, 117, 54, 138, 81, 183, 191, 195, 18, 242, 44, 204, 57, 55, 237, 178, 27, 6, 62, 201, 216, 113, 175, 31, 225, 122, 238, 206, 9, 27, 139, 76, 25, 136, 190, 135, 52, 192, 24, 80, 92, 126, 97 }, new byte[] { 131, 130, 204, 247, 125, 197, 81, 69, 159, 253, 24, 226, 221, 168, 195, 22, 204, 42, 100, 115, 228, 61, 74, 32, 80, 58, 254, 68, 214, 94, 92, 28, 16, 71, 168, 219, 176, 40, 1, 211, 145, 15, 128, 240, 109, 55, 4, 13, 244, 228, 47, 142, 50, 83, 155, 165, 90, 202, 227, 242, 173, 107, 239, 247, 136, 248, 239, 172, 152, 241, 154, 147, 36, 0, 138, 154, 101, 182, 229, 136, 116, 8, 31, 102, 48, 219, 15, 94, 231, 242, 34, 10, 102, 30, 122, 88, 217, 18, 35, 146, 107, 116, 38, 208, 66, 225, 243, 109, 240, 72, 215, 10, 0, 201, 177, 198, 108, 92, 4, 159, 164, 11, 223, 79, 214, 165, 177, 220 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("38a72e5d-e575-43ae-b59e-45e3b8fd25aa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("4d303260-51fa-4781-8829-246602742b85") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("38a72e5d-e575-43ae-b59e-45e3b8fd25aa"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4d303260-51fa-4781-8829-246602742b85"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("20d5598d-ae53-4dd0-bcca-054cd6006f5d"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 139, 198, 133, 167, 38, 245, 220, 252, 29, 134, 49, 103, 3, 233, 199, 42, 209, 165, 24, 213, 89, 200, 84, 165, 227, 14, 161, 19, 19, 52, 168, 124, 134, 86, 1, 110, 154, 57, 245, 136, 140, 67, 119, 237, 2, 112, 125, 170, 179, 71, 25, 149, 232, 113, 68, 184, 58, 73, 240, 117, 141, 200, 229, 74 }, new byte[] { 28, 58, 112, 145, 197, 88, 181, 237, 184, 187, 160, 70, 209, 77, 58, 13, 202, 217, 132, 122, 205, 210, 228, 95, 205, 154, 249, 39, 50, 129, 200, 12, 138, 196, 238, 36, 140, 31, 203, 95, 236, 147, 163, 206, 66, 188, 224, 110, 28, 120, 225, 212, 91, 170, 205, 164, 167, 116, 45, 204, 247, 162, 232, 10, 15, 49, 6, 245, 38, 140, 160, 137, 4, 21, 172, 231, 19, 204, 20, 178, 76, 124, 38, 7, 234, 192, 139, 102, 99, 175, 149, 51, 90, 203, 19, 143, 9, 54, 212, 12, 17, 215, 103, 110, 85, 6, 130, 184, 83, 137, 152, 240, 190, 131, 188, 33, 55, 15, 187, 46, 114, 119, 217, 64, 137, 9, 99, 176 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("09cfce53-77ef-48bd-bc15-05ce7665ff05"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("20d5598d-ae53-4dd0-bcca-054cd6006f5d") });
        }
    }
}
