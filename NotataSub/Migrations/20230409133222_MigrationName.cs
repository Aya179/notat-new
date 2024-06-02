using Microsoft.EntityFrameworkCore.Migrations;

namespace NotataSub.Migrations
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookSemeters",
                table: "BookSemeters");

            migrationBuilder.RenameTable(
                name: "BookSemeters",
                newName: "BookSemeter");

            migrationBuilder.AlterColumn<string>(
                name: "bookId",
                table: "BookSemeter",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookSemeter",
                table: "BookSemeter",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookSemeter",
                table: "BookSemeter");

            migrationBuilder.RenameTable(
                name: "BookSemeter",
                newName: "BookSemeters");

            migrationBuilder.AlterColumn<int>(
                name: "bookId",
                table: "BookSemeters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookSemeters",
                table: "BookSemeters",
                column: "id");
        }
    }
}
