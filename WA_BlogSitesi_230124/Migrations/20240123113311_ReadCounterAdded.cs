using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WA_BlogSitesi_230124.Migrations
{
    public partial class ReadCounterAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReadCounter",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadCounter",
                table: "Article");
        }
    }
}
