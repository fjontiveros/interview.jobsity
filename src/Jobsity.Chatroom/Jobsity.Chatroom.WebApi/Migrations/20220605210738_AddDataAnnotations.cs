using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobsity.Chatroom.WebApi.Migrations
{
    public partial class AddDataAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
