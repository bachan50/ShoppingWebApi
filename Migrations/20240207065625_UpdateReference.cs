using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingWebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product_Id",
                table: "order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Product_Id",
                table: "order",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
