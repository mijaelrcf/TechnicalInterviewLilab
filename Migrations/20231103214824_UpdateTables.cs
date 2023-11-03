using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechTestAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HistoryStocks_ProductId",
                table: "HistoryStocks");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryStocks_ProductId",
                table: "HistoryStocks",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HistoryStocks_ProductId",
                table: "HistoryStocks");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryStocks_ProductId",
                table: "HistoryStocks",
                column: "ProductId",
                unique: true);
        }
    }
}
