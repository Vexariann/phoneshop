using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoneshop.Data.Migrations
{
    public partial class AddBrand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Phones");

            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "Phones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phones_BrandID",
                table: "Phones",
                column: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Brands_BrandID",
                table: "Phones",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Brands_BrandID",
                table: "Phones");

            migrationBuilder.DropIndex(
                name: "IX_Phones_BrandID",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "Phones");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Phones",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
