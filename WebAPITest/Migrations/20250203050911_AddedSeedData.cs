using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPITest.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Food" },
                    { 2, "Tech" },
                    { 3, "News" },
                    { 4, "Tacos" }
                });

            migrationBuilder.InsertData(
                table: "Content",
                columns: new[] { "ContentId", "Author", "Body", "CategoryId", "CreatedAt", "LastModifiedAt", "Title", "Visibility" },
                values: new object[] { 1, "Author", "Title", 3, new DateTime(2025, 2, 2, 21, 9, 11, 193, DateTimeKind.Local).AddTicks(1846), new DateTime(2025, 2, 2, 21, 9, 11, 193, DateTimeKind.Local).AddTicks(1888), "Title", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Content",
                keyColumn: "ContentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3);
        }
    }
}
