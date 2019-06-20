using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopDN.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdParentCategory",
                table: "Category",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdParentCategory",
                table: "Category",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
