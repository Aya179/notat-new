using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotataSub.Migrations
{
    public partial class rrrr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Department",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAttachement_Course",
                table: "CourseAttachement");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseExam_Course",
                table: "CourseExam");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseHashtag_Hashtags",
                table: "CourseHashtag");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseHashtag_OnLineCourse",
                table: "CourseHashtag");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOffers_Offers",
                table: "CourseOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOffers_OnLineCourse",
                table: "CourseOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Faculty",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_University",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_CourseExam",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Course",
                table: "Lecture");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_studyyear",
                table: "Lecture");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Faculty",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineExam_OnLineCourse",
                table: "OnlineExam");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineLecture_OnLineCourse",
                table: "OnlineLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Department",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Faculty",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_studyyear",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Course",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Student",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamOnLine_OnlineExam",
                table: "StudentExamOnLine");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamOnLine_Student",
                table: "StudentExamOnLine");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLecture_Lecture",
                table: "StudentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLecture_Student",
                table: "StudentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentNotes_Lecture",
                table: "StudentNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentNotes_Student",
                table: "StudentNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPresense_OnlineLecture",
                table: "StudentPresense");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPresense_Student",
                table: "StudentPresense");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegister_Cobon",
                table: "StudentRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegister_RegisterationType",
                table: "StudentRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegister_Student",
                table: "StudentRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegisterOnline_OnlineCobon",
                table: "StudentRegisterOnline");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegisterOnline_OnLineCourse",
                table: "StudentRegisterOnline");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegisterOnline_Student",
                table: "StudentRegisterOnline");

            migrationBuilder.DropForeignKey(
                name: "FK_studyyear_Department",
                table: "studyyear");

            migrationBuilder.AlterColumn<string>(
                name: "universityName",
                table: "University",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "University",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Teacher",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Teacher",
                type: "nchar(500)",
                fixedLength: true,
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(500)",
                oldFixedLength: true,
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "yearname",
                table: "studyyear",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "Student",
                type: "nchar(20)",
                fixedLength: true,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(20)",
                oldFixedLength: true,
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Student",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Student",
                type: "nchar(200)",
                fixedLength: true,
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(200)",
                oldFixedLength: true,
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "Student",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "RegisterationType",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "courseName",
                table: "OnLineCourse",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "Lecture",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "linkurl",
                table: "Lecture",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Faculty",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "departmentName",
                table: "Department",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "teacher",
                table: "Course",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "courseName",
                table: "Course",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "cobonNumber",
                table: "Cobon",
                type: "nchar(40)",
                fixedLength: true,
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(40)",
                oldFixedLength: true,
                oldMaxLength: 40);

            migrationBuilder.CreateTable(
                name: "Catogary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catogary", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    image = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Writer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    information = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    image = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sub_catogary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Catogary_id = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sub_catogary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sub_catogary_Catogary",
                        column: x => x.Catogary_id,
                        principalTable: "Catogary",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cat_id = table.Column<int>(type: "int", nullable: true),
                    Writre_id = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    pages = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<int>(type: "int", nullable: true),
                    year = table.Column<DateTime>(type: "date", nullable: true),
                    isDeleted = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id);
                    table.ForeignKey(
                        name: "FK_Books_Catogary",
                        column: x => x.cat_id,
                        principalTable: "Catogary",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Writer",
                        column: x => x.Writre_id,
                        principalTable: "Writer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_cat_id",
                table: "Books",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Writre_id",
                table: "Books",
                column: "Writre_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sub_catogary_Catogary_id",
                table: "Sub_catogary",
                column: "Catogary_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Department",
                table: "Course",
                column: "departmentId",
                principalTable: "Department",
                principalColumn: "departmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAttachement_Course",
                table: "CourseAttachement",
                column: "courseId",
                principalTable: "Course",
                principalColumn: "courseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseExam_Course",
                table: "CourseExam",
                column: "courseId",
                principalTable: "Course",
                principalColumn: "courseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseHashtag_Hashtags",
                table: "CourseHashtag",
                column: "hashtagId",
                principalTable: "Hashtags",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseHashtag_OnLineCourse",
                table: "CourseHashtag",
                column: "courseId",
                principalTable: "OnLineCourse",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOffers_Offers",
                table: "CourseOffers",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOffers_OnLineCourse",
                table: "CourseOffers",
                column: "courseId",
                principalTable: "OnLineCourse",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Faculty",
                table: "Department",
                column: "facultyId",
                principalTable: "Faculty",
                principalColumn: "facultyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_University",
                table: "Department",
                column: "universityId",
                principalTable: "University",
                principalColumn: "universityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_CourseExam",
                table: "ExamQuestion",
                column: "examId",
                principalTable: "CourseExam",
                principalColumn: "examId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Course",
                table: "Lecture",
                column: "courseId",
                principalTable: "Course",
                principalColumn: "courseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_studyyear",
                table: "Lecture",
                column: "yearid",
                principalTable: "studyyear",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Faculty",
                table: "News",
                column: "facultyId",
                principalTable: "Faculty",
                principalColumn: "facultyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineExam_OnLineCourse",
                table: "OnlineExam",
                column: "courseId",
                principalTable: "OnLineCourse",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineLecture_OnLineCourse",
                table: "OnlineLecture",
                column: "courseId",
                principalTable: "OnLineCourse",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Department",
                table: "Student",
                column: "departmentId",
                principalTable: "Department",
                principalColumn: "departmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Faculty",
                table: "Student",
                column: "faculityId",
                principalTable: "Faculty",
                principalColumn: "facultyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_studyyear",
                table: "Student",
                column: "yearid",
                principalTable: "studyyear",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Course",
                table: "StudentCourse",
                column: "courseId",
                principalTable: "Course",
                principalColumn: "courseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Student",
                table: "StudentCourse",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "studentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamOnLine_OnlineExam",
                table: "StudentExamOnLine",
                column: "examId",
                principalTable: "OnlineExam",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamOnLine_Student",
                table: "StudentExamOnLine",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "studentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLecture_Lecture",
                table: "StudentLecture",
                column: "lectureId",
                principalTable: "Lecture",
                principalColumn: "lectureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLecture_Student",
                table: "StudentLecture",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "studentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentNotes_Lecture",
                table: "StudentNotes",
                column: "lectureId",
                principalTable: "Lecture",
                principalColumn: "lectureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentNotes_Student",
                table: "StudentNotes",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "studentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPresense_OnlineLecture",
                table: "StudentPresense",
                column: "lectureId",
                principalTable: "OnlineLecture",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPresense_Student",
                table: "StudentPresense",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "studentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegister_Cobon",
                table: "StudentRegister",
                column: "cobonId",
                principalTable: "Cobon",
                principalColumn: "cobonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegister_RegisterationType",
                table: "StudentRegister",
                column: "typeId",
                principalTable: "RegisterationType",
                principalColumn: "typeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegister_Student",
                table: "StudentRegister",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "studentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegisterOnline_OnlineCobon",
                table: "StudentRegisterOnline",
                column: "cobonId",
                principalTable: "OnlineCobon",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegisterOnline_OnLineCourse",
                table: "StudentRegisterOnline",
                column: "CourseId",
                principalTable: "OnLineCourse",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegisterOnline_Student",
                table: "StudentRegisterOnline",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "studentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_studyyear_Department",
                table: "studyyear",
                column: "deptid",
                principalTable: "Department",
                principalColumn: "departmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Department",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAttachement_Course",
                table: "CourseAttachement");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseExam_Course",
                table: "CourseExam");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseHashtag_Hashtags",
                table: "CourseHashtag");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseHashtag_OnLineCourse",
                table: "CourseHashtag");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOffers_Offers",
                table: "CourseOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseOffers_OnLineCourse",
                table: "CourseOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Faculty",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_University",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_CourseExam",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Course",
                table: "Lecture");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_studyyear",
                table: "Lecture");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Faculty",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineExam_OnLineCourse",
                table: "OnlineExam");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineLecture_OnLineCourse",
                table: "OnlineLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Department",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Faculty",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_studyyear",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Course",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Student",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamOnLine_OnlineExam",
                table: "StudentExamOnLine");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamOnLine_Student",
                table: "StudentExamOnLine");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLecture_Lecture",
                table: "StudentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentLecture_Student",
                table: "StudentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentNotes_Lecture",
                table: "StudentNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentNotes_Student",
                table: "StudentNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPresense_OnlineLecture",
                table: "StudentPresense");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentPresense_Student",
                table: "StudentPresense");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegister_Cobon",
                table: "StudentRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegister_RegisterationType",
                table: "StudentRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegister_Student",
                table: "StudentRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegisterOnline_OnlineCobon",
                table: "StudentRegisterOnline");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegisterOnline_OnLineCourse",
                table: "StudentRegisterOnline");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegisterOnline_Student",
                table: "StudentRegisterOnline");

            migrationBuilder.DropForeignKey(
                name: "FK_studyyear_Department",
                table: "studyyear");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Sub_catogary");

            migrationBuilder.DropTable(
                name: "Writer");

            migrationBuilder.DropTable(
                name: "Catogary");

            migrationBuilder.AlterColumn<string>(
                name: "universityName",
                table: "University",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "University",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Teacher",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Teacher",
                type: "nchar(500)",
                fixedLength: true,
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nchar(500)",
                oldFixedLength: true,
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "yearname",
                table: "studyyear",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "Student",
                type: "nchar(20)",
                fixedLength: true,
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nchar(20)",
                oldFixedLength: true,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Student",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Student",
                type: "nchar(200)",
                fixedLength: true,
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nchar(200)",
                oldFixedLength: true,
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "Student",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "RegisterationType",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "courseName",
                table: "OnLineCourse",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "Lecture",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "linkurl",
                table: "Lecture",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Faculty",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "departmentName",
                table: "Department",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "teacher",
                table: "Course",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "courseName",
                table: "Course",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cobonNumber",
                table: "Cobon",
                type: "nchar(40)",
                fixedLength: true,
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nchar(40)",
                oldFixedLength: true,
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Department",
                table: "Course",
                column: "departmentId",
                principalTable: "Department",
                principalColumn: "departmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAttachement_Course",
                table: "CourseAttachement",
                column: "courseId",
                principalTable: "Course",
                principalColumn: "courseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseExam_Course",
                table: "CourseExam",
                column: "courseId",
                principalTable: "Course",
                principalColumn: "courseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseHashtag_Hashtags",
                table: "CourseHashtag",
                column: "hashtagId",
                principalTable: "Hashtags",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseHashtag_OnLineCourse",
                table: "CourseHashtag",
                column: "courseId",
                principalTable: "OnLineCourse",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOffers_Offers",
                table: "CourseOffers",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOffers_OnLineCourse",
                table: "CourseOffers",
                column: "courseId",
                principalTable: "OnLineCourse",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Faculty",
                table: "Department",
                column: "facultyId",
                principalTable: "Faculty",
                principalColumn: "facultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_University",
                table: "Department",
                column: "universityId",
                principalTable: "University",
                principalColumn: "universityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_CourseExam",
                table: "ExamQuestion",
                column: "examId",
                principalTable: "CourseExam",
                principalColumn: "examId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Course",
                table: "Lecture",
                column: "courseId",
                principalTable: "Course",
                principalColumn: "courseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_studyyear",
                table: "Lecture",
                column: "yearid",
                principalTable: "studyyear",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Faculty",
                table: "News",
                column: "facultyId",
                principalTable: "Faculty",
                principalColumn: "facultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineExam_OnLineCourse",
                table: "OnlineExam",
                column: "courseId",
                principalTable: "OnLineCourse",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineLecture_OnLineCourse",
                table: "OnlineLecture",
                column: "courseId",
                principalTable: "OnLineCourse",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Department",
                table: "Student",
                column: "departmentId",
                principalTable: "Department",
                principalColumn: "departmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Faculty",
                table: "Student",
                column: "faculityId",
                principalTable: "Faculty",
                principalColumn: "facultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_studyyear",
                table: "Student",
                column: "yearid",
                principalTable: "studyyear",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Course",
                table: "StudentCourse",
                column: "courseId",
                principalTable: "Course",
                principalColumn: "courseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Student",
                table: "StudentCourse",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamOnLine_OnlineExam",
                table: "StudentExamOnLine",
                column: "examId",
                principalTable: "OnlineExam",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamOnLine_Student",
                table: "StudentExamOnLine",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLecture_Lecture",
                table: "StudentLecture",
                column: "lectureId",
                principalTable: "Lecture",
                principalColumn: "lectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentLecture_Student",
                table: "StudentLecture",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentNotes_Lecture",
                table: "StudentNotes",
                column: "lectureId",
                principalTable: "Lecture",
                principalColumn: "lectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentNotes_Student",
                table: "StudentNotes",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPresense_OnlineLecture",
                table: "StudentPresense",
                column: "lectureId",
                principalTable: "OnlineLecture",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentPresense_Student",
                table: "StudentPresense",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegister_Cobon",
                table: "StudentRegister",
                column: "cobonId",
                principalTable: "Cobon",
                principalColumn: "cobonId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegister_RegisterationType",
                table: "StudentRegister",
                column: "typeId",
                principalTable: "RegisterationType",
                principalColumn: "typeId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegister_Student",
                table: "StudentRegister",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegisterOnline_OnlineCobon",
                table: "StudentRegisterOnline",
                column: "cobonId",
                principalTable: "OnlineCobon",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegisterOnline_OnLineCourse",
                table: "StudentRegisterOnline",
                column: "CourseId",
                principalTable: "OnLineCourse",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegisterOnline_Student",
                table: "StudentRegisterOnline",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_studyyear_Department",
                table: "studyyear",
                column: "deptid",
                principalTable: "Department",
                principalColumn: "departmentId");
        }
    }
}
