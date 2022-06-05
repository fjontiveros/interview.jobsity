using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobsity.Chatroom.WebApi.Migrations
{
    public partial class HashPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("dc7c9c85-b4af-42f9-9646-c7c7ee0d7324"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8b2294a2-454f-45ea-b064-d39d1fbdfac4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b995314b-2c49-4b87-919b-58cbb5cd3f91"));

            migrationBuilder.InsertData(
                table: "Chatrooms",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[] { new Guid("c69b9bf2-477c-437d-b1b3-33736cc2123b"), new DateTime(2022, 6, 5, 19, 1, 34, 654, DateTimeKind.Local).AddTicks(4745), "Chatroom 1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[] { new Guid("62181887-1b02-4f57-8922-6bf3021a2459"), "user2", "a2FpcUtBUzY1MTEyLTFrbJfLJVJXdqn9noF3GwDzW/kF7QQ8" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[] { new Guid("e9b5dce3-413e-431a-84d0-c5e056ab2a24"), "user1", "a2FpcUtBUzY1MTEyLTFrbJfLJVJXdqn9noF3GwDzW/kF7QQ8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("c69b9bf2-477c-437d-b1b3-33736cc2123b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62181887-1b02-4f57-8922-6bf3021a2459"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e9b5dce3-413e-431a-84d0-c5e056ab2a24"));

            migrationBuilder.InsertData(
                table: "Chatrooms",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[] { new Guid("dc7c9c85-b4af-42f9-9646-c7c7ee0d7324"), new DateTime(2022, 6, 5, 18, 7, 38, 266, DateTimeKind.Local).AddTicks(2289), "Chatroom 1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[] { new Guid("8b2294a2-454f-45ea-b064-d39d1fbdfac4"), "user2", "123456" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[] { new Guid("b995314b-2c49-4b87-919b-58cbb5cd3f91"), "user1", "123456" });
        }
    }
}
