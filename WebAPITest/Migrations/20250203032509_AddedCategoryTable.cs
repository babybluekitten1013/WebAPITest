using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPITest.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Content");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Content",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Content_CategoryId",
                table: "Content",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Content_Category_CategoryId",
                table: "Content",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Content_Category_CategoryId",
                table: "Content");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Content_CategoryId",
                table: "Content");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Content");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Content",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
