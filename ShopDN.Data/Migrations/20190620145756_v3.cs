using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopDN.Data.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_ParentCategoryId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_ParentCategoryId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                table: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Category_IdParentCategory",
                table: "Category",
                column: "IdParentCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_IdParentCategory",
                table: "Category",
                column: "IdParentCategory",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_IdParentCategory",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_IdParentCategory",
                table: "Category");

            migrationBuilder.AddColumn<int>(
                name: "ParentCategoryId",
                table: "Category",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryId",
                table: "Category",
                column: "ParentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_ParentCategoryId",
                table: "Category",
                column: "ParentCategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
