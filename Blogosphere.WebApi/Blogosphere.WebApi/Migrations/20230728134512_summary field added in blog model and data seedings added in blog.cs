using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blogosphere.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class summaryfieldaddedinblogmodelanddataseedingsaddedinblog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Summary",
                value: "summary");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Summary",
                value: "summary");

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Content", "LargeImageUrl", "SmallImageUrl", "Summary", "Title", "UserId" },
                values: new object[,]
                {
                    { 3, "Blog 3 Description", "https://via.placeholder.com/350", "https://via.placeholder.com/150", "summary", "Blog 3", 2 },
                    { 4, "Blog 4 Description", "https://via.placeholder.com/350", "https://via.placeholder.com/150", "summary", "Blog 4", 2 },
                    { 5, "Blog 5 Description", "https://via.placeholder.com/350", "https://via.placeholder.com/150", "summary", "Blog 5", 3 },
                    { 6, "Blog 6 Description", "https://via.placeholder.com/350", "https://via.placeholder.com/150", "summary", "Blog 6", 3 },
                    { 7, "Blog 7 Description", "https://via.placeholder.com/350", "https://via.placeholder.com/150", "summary", "Blog 7", 4 },
                    { 8, "Blog 8 Description", "https://via.placeholder.com/350", "https://via.placeholder.com/150", "summary", "Blog 8", 4 },
                    { 9, "Blog 9 Description", "https://via.placeholder.com/350", "https://via.placeholder.com/150", "summary", "Blog 9", 5 },
                    { 10, "Blog 10 Description", "https://via.placeholder.com/350", "https://via.placeholder.com/150", "summary", "Blog 10", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Blogs");
        }
    }
}
