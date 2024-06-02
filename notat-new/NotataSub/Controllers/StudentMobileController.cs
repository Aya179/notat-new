using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using NotataSub.Helpers;
using System.Collections.Generic;
using System.Linq;
using NotataSub.Models;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace NotataSub.Controllers
{
    public class StudentMobileController : Controller
    {
        private StudyHubContext context;
        private readonly IWebHostEnvironment _env;

        public StudentMobileController(StudyHubContext context, IWebHostEnvironment _env)
        {
            this.context = context;
            this._env = _env;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult getStudentCourse(int studentId)
        {
            Student dept = context.Students.Where(f => f.StudentId == studentId).First();
           
           List<Course> studcourses = new List<Course>();
            Course[] courses = context.Courses.Where(c => c.DepartmentId == dept.DepartmentId).ToArray();

            for (int i = 0; i < courses.Length; i++)
            {
               // if (courses[i].Year == dept.Yearid)
                {
                    courses[i].Lectures = null;
                    courses[i].StudentCourses = null;
                    courses[i].CourseExams = null;
                    courses[i].CourseAttachements = null;
                    courses[i].Department = null;
                    studcourses.Add(courses[i]);
                }
            }
            return Ok(new { courses = studcourses.ToArray() });
        }


        public IActionResult getLastLectures(int studentId)
        {
            Student dept = context.Students.Where(f => f.StudentId == studentId).First();

            List<Course> studcourses = new List<Course>();
            Course[] courses = context.Courses.Where(c => c.DepartmentId == dept.DepartmentId).ToArray();
            Console.WriteLine(courses.Length.ToString());
            List<Lecture> lectures = new List<Lecture>();
            for (int i = 0; i < courses.Length; i++)
            {
                Lecture[] lects = context.Lectures.Where(d => d.CourseId == courses[i].CourseId).ToArray();
                System.Diagnostics.Debug.WriteLine("all lects are "+ lects.Length.ToString());
                for (int j = 0; j < lects.Length; j++)
                {
                    System.Diagnostics.Debug.WriteLine("current count is " + lectures.Count.ToString());


                    Lecture lec = new Lecture();
                    lec.CourseId = lects[j].CourseId;
                    lec.IsDeleted = lects[j].IsDeleted;
                    lec.LectureId = lects[j].LectureId;
                    lec.LectureNum = lects[j].LectureNum;
                    lec.Linkurl = lects[j].Linkurl;
                    lec.Pages = lects[j].Pages;
                    lec.Price = lects[j].Price;
                    lec.PublishDate = lects[j].PublishDate;
                    lec.Title = lects[j].Title;
                    lec.Yearid = lects[j].Yearid;
                   lectures.Add(lec);
                    System.Diagnostics.Debug.WriteLine("current count is "+ lectures.Count.ToString());

                }
            }
            System.Diagnostics.Debug.WriteLine(lectures.Count.ToString());

            //lectures.Sort(new Comparison<Lecture>((i1, i2) => (i1.PublishDate.Value.CompareTo(i2.PublishDate.Value))));
            if (lectures.Count >= 12)
                return Ok(new { lectures = lectures.Take(12).ToArray() });
            else
                return Ok(new { lectures = lectures.ToArray() });
        }
        public IActionResult getUniversities()
        {
            return Ok(new { universities = context.Universities.ToArray() });
        }


        public IActionResult getNews()
        {
            return Ok(new { news = context.News.ToArray() });
        }
        public IActionResult addFaculty(string facultyName, int universityId)
        {
            Faculty fac = new Faculty();
            fac.Name = facultyName;
            fac.IsDeleted = false;
            fac.UniersityId = universityId;
            fac = context.Faculties.Add(fac).Entity;
            context.SaveChanges();
            return Ok(new { faculty = fac });
        }

        public IActionResult addDepartment(string departmentName, int facultyId, int universityId)
        {
            Department dept = new Department();
            dept.DepartmentName = departmentName;
            dept.FacultyId = facultyId;
            dept.IsDeleted = false;
            dept.UniversityId = universityId;
            dept = context.Departments.Add(dept).Entity;
            context.SaveChanges();
            dept.Courses = null;
            dept.Faculty = null;
            dept.University = null;
            dept.Students = null;
            dept.Studyyears = null;

            return Ok(new { department = dept });
        }
        public IActionResult addUniversity(string universityName, string City)
        {
            University univesity = new University();
            univesity.City = City;
            univesity.UniversityName = universityName;
            univesity.IsDeleted = false;
            univesity = context.Universities.Add(univesity).Entity;
            context.SaveChanges();
            return Ok(new { University = univesity });
        }



        public IActionResult getFaculties(int universityId)
        {
            return Ok(new { faculties = context.Faculties.Where(c => c.UniersityId == universityId).ToArray() });
        }

        public IActionResult getDepartments(int facultyId)
        {
            return Ok(new { faculties = context.Departments.Where(c => c.FacultyId == facultyId).ToArray() });
        }

        public IActionResult getStudyYear(int DepartmentId)
        {
            return Ok(new { Departments = context.Studyyears.Where(c => c.Deptid == DepartmentId).ToArray() });
        }

        [HttpPost]
        public IActionResult addStudent(string studName, string email, string password, string mobileNum, string birthdate, string city,
       int facId, int departmentId, int StudyyearId)
        {
            Student student = new Student();
            student.Birthdate = DateTime.Parse(birthdate);
            student.City = city;
            student.DepartmentId = departmentId;
            student.Email = email;
            student.FaculityId = facId;
            student.Name = studName;
            student.Password = password;
            student.Phone = mobileNum;
            student.Yearid = StudyyearId;
            student.Isactive = true;
            student.IsDeleted = false;
            student = context.Add(student).Entity;
            context.SaveChanges();
            Course[] courses = context.Courses.Where(e => e.DepartmentId == departmentId && e.Year == StudyyearId).ToArray();
            for (int i = 0; i < courses.Length; i++)
            {
                StudentCourse studentCourse = new StudentCourse();
                studentCourse.CourseId = courses[i].CourseId;
                studentCourse.StudentId = student.StudentId;
                context.Add(studentCourse);
                context.SaveChanges();
            }
            student.StudentCourses = null;
            student.StudentExamOnLines = null;
            student.StudentLectures = null;
            student.StudentNotes = null;
            student.StudentPresenses = null;
            student.StudentRegisterOnlines = null;
            student.StudentRegisters = null;
            student.Year = null;
            student.Department = null;
            student.Faculity = null;

            return Ok(new { student = student });

        }


        [HttpPost]
        public StudentCourse setStudentCourse(int studentId, int courseId)
        {
            StudentCourse studentCourse = new StudentCourse();
            studentCourse.CourseId = courseId;
            studentCourse.StudentId = studentId;
            context.Add(studentCourse);
            context.SaveChanges();
            return studentCourse;
        }



        [HttpGet]
        public Course[] getFaculityCourses(int facId)
        {

            return context.Courses.Where(p => p.FacultyId == facId).ToArray();
        }


        public IActionResult getCourseLecture(int studentId, int courseId)
        {
            Student stud = context.Students.Where(o => o.StudentId == studentId).First();
            Lecture[] lectures = context.Lectures.Where(c =>  c.CourseId == courseId).ToArray();
            for (int i = 0; i < lectures.Length; i++)
            {
                lectures[i].Course = null;
                lectures[i].StudentLectures = null;
                lectures[i].StudentNotes = null;
                lectures[i].Year = null;
            }
            return Ok(new { Lectures = lectures });

        }

        public IActionResult getLecture(int lectureId)
        {
            Lecture lecture = context.Lectures.Where(c => c.LectureId == lectureId).First();
            lecture.StudentLectures = null;
            lecture.StudentNotes = null;
            lecture.Year = null;
            return Ok(new { lecture = lecture });
        }

        public IActionResult addnNews(string newsText, string newsUrl)
        {
            News news = new News();
            news.Faculty = null;
            news.FacultyId = 1;
            news.NewsText = newsText;
            news.NewsUrl=newsUrl;
            context.News.Add(news);
            context.SaveChanges();
            return Ok(new { news = newsText });
        }
        public IActionResult getLectureFirstPages(int lectureId)
        {

            byte[] buff = null;
            Lecture lecture = context.Lectures.Where(p => p.LectureId == lectureId).First();
            //var provider = new PhysicalFileProvider(_env.WebRootPath);
            //var contents = provider.GetDirectoryContents(Path.Combine(
            string fileName = Path.Combine(_env.WebRootPath,Helper.lecturesPath + lecture.LectureId.ToString() +"/image-00001-01.jpg");
            Console.WriteLine(fileName);
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);

            return Ok(new { page = buff });
        }


        [HttpGet]
        public IActionResult getLecturePage(int lectureId, int pageId)
        {
            byte[] buff = null;
            Lecture lecture = context.Lectures.Where(p => p.LectureId == lectureId).First();
            string fileName = Path.Combine(_env.WebRootPath, Helper.lecturesPath + lecture.LectureId.ToString() + "/" + pageId.ToString() + ".jpg");
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return Ok(new { page = buff });

        }


        [HttpGet]
        public IActionResult getLecturePages(int lectureId)
        {
            byte[] buff = null;
            Lecture lecture = context.Lectures.Where(p => p.LectureId == lectureId).First();
            string dirName = Path.Combine(_env.WebRootPath, Helper.lecturesPath + lecture.LectureId.ToString() );
            String[] files = Directory.GetFiles(dirName);
            List<Helpers.LectureData> pages = new List<LectureData>();
            for(int i = 0; i < files.Length; i++)
            {
                FileStream fs = new FileStream(files[i], FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                long numBytes = new FileInfo(files[i]).Length;
                buff = br.ReadBytes((int)numBytes);
                string finalName = files[i].Split("-")[files[i].Split("-").Length - 1];
                if(!finalName.EndsWith('p'))
                {
                    int pagenum = int.Parse(finalName.Substring(0, finalName.Length - 4));
                    pages.Add(new LectureData(pagenum, finalName, buff));

                }
            }
            return Ok(new { pages = pages });

        }
    }
}
