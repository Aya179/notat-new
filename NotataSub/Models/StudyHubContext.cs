using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NotataSub.Models
{
    public partial class StudyHubContext : DbContext
    {
        public StudyHubContext()
        {
        }

        public StudyHubContext(DbContextOptions<StudyHubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Catogary> Catogaries { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Cobon> Cobons { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseAttachement> CourseAttachements { get; set; } = null!;
        public virtual DbSet<CourseExam> CourseExams { get; set; } = null!;
        public virtual DbSet<CourseHashtag> CourseHashtags { get; set; } = null!;
        public virtual DbSet<CourseOffer> CourseOffers { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<ExamQuestion> ExamQuestions { get; set; } = null!;
        public virtual DbSet<Faculty> Faculties { get; set; } = null!;
        public virtual DbSet<Hashtag> Hashtags { get; set; } = null!;
        public virtual DbSet<Lecture> Lectures { get; set; } = null!;
        public virtual DbSet<Library> Libraries { get; set; } = null!;
        public virtual DbSet<News> News { get; set; } = null!;
        public virtual DbSet<Offer> Offers { get; set; } = null!;
        public virtual DbSet<OnLineCourse> OnLineCourses { get; set; } = null!;
        public virtual DbSet<OnlineCobon> OnlineCobons { get; set; } = null!;
        public virtual DbSet<OnlineExam> OnlineExams { get; set; } = null!;
        public virtual DbSet<OnlineLecture> OnlineLectures { get; set; } = null!;
        public virtual DbSet<OnlineQuestion> OnlineQuestions { get; set; } = null!;
        public virtual DbSet<RegisterOnLine> RegisterOnLines { get; set; } = null!;
        public virtual DbSet<RegisterationType> RegisterationTypes { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentCourse> StudentCourses { get; set; } = null!;
        public virtual DbSet<StudentExamOnLine> StudentExamOnLines { get; set; } = null!;
        public virtual DbSet<StudentLecture> StudentLectures { get; set; } = null!;
        public virtual DbSet<StudentNote> StudentNotes { get; set; } = null!;
        public virtual DbSet<StudentPresense> StudentPresenses { get; set; } = null!;
        public virtual DbSet<StudentRegister> StudentRegisters { get; set; } = null!;
        public virtual DbSet<StudentRegisterOnline> StudentRegisterOnlines { get; set; } = null!;
        public virtual DbSet<Studyyear> Studyyears { get; set; } = null!;
        public virtual DbSet<SubCatogary> SubCatogaries { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<University> Universities { get; set; } = null!;
        public virtual DbSet<Writer> Writers { get; set; } = null!;
        public virtual DbSet<Buying> Buyings { get; set; } = null!;
        public virtual DbSet<ClientCobon> ClientCobons { get; set; } = null!;
        public virtual DbSet<BookSemeter> BookSemeters { get; set; } = null!;




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-TLHBLSS;Database=dbNew;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");
                entity.Property(e => e.Linkurl)
                    .HasMaxLength(150)
                    .HasColumnName("linkurl");

                entity.Property(e => e.OtherWriter)
                    .HasMaxLength(150)
                    .HasColumnName("OtherWriter");


                entity.Property(e => e.WriterName)
                   .HasMaxLength(150)
                   .HasColumnName("WriterName");

                entity.Property(e => e.Image).HasColumnType("Image");
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CatId).HasColumnName("cat_id");

                entity.Property(e => e.IsDeleted)
                    .HasMaxLength(10)
                    .HasColumnName("isDeleted")
                    .IsFixedLength();

                entity.Property(e => e.Pages).HasColumnName("pages");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

               

                entity.Property(e => e.Year)
                    .HasColumnType("date")
                    .HasColumnName("year");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_Books_Catogary");

                entity.HasOne(d => d.Sub)
                   .WithMany(p => p.Books)
                   .HasForeignKey(d => d.subId)
                   .HasConstraintName("FK_Books_Sub_catogary");


            });


            modelBuilder.Entity<BookSemeter>(entity =>
            {
                entity.ToTable("BookSemeter");
                entity.Property(e => e.id)
                    
                    .HasColumnName("id");

                entity.Property(e => e.semeterTitel)
                    .HasMaxLength(150)
                    .HasColumnName("semeterTitel");


                entity.Property(e => e.bookTitle)
                  .HasMaxLength(150)
                   .HasColumnName("bookTitle");
                entity.Property(e => e.pagenum)

                  .HasColumnName("pagenum");

              
                

                
                //entity.HasOne(d => d.book2)
                //    .WithMany(p => p.BookSemeters)
                //    .HasForeignKey(d => d.bookId)
                //    .HasConstraintName("FK_BookSemeter_Books");


            });



            modelBuilder.Entity<Catogary>(entity =>
            {
                entity.ToTable("Catogary");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.IsBuing).HasColumnName("IsBuing");
                entity.Property(e => e.balance)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("balance");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Image)
                    .HasColumnType("image")
                    .HasColumnName("image");

                entity.Property(e => e.LastName).HasMaxLength(100);

               

                entity.Property(e => e.Phone).HasMaxLength(100);
            });

            modelBuilder.Entity<Cobon>(entity =>
            {
                entity.ToTable("Cobon");

                entity.Property(e => e.CobonId).HasColumnName("cobonId");

                entity.Property(e => e.CobonNumber)
                    .HasMaxLength(40)
                    .HasColumnName("cobonNumber")
                    .IsFixedLength();

                entity.Property(e => e.CobonValue)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("cobonValue");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsValid).HasColumnName("isValid");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("releaseDate");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.HasIndex(e => e.DepartmentId, "IX_Course_departmentId");

                entity.HasIndex(e => e.FacultyId, "IX_Course_facultyId");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(100)
                    .HasColumnName("courseName");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.FacultyId).HasColumnName("facultyId");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Semester).HasColumnName("semester");

                entity.Property(e => e.Teacher)
                    .HasMaxLength(100)
                    .HasColumnName("teacher");

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Department");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Faculty");
            });

            modelBuilder.Entity<CourseAttachement>(entity =>
            {
                entity.HasKey(e => e.AttachementId)
                    .HasName("PK__CourseAt__7CA72DFB90A4D1EC");

                entity.ToTable("CourseAttachement");

                entity.HasIndex(e => e.CourseId, "IX_CourseAttachement_courseId");

                entity.Property(e => e.AttachementId).HasColumnName("attachementId");

                entity.Property(e => e.AttachUrl)
                    .HasMaxLength(200)
                    .HasColumnName("attachUrl")
                    .IsFixedLength();

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PublishDate)
                    .HasColumnType("date")
                    .HasColumnName("publishDate");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseAttachements)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_CourseAttachement_Course");
            });

            modelBuilder.Entity<CourseExam>(entity =>
            {
                entity.HasKey(e => e.ExamId)
                    .HasName("PK__CourseEx__A56D125FB33AED43");

                entity.ToTable("CourseExam");

                entity.HasIndex(e => e.CourseId, "IX_CourseExam_courseId");

                entity.Property(e => e.ExamId).HasColumnName("examId");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.ExamDate)
                    .HasColumnType("date")
                    .HasColumnName("examDate");

                entity.Property(e => e.Failed).HasColumnName("failed");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Passes).HasColumnName("passes");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseExams)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_CourseExam_Course");
            });

            modelBuilder.Entity<CourseHashtag>(entity =>
            {
                entity.ToTable("CourseHashtag");

                entity.HasIndex(e => e.CourseId, "IX_CourseHashtag_courseId");

                entity.HasIndex(e => e.HashtagId, "IX_CourseHashtag_hashtagId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.HashtagId).HasColumnName("hashtagId");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseHashtags)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_CourseHashtag_OnLineCourse");

                entity.HasOne(d => d.Hashtag)
                    .WithMany(p => p.CourseHashtags)
                    .HasForeignKey(d => d.HashtagId)
                    .HasConstraintName("FK_CourseHashtag_Hashtags");
            });

            modelBuilder.Entity<CourseOffer>(entity =>
            {
                entity.HasIndex(e => e.OfferId, "IX_CourseOffers_OfferId");

                entity.HasIndex(e => e.CourseId, "IX_CourseOffers_courseId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseOffers)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_CourseOffers_OnLineCourse");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.CourseOffers)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("FK_CourseOffers_Offers");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.HasIndex(e => e.FacultyId, "IX_Department_facultyId");

                entity.HasIndex(e => e.UniversityId, "IX_Department_universityId");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(100)
                    .HasColumnName("departmentName");

                entity.Property(e => e.FacultyId).HasColumnName("facultyId");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UniversityId).HasColumnName("universityId");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Department_Faculty");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Department_University");
            });

            modelBuilder.Entity<ExamQuestion>(entity =>
            {
                entity.HasKey(e => e.QuestionId)
                    .HasName("PK__ExamQues__6238D4B29DCC452F");

                entity.ToTable("ExamQuestion");

                entity.HasIndex(e => e.ExamId, "IX_ExamQuestion_examId");

                entity.Property(e => e.QuestionId).HasColumnName("questionId");

                entity.Property(e => e.Ans1)
                    .HasMaxLength(200)
                    .HasColumnName("ans1");

                entity.Property(e => e.Ans2)
                    .HasMaxLength(200)
                    .HasColumnName("ans2");

                entity.Property(e => e.Ans3)
                    .HasMaxLength(200)
                    .HasColumnName("ans3");

                entity.Property(e => e.Ans4)
                    .HasMaxLength(200)
                    .HasColumnName("ans4");

                entity.Property(e => e.Ans5)
                    .HasMaxLength(200)
                    .HasColumnName("ans5");

                entity.Property(e => e.ExamId).HasColumnName("examId");

                entity.Property(e => e.Question)
                    .HasMaxLength(200)
                    .HasColumnName("question");

                entity.Property(e => e.RightAnswer).HasColumnName("rightAnswer");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.ExamQuestions)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK_ExamQuestion_CourseExam");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.ToTable("Faculty");

                entity.HasIndex(e => e.UniersityId, "IX_Faculty_uniersityId");

                entity.Property(e => e.FacultyId).HasColumnName("facultyId");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.UniersityId).HasColumnName("uniersityId");

                entity.HasOne(d => d.Uniersity)
                    .WithMany(p => p.Faculties)
                    .HasForeignKey(d => d.UniersityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Faculty_University");
            });

            modelBuilder.Entity<Hashtag>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.HashtagText)
                    .HasMaxLength(50)
                    .HasColumnName("hashtagText");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.ToTable("Lecture");

                entity.HasIndex(e => e.CourseId, "IX_Lecture_courseId");

                entity.HasIndex(e => e.Yearid, "IX_Lecture_yearid");

                entity.Property(e => e.LectureId).HasColumnName("lectureId");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LectureNum).HasColumnName("lectureNum");

                entity.Property(e => e.Linkurl)
                    .HasMaxLength(150)
                    .HasColumnName("linkurl");

                entity.Property(e => e.Pages).HasColumnName("pages");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.PublishDate)
                    .HasColumnType("date")
                    .HasColumnName("publishDate");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");

                entity.Property(e => e.Yearid).HasColumnName("yearid");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lecture_Course");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.Yearid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lecture_studyyear");
            });

            modelBuilder.Entity<Library>(entity =>
            {
                entity.HasKey(e => e.LibId)
                    .HasName("PK__Library__13D57668A432853F");

                entity.ToTable("Library");

                entity.Property(e => e.LibId).HasColumnName("libId");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .HasColumnName("email");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Notes)
                    .HasMaxLength(1000)
                    .HasColumnName("notes");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone")
                    .IsFixedLength();
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasIndex(e => e.FacultyId, "IX_News_facultyId");

                entity.Property(e => e.NewsId).HasColumnName("newsId");

                entity.Property(e => e.FacultyId).HasColumnName("facultyId");

                entity.Property(e => e.NewsText)
                    .HasMaxLength(300)
                    .HasColumnName("newsText");

                entity.Property(e => e.NewsUrl)
                    .HasMaxLength(400)
                    .HasColumnName("newsUrl")
                    .IsFixedLength();

                entity.Property(e => e.PublishDate)
                    .HasColumnType("date")
                    .HasColumnName("publishDate");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("FK_News_Faculty");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Discription)
                    .HasMaxLength(10)
                    .HasColumnName("discription")
                    .IsFixedLength();

                entity.Property(e => e.Enddate)
                    .HasColumnType("date")
                    .HasColumnName("enddate");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.OfferText)
                    .HasMaxLength(400)
                    .HasColumnName("offerText");

                entity.Property(e => e.Startdate)
                    .HasColumnType("date")
                    .HasColumnName("startdate");
            });

            modelBuilder.Entity<OnLineCourse>(entity =>
            {
                entity.ToTable("OnLineCourse");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("cost");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(100)
                    .HasColumnName("courseName");

                entity.Property(e => e.Description)
                    .HasMaxLength(400)
                    .HasColumnName("description");

                entity.Property(e => e.Domain).HasMaxLength(300);

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsUniversity).HasColumnName("isUniversity");

                entity.Property(e => e.NumOfLectures).HasColumnName("numOfLectures");

                entity.Property(e => e.PromoLink)
                    .HasMaxLength(400)
                    .HasColumnName("promoLink");

                entity.Property(e => e.Teacher)
                    .HasMaxLength(100)
                    .HasColumnName("teacher");
            });

            modelBuilder.Entity<OnlineCobon>(entity =>
            {
                entity.ToTable("OnlineCobon");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPayes).HasColumnName("isPayes");

                entity.Property(e => e.LibId).HasColumnName("libId");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.PublishDate)
                    .HasColumnType("date")
                    .HasColumnName("publishDate");

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("value");
            });

            modelBuilder.Entity<OnlineExam>(entity =>
            {
                entity.ToTable("OnlineExam");

                entity.HasIndex(e => e.CourseId, "IX_OnlineExam_courseId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Failed).HasColumnName("failed");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NumOfQuestions).HasColumnName("numOfQuestions");

                entity.Property(e => e.Passed).HasColumnName("passed");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.OnlineExams)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_OnlineExam_OnLineCourse");
            });

            modelBuilder.Entity<OnlineLecture>(entity =>
            {
                entity.ToTable("OnlineLecture");

                entity.HasIndex(e => e.CourseId, "IX_OnlineLecture_courseId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.Description)
                    .HasMaxLength(400)
                    .HasColumnName("description");

                entity.Property(e => e.Files)
                    .HasMaxLength(300)
                    .HasColumnName("files");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LectureNum).HasColumnName("lectureNum");

                entity.Property(e => e.Publishdate)
                    .HasColumnType("date")
                    .HasColumnName("publishdate");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.OnlineLectures)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_OnlineLecture_OnLineCourse");
            });

            modelBuilder.Entity<OnlineQuestion>(entity =>
            {
                entity.ToTable("OnlineQuestion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ans1)
                    .HasMaxLength(300)
                    .HasColumnName("ans1");

                entity.Property(e => e.Ans2)
                    .HasMaxLength(300)
                    .HasColumnName("ans2");

                entity.Property(e => e.Ans3)
                    .HasMaxLength(300)
                    .HasColumnName("ans3");

                entity.Property(e => e.Ans4)
                    .HasMaxLength(300)
                    .HasColumnName("ans4");

                entity.Property(e => e.Ans5)
                    .HasMaxLength(500)
                    .HasColumnName("ans5");

                entity.Property(e => e.Answer).HasColumnName("answer");

                entity.Property(e => e.QuestionText)
                    .HasMaxLength(300)
                    .HasColumnName("questionText");
            });

            modelBuilder.Entity<RegisterOnLine>(entity =>
            {
                entity.ToTable("RegisterOnLine");

                entity.HasIndex(e => e.CourseId, "IX_RegisterOnLine_courseId");

                entity.HasIndex(e => e.StudentId, "IX_RegisterOnLine_studentId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.CurrentLesson).HasColumnName("currentLesson");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDone).HasColumnName("isDone");

                entity.Property(e => e.IsPassed).HasColumnName("isPassed");

                entity.Property(e => e.Registerdate)
                    .HasColumnType("date")
                    .HasColumnName("registerdate");

                entity.Property(e => e.Reviews).HasColumnName("reviews");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.RegisterOnLines)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegisterOnLine_OnLineCourse");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.RegisterOnLines)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegisterOnLine_Student");
            });

            modelBuilder.Entity<RegisterationType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__Register__F04DF13A11ED9B73");

                entity.ToTable("RegisterationType");

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.HasIndex(e => e.DepartmentId, "IX_Student_departmentId");

                entity.HasIndex(e => e.FaculityId, "IX_Student_faculityId");

                entity.HasIndex(e => e.Yearid, "IX_Student_yearid");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.Activationcode)
                    .HasMaxLength(50)
                    .HasColumnName("activationcode");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .HasColumnName("city");

                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .HasColumnName("email")
                    .IsFixedLength();

                entity.Property(e => e.FaculityId).HasColumnName("faculityId");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .HasColumnName("phone")
                    .IsFixedLength();

                entity.Property(e => e.Yearid).HasColumnName("yearid");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Department");

                entity.HasOne(d => d.Faculity)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.FaculityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Faculty");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Yearid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_studyyear");
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => e.ScId)
                    .HasName("PK__StudentC__3215821D6D532D9D");

                entity.ToTable("StudentCourse");

                entity.HasIndex(e => e.CourseId, "IX_StudentCourse_courseId");

                entity.HasIndex(e => e.StudentId, "IX_StudentCourse_studentId");

                entity.Property(e => e.ScId).HasColumnName("scId");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_StudentCourse_Course");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentCourses)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentCourse_Student");
            });

            modelBuilder.Entity<StudentExamOnLine>(entity =>
            {
                entity.ToTable("StudentExamOnLine");

                entity.HasIndex(e => e.ExamId, "IX_StudentExamOnLine_examId");

                entity.HasIndex(e => e.StudentId, "IX_StudentExamOnLine_studentId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ExamDate)
                    .HasColumnType("date")
                    .HasColumnName("examDate");

                entity.Property(e => e.ExamId).HasColumnName("examId");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mark).HasColumnName("mark");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.StudentExamOnLines)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK_StudentExamOnLine_OnlineExam");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentExamOnLines)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentExamOnLine_Student");
            });

            modelBuilder.Entity<StudentLecture>(entity =>
            {
                entity.HasKey(e => e.SlId)
                    .HasName("PK__StudentL__32DCE1E7526EF8FF");

                entity.ToTable("StudentLecture");

                entity.HasIndex(e => e.LectureId, "IX_StudentLecture_lectureId");

                entity.HasIndex(e => e.StudentId, "IX_StudentLecture_studentId");

                entity.Property(e => e.SlId).HasColumnName("slId");

                entity.Property(e => e.DownloadDate)
                    .HasColumnType("date")
                    .HasColumnName("downloadDate");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsFav).HasColumnName("isFav");

                entity.Property(e => e.LectureId).HasColumnName("lectureId");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.ViewDate)
                    .HasColumnType("date")
                    .HasColumnName("viewDate");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.StudentLectures)
                    .HasForeignKey(d => d.LectureId)
                    .HasConstraintName("FK_StudentLecture_Lecture");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentLectures)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentLecture_Student");
            });

            modelBuilder.Entity<StudentNote>(entity =>
            {
                entity.HasKey(e => e.NoteId)
                    .HasName("PK__StudentN__03C97EFDB06B1A33");

                entity.HasIndex(e => e.LectureId, "IX_StudentNotes_lectureId");

                entity.HasIndex(e => e.StudentId, "IX_StudentNotes_studentId");

                entity.Property(e => e.NoteId).HasColumnName("noteId");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LectureId).HasColumnName("lectureId");

                entity.Property(e => e.NoteText)
                    .HasMaxLength(300)
                    .HasColumnName("noteText");

                entity.Property(e => e.Page).HasColumnName("page");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.StudentNotes)
                    .HasForeignKey(d => d.LectureId)
                    .HasConstraintName("FK_StudentNotes_Lecture");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentNotes)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentNotes_Student");
            });

            modelBuilder.Entity<StudentPresense>(entity =>
            {
                entity.ToTable("StudentPresense");

                entity.HasIndex(e => e.LectureId, "IX_StudentPresense_lectureId");

                entity.HasIndex(e => e.StudentId, "IX_StudentPresense_studentId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LectureId).HasColumnName("lectureId");

                entity.Property(e => e.PresenseDate)
                    .HasColumnType("date")
                    .HasColumnName("presenseDate");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.StudentPresenses)
                    .HasForeignKey(d => d.LectureId)
                    .HasConstraintName("FK_StudentPresense_OnlineLecture");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentPresenses)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentPresense_Student");
            });

            modelBuilder.Entity<StudentRegister>(entity =>
            {
                entity.HasKey(e => e.SrId)
                    .HasName("PK__StudentR__36B01FFD2A9D488D");

                entity.ToTable("StudentRegister");

                entity.HasIndex(e => e.CobonId, "IX_StudentRegister_cobonId");

                entity.HasIndex(e => e.StudentId, "IX_StudentRegister_studentId");

                entity.HasIndex(e => e.TypeId, "IX_StudentRegister_typeId");

                entity.Property(e => e.SrId).HasColumnName("srId");

                entity.Property(e => e.CobonId).HasColumnName("cobonId");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPaid).HasColumnName("isPaid");

                entity.Property(e => e.IsValid).HasColumnName("isValid");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("date")
                    .HasColumnName("registerDate");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.HasOne(d => d.Cobon)
                    .WithMany(p => p.StudentRegisters)
                    .HasForeignKey(d => d.CobonId)
                    .HasConstraintName("FK_StudentRegister_Cobon");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentRegisters)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentRegister_Student");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.StudentRegisters)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_StudentRegister_RegisterationType");
            });

            modelBuilder.Entity<StudentRegisterOnline>(entity =>
            {
                entity.ToTable("StudentRegisterOnline");

                entity.HasIndex(e => e.CourseId, "IX_StudentRegisterOnline_CourseId");

                entity.HasIndex(e => e.StudentId, "IX_StudentRegisterOnline_StudentId");

                entity.HasIndex(e => e.CobonId, "IX_StudentRegisterOnline_cobonId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CobonId).HasColumnName("cobonId");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Review).HasColumnName("review");

                entity.HasOne(d => d.Cobon)
                    .WithMany(p => p.StudentRegisterOnlines)
                    .HasForeignKey(d => d.CobonId)
                    .HasConstraintName("FK_StudentRegisterOnline_OnlineCobon");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentRegisterOnlines)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_StudentRegisterOnline_OnLineCourse");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentRegisterOnlines)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentRegisterOnline_Student");
            });

            modelBuilder.Entity<Studyyear>(entity =>
            {
                entity.ToTable("studyyear");

                entity.HasIndex(e => e.Deptid, "IX_studyyear_deptid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deptid).HasColumnName("deptid");

                entity.Property(e => e.Yearname)
                    .HasMaxLength(10)
                    .HasColumnName("yearname")
                    .IsFixedLength();

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Studyyears)
                    .HasForeignKey(d => d.Deptid)
                    .HasConstraintName("FK_studyyear_Department");
            });

            modelBuilder.Entity<SubCatogary>(entity =>
            {
                entity.ToTable("Sub_catogary");

                entity.Property(e => e.CatogaryId).HasColumnName("Catogary_id");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Catogary)
                    .WithMany(p => p.SubCatogaries)
                    .HasForeignKey(d => d.CatogaryId)
                    .HasConstraintName("FK_Sub_catogary_Catogary");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.TeacherId).HasColumnName("teacherId");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description")
                    .IsFixedLength();

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Photo)
                    .HasMaxLength(400)
                    .HasColumnName("photo");
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.ToTable("University");

                entity.Property(e => e.UniversityId).HasColumnName("universityId");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UniversityName)
                    .HasMaxLength(100)
                    .HasColumnName("universityName");
            });

            modelBuilder.Entity<Writer>(entity =>
            {
                entity.ToTable("Writer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Image)
                    .HasColumnType("image")
                    .HasColumnName("image");

                entity.Property(e => e.Information)
                    .HasMaxLength(100)
                    .HasColumnName("information");

                entity.Property(e => e.Name).HasMaxLength(100);
            });
            modelBuilder.Entity<Buying>(entity =>
            {
                entity.ToTable("Buying");

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.clientId).HasColumnName("clientId");
                entity.Property(e => e.bookID).HasColumnName("bookID");
                entity.Property(e => e.BuyingDate)
                .HasColumnType("date")
                .HasColumnName("BuyingDate");



            });
            modelBuilder.Entity<ClientCobon>(entity =>
            {
                entity.ToTable("ClientCobon");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("ClientId");
                entity.Property(e => e.CobonId).HasColumnName("CobonId");
                entity.Property(e => e.CobonDate)
                .HasColumnType("date")
                .HasColumnName("CobonDate");



            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
