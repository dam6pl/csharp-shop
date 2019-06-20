using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopDN.Data.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.RenameTable(
                name: "Options",
                newName: "Option");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Option",
                table: "Option",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Option",
                table: "Option");

            migrationBuilder.RenameTable(
                name: "Option",
                newName: "Options");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "Id");
        }
    }
}
