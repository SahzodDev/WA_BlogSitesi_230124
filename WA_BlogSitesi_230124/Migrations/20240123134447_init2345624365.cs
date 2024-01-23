using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WA_BlogSitesi_230124.Migrations
{
    public partial class init2345624365 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Subject_SubjectId",
                table: "Article");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "AppUserId", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 1, 23, 16, 44, 47, 466, DateTimeKind.Local).AddTicks(9002), "Sci-Fi" },
                    { 2, null, new DateTime(2024, 1, 23, 16, 44, 47, 466, DateTimeKind.Local).AddTicks(9004), "Fantasy" },
                    { 3, null, new DateTime(2024, 1, 23, 16, 44, 47, 466, DateTimeKind.Local).AddTicks(9005), "History" },
                    { 4, null, new DateTime(2024, 1, 23, 16, 44, 47, 466, DateTimeKind.Local).AddTicks(9006), "Movies" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Subject_SubjectId",
                table: "Article",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Subject_SubjectId",
                table: "Article");

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Article",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Subject_SubjectId",
                table: "Article",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id");
        }
    }
}
