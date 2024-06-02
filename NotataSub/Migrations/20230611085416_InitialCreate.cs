using Microsoft.EntityFrameworkCore.Migrations;

namespace NotataSub.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "semeternum",
                table: "BookSemeter");

            migrationBuilder.RenameColumn(
                name: "bookId",
                table: "BookSemeter",
                newName: "bookTitle");

            migrationBuilder.AddColumn<string>(
                name: "semeterTitel",
                table: "BookSemeter",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "subId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_subId",
                table: "Books",
                column: "subId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Sub_catogary",
                table: "Books",
                column: "subId",
                principalTable: "Sub_catogary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Sub_catogary",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_subId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "semeterTitel",
                table: "BookSemeter");

            migrationBuilder.DropColumn(
                name: "subId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "bookTitle",
                table: "BookSemeter",
                newName: "bookId");

            migrationBuilder.AddColumn<int>(
                name: "semeternum",
                table: "BookSemeter",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
