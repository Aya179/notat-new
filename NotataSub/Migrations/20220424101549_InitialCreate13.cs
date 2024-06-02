using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NotataSub.Migrations
{
    public partial class InitialCreate13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cobon",
                columns: table => new
                {
                    cobonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cobonValue = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    cobonNumber = table.Column<string>(type: "nchar(40)", fixedLength: true, maxLength: 40, nullable: false),
                    isValid = table.Column<bool>(type: "bit", nullable: false),
                    releaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobon", x => x.cobonId);
                });

            migrationBuilder.CreateTable(
                name: "Hashtags",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hashtagText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hashtags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Library",
                columns: table => new
                {
                    libId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phone = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Library__13D57668A432853F", x => x.libId);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    offerText = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    startdate = table.Column<DateTime>(type: "date", nullable: true),
                    enddate = table.Column<DateTime>(type: "date", nullable: true),
                    discount = table.Column<int>(type: "int", nullable: true),
                    discription = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OnlineCobon",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    value = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    number = table.Column<int>(type: "int", nullable: true),
                    publishDate = table.Column<DateTime>(type: "date", nullable: true),
                    libId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isPayes = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineCobon", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OnLineCourse",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    isUniversity = table.Column<bool>(type: "bit", nullable: true),
                    cost = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    numOfLectures = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    teacher = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Domain = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    promoLink = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnLineCourse", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OnlineQuestion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    questionText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ans1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ans2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ans3 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ans4 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ans5 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    answer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineQuestion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RegisterationType",
                columns: table => new
                {
                    typeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    duration = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,0)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Register__F04DF13A11ED9B73", x => x.typeId);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    teacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "nchar(500)", fixedLength: true, maxLength: 500, nullable: false),
                    photo = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.teacherId);
                });

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    universityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    universityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.universityId);
                });

            migrationBuilder.CreateTable(
                name: "CourseHashtag",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    hashtagId = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseHashtag", x => x.id);
                    table.ForeignKey(
                        name: "FK_CourseHashtag_Hashtags",
                        column: x => x.hashtagId,
                        principalTable: "Hashtags",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CourseHashtag_OnLineCourse",
                        column: x => x.courseId,
                        principalTable: "OnLineCourse",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CourseOffers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    OfferId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOffers", x => x.id);
                    table.ForeignKey(
                        name: "FK_CourseOffers_Offers",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CourseOffers_OnLineCourse",
                        column: x => x.courseId,
                        principalTable: "OnLineCourse",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "OnlineExam",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    passed = table.Column<int>(type: "int", nullable: true),
                    failed = table.Column<int>(type: "int", nullable: true),
                    numOfQuestions = table.Column<int>(type: "int", nullable: true),
                    duration = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineExam", x => x.id);
                    table.ForeignKey(
                        name: "FK_OnlineExam_OnLineCourse",
                        column: x => x.courseId,
                        principalTable: "OnLineCourse",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "OnlineLecture",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    lectureNum = table.Column<int>(type: "int", nullable: true),
                    publishdate = table.Column<DateTime>(type: "date", nullable: true),
                    description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    files = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineLecture", x => x.id);
                    table.ForeignKey(
                        name: "FK_OnlineLecture_OnLineCourse",
                        column: x => x.courseId,
                        principalTable: "OnLineCourse",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    facultyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uniersityId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.facultyId);
                    table.ForeignKey(
                        name: "FK_Faculty_University",
                        column: x => x.uniersityId,
                        principalTable: "University",
                        principalColumn: "universityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    departmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    facultyId = table.Column<int>(type: "int", nullable: false),
                    departmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    universityId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.departmentId);
                    table.ForeignKey(
                        name: "FK_Department_Faculty",
                        column: x => x.facultyId,
                        principalTable: "Faculty",
                        principalColumn: "facultyId");
                    table.ForeignKey(
                        name: "FK_Department_University",
                        column: x => x.universityId,
                        principalTable: "University",
                        principalColumn: "universityId");
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    newsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    newsText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    newsUrl = table.Column<string>(type: "nchar(400)", fixedLength: true, maxLength: 400, nullable: true),
                    publishDate = table.Column<DateTime>(type: "date", nullable: true),
                    facultyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.newsId);
                    table.ForeignKey(
                        name: "FK_News_Faculty",
                        column: x => x.facultyId,
                        principalTable: "Faculty",
                        principalColumn: "facultyId");
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    courseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    facultyId = table.Column<int>(type: "int", nullable: false),
                    teacher = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    semester = table.Column<int>(type: "int", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.courseId);
                    table.ForeignKey(
                        name: "FK_Course_Department",
                        column: x => x.departmentId,
                        principalTable: "Department",
                        principalColumn: "departmentId");
                    table.ForeignKey(
                        name: "FK_Course_Faculty",
                        column: x => x.facultyId,
                        principalTable: "Faculty",
                        principalColumn: "facultyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "studyyear",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yearname = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    deptid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studyyear", x => x.id);
                    table.ForeignKey(
                        name: "FK_studyyear_Department",
                        column: x => x.deptid,
                        principalTable: "Department",
                        principalColumn: "departmentId");
                });

            migrationBuilder.CreateTable(
                name: "CourseAttachement",
                columns: table => new
                {
                    attachementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    publishDate = table.Column<DateTime>(type: "date", nullable: true),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    attachUrl = table.Column<string>(type: "nchar(200)", fixedLength: true, maxLength: 200, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseAt__7CA72DFB90A4D1EC", x => x.attachementId);
                    table.ForeignKey(
                        name: "FK_CourseAttachement_Course",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "courseId");
                });

            migrationBuilder.CreateTable(
                name: "CourseExam",
                columns: table => new
                {
                    examId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    passes = table.Column<int>(type: "int", nullable: true),
                    failed = table.Column<int>(type: "int", nullable: true),
                    examDate = table.Column<DateTime>(type: "date", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseEx__A56D125FB33AED43", x => x.examId);
                    table.ForeignKey(
                        name: "FK_CourseExam_Course",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "courseId");
                });

            migrationBuilder.CreateTable(
                name: "Lecture",
                columns: table => new
                {
                    lectureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lectureNum = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    publishDate = table.Column<DateTime>(type: "date", nullable: false),
                    courseId = table.Column<int>(type: "int", nullable: false),
                    pages = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    price = table.Column<int>(type: "int", nullable: false),
                    yearid = table.Column<int>(type: "int", nullable: false),
                    linkurl = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecture", x => x.lectureId);
                    table.ForeignKey(
                        name: "FK_Lecture_Course",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "courseId");
                    table.ForeignKey(
                        name: "FK_Lecture_studyyear",
                        column: x => x.yearid,
                        principalTable: "studyyear",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nchar(200)", fixedLength: true, maxLength: 200, nullable: false),
                    phone = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    birthdate = table.Column<DateTime>(type: "date", nullable: false),
                    password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    faculityId = table.Column<int>(type: "int", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    yearid = table.Column<int>(type: "int", nullable: false),
                    activationcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.studentId);
                    table.ForeignKey(
                        name: "FK_Student_Department",
                        column: x => x.departmentId,
                        principalTable: "Department",
                        principalColumn: "departmentId");
                    table.ForeignKey(
                        name: "FK_Student_Faculty",
                        column: x => x.faculityId,
                        principalTable: "Faculty",
                        principalColumn: "facultyId");
                    table.ForeignKey(
                        name: "FK_Student_studyyear",
                        column: x => x.yearid,
                        principalTable: "studyyear",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestion",
                columns: table => new
                {
                    questionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    examId = table.Column<int>(type: "int", nullable: true),
                    question = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ans1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ans2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ans3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ans4 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    rightAnswer = table.Column<int>(type: "int", nullable: true),
                    ans5 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ExamQues__6238D4B29DCC452F", x => x.questionId);
                    table.ForeignKey(
                        name: "FK_ExamQuestion_CourseExam",
                        column: x => x.examId,
                        principalTable: "CourseExam",
                        principalColumn: "examId");
                });

            migrationBuilder.CreateTable(
                name: "RegisterOnLine",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    courseId = table.Column<int>(type: "int", nullable: false),
                    registerdate = table.Column<DateTime>(type: "date", nullable: true),
                    reviews = table.Column<int>(type: "int", nullable: true),
                    currentLesson = table.Column<int>(type: "int", nullable: true),
                    isDone = table.Column<bool>(type: "bit", nullable: true),
                    isPassed = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterOnLine", x => x.id);
                    table.ForeignKey(
                        name: "FK_RegisterOnLine_OnLineCourse",
                        column: x => x.courseId,
                        principalTable: "OnLineCourse",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisterOnLine_Student",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    scId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: true),
                    courseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentC__3215821D6D532D9D", x => x.scId);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Course",
                        column: x => x.courseId,
                        principalTable: "Course",
                        principalColumn: "courseId");
                    table.ForeignKey(
                        name: "FK_StudentCourse_Student",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "studentId");
                });

            migrationBuilder.CreateTable(
                name: "StudentExamOnLine",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: true),
                    examId = table.Column<int>(type: "int", nullable: true),
                    examDate = table.Column<DateTime>(type: "date", nullable: true),
                    mark = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExamOnLine", x => x.id);
                    table.ForeignKey(
                        name: "FK_StudentExamOnLine_OnlineExam",
                        column: x => x.examId,
                        principalTable: "OnlineExam",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_StudentExamOnLine_Student",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "studentId");
                });

            migrationBuilder.CreateTable(
                name: "StudentLecture",
                columns: table => new
                {
                    slId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: true),
                    lectureId = table.Column<int>(type: "int", nullable: true),
                    viewDate = table.Column<DateTime>(type: "date", nullable: true),
                    downloadDate = table.Column<DateTime>(type: "date", nullable: true),
                    isFav = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentL__32DCE1E7526EF8FF", x => x.slId);
                    table.ForeignKey(
                        name: "FK_StudentLecture_Lecture",
                        column: x => x.lectureId,
                        principalTable: "Lecture",
                        principalColumn: "lectureId");
                    table.ForeignKey(
                        name: "FK_StudentLecture_Student",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "studentId");
                });

            migrationBuilder.CreateTable(
                name: "StudentNotes",
                columns: table => new
                {
                    noteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: true),
                    noteText = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    lectureId = table.Column<int>(type: "int", nullable: true),
                    page = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentN__03C97EFDB06B1A33", x => x.noteId);
                    table.ForeignKey(
                        name: "FK_StudentNotes_Lecture",
                        column: x => x.lectureId,
                        principalTable: "Lecture",
                        principalColumn: "lectureId");
                    table.ForeignKey(
                        name: "FK_StudentNotes_Student",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "studentId");
                });

            migrationBuilder.CreateTable(
                name: "StudentPresense",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    presenseDate = table.Column<DateTime>(type: "date", nullable: true),
                    studentId = table.Column<int>(type: "int", nullable: true),
                    lectureId = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPresense", x => x.id);
                    table.ForeignKey(
                        name: "FK_StudentPresense_OnlineLecture",
                        column: x => x.lectureId,
                        principalTable: "OnlineLecture",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_StudentPresense_Student",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "studentId");
                });

            migrationBuilder.CreateTable(
                name: "StudentRegister",
                columns: table => new
                {
                    srId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: true),
                    typeId = table.Column<int>(type: "int", nullable: true),
                    cobonId = table.Column<int>(type: "int", nullable: true),
                    registerDate = table.Column<DateTime>(type: "date", nullable: true),
                    isValid = table.Column<bool>(type: "bit", nullable: true),
                    isPaid = table.Column<bool>(type: "bit", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StudentR__36B01FFD2A9D488D", x => x.srId);
                    table.ForeignKey(
                        name: "FK_StudentRegister_Cobon",
                        column: x => x.cobonId,
                        principalTable: "Cobon",
                        principalColumn: "cobonId");
                    table.ForeignKey(
                        name: "FK_StudentRegister_RegisterationType",
                        column: x => x.typeId,
                        principalTable: "RegisterationType",
                        principalColumn: "typeId");
                    table.ForeignKey(
                        name: "FK_StudentRegister_Student",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "studentId");
                });

            migrationBuilder.CreateTable(
                name: "StudentRegisterOnline",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    cobonId = table.Column<int>(type: "int", nullable: true),
                    review = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRegisterOnline", x => x.id);
                    table.ForeignKey(
                        name: "FK_StudentRegisterOnline_OnlineCobon",
                        column: x => x.cobonId,
                        principalTable: "OnlineCobon",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_StudentRegisterOnline_OnLineCourse",
                        column: x => x.CourseId,
                        principalTable: "OnLineCourse",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_StudentRegisterOnline_Student",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "studentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_departmentId",
                table: "Course",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_facultyId",
                table: "Course",
                column: "facultyId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAttachement_courseId",
                table: "CourseAttachement",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseExam_courseId",
                table: "CourseExam",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseHashtag_courseId",
                table: "CourseHashtag",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseHashtag_hashtagId",
                table: "CourseHashtag",
                column: "hashtagId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOffers_courseId",
                table: "CourseOffers",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOffers_OfferId",
                table: "CourseOffers",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_facultyId",
                table: "Department",
                column: "facultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_universityId",
                table: "Department",
                column: "universityId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestion_examId",
                table: "ExamQuestion",
                column: "examId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculty_uniersityId",
                table: "Faculty",
                column: "uniersityId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_courseId",
                table: "Lecture",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_yearid",
                table: "Lecture",
                column: "yearid");

            migrationBuilder.CreateIndex(
                name: "IX_News_facultyId",
                table: "News",
                column: "facultyId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineExam_courseId",
                table: "OnlineExam",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineLecture_courseId",
                table: "OnlineLecture",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterOnLine_courseId",
                table: "RegisterOnLine",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterOnLine_studentId",
                table: "RegisterOnLine",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_departmentId",
                table: "Student",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_faculityId",
                table: "Student",
                column: "faculityId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_yearid",
                table: "Student",
                column: "yearid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_courseId",
                table: "StudentCourse",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_studentId",
                table: "StudentCourse",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExamOnLine_examId",
                table: "StudentExamOnLine",
                column: "examId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExamOnLine_studentId",
                table: "StudentExamOnLine",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLecture_lectureId",
                table: "StudentLecture",
                column: "lectureId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLecture_studentId",
                table: "StudentLecture",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentNotes_lectureId",
                table: "StudentNotes",
                column: "lectureId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentNotes_studentId",
                table: "StudentNotes",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPresense_lectureId",
                table: "StudentPresense",
                column: "lectureId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPresense_studentId",
                table: "StudentPresense",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegister_cobonId",
                table: "StudentRegister",
                column: "cobonId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegister_studentId",
                table: "StudentRegister",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegister_typeId",
                table: "StudentRegister",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegisterOnline_cobonId",
                table: "StudentRegisterOnline",
                column: "cobonId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegisterOnline_CourseId",
                table: "StudentRegisterOnline",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegisterOnline_StudentId",
                table: "StudentRegisterOnline",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_studyyear_deptid",
                table: "studyyear",
                column: "deptid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseAttachement");

            migrationBuilder.DropTable(
                name: "CourseHashtag");

            migrationBuilder.DropTable(
                name: "CourseOffers");

            migrationBuilder.DropTable(
                name: "ExamQuestion");

            migrationBuilder.DropTable(
                name: "Library");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "OnlineQuestion");

            migrationBuilder.DropTable(
                name: "RegisterOnLine");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "StudentExamOnLine");

            migrationBuilder.DropTable(
                name: "StudentLecture");

            migrationBuilder.DropTable(
                name: "StudentNotes");

            migrationBuilder.DropTable(
                name: "StudentPresense");

            migrationBuilder.DropTable(
                name: "StudentRegister");

            migrationBuilder.DropTable(
                name: "StudentRegisterOnline");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Hashtags");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "CourseExam");

            migrationBuilder.DropTable(
                name: "OnlineExam");

            migrationBuilder.DropTable(
                name: "Lecture");

            migrationBuilder.DropTable(
                name: "OnlineLecture");

            migrationBuilder.DropTable(
                name: "Cobon");

            migrationBuilder.DropTable(
                name: "RegisterationType");

            migrationBuilder.DropTable(
                name: "OnlineCobon");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "OnLineCourse");

            migrationBuilder.DropTable(
                name: "studyyear");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "University");
        }
    }
}
