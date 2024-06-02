using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotataSub.Migrations
{
    public partial class test1245879 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Catogary",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Writer",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Writre_id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Writre_id",
                table: "Books");

            migrationBuilder.AddColumn<bool>(
                name: "IsBuing",
                table: "Client",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Client",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "balance",
                table: "Client",
                type: "decimal(18,0)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "cat_id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Books",
                type: "Image",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherWriter",
                table: "Books",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WriterName",
                table: "Books",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "linkurl",
                table: "Books",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookSemeters",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    semeternum = table.Column<int>(type: "int", nullable: false),
                    pagenum = table.Column<int>(type: "int", nullable: false),
                    bookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSemeters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Buying",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientId = table.Column<int>(type: "int", nullable: false),
                    bookID = table.Column<int>(type: "int", nullable: false),
                    BuyingDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buying", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientCobon",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CobonId = table.Column<int>(type: "int", nullable: false),
                    CobonDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCobon", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Catogary",
                table: "Books",
                column: "cat_id",
                principalTable: "Catogary",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Catogary",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookSemeters");

            migrationBuilder.DropTable(
                name: "Buying");

            migrationBuilder.DropTable(
                name: "ClientCobon");

            migrationBuilder.DropColumn(
                name: "IsBuing",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "balance",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "OtherWriter",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "WriterName",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "linkurl",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "cat_id",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Writre_id",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_Writre_id",
                table: "Books",
                column: "Writre_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Catogary",
                table: "Books",
                column: "cat_id",
                principalTable: "Catogary",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Writer",
                table: "Books",
                column: "Writre_id",
                principalTable: "Writer",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
