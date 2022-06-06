using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobsity.Chatroom.WebApi.Migrations
{
    public partial class AddBotUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("56f67c8d-9233-4c0a-8326-c6e252ea15e7"), new DateTime(2022, 6, 6, 19, 53, 55, 916, DateTimeKind.Local).AddTicks(3175), "Chatroom 1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("2aad878b-6c32-4a34-a0bc-59d651b60546"), "user2", "a2FpcUtBUzY1MTEyLTFrbJfLJVJXdqn9noF3GwDzW/kF7QQ8" },
                    { new Guid("5ab9570a-80fa-43a4-adb7-2aea3e64ebf5"), "user1", "a2FpcUtBUzY1MTEyLTFrbJfLJVJXdqn9noF3GwDzW/kF7QQ8" },
                    { new Guid("6bf7ef1e-64ea-4888-83d3-2e7d89c98b72"), "botUser", "a2FpcUtBUzY1MTEyLTFrbJfLJVJXdqn9noF3GwDzW/kF7QQ8" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chatrooms",
                keyColumn: "Id",
                keyValue: new Guid("56f67c8d-9233-4c0a-8326-c6e252ea15e7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2aad878b-6c32-4a34-a0bc-59d651b60546"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5ab9570a-80fa-43a4-adb7-2aea3e64ebf5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6bf7ef1e-64ea-4888-83d3-2e7d89c98b72"));

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
    }
}
