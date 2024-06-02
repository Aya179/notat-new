using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NotataSub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotataSub.Controllers
{

    public class HomeController : Controller
    {
        private readonly StudyHubContext _context;

        public HomeController(StudyHubContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            Notatbager();
            return View();
        }
       
        [Authorize]

        public IActionResult Index2()
        {
            bager();
            return View();
        }

        public void Notatbager()
        {
            ViewBag.Coursecount = _context.Courses.Count();
            ViewBag.Facultycount = _context.Faculties.Count();
            ViewBag.Departmentcount = _context.Departments.Count();
            ViewBag.Teachercount = _context.Teachers.Count();



        }


        public void bager()
        {
            ViewBag.count = _context.Books.Count();
            ViewBag.count1 = _context.Writers.Count();
            ViewBag.count2 = _context.Clients.Count();
            ViewBag.count3 = _context.Catogaries.Count();



        }

        public IActionResult TOp5Clients()
        {


            var sub = from buy in _context.Buyings
                      join book in _context.Books on buy.bookID equals book.Id
                      // join client in _context.Clients on buy.clientId equals client.Id

                      select new selectModel
                      {
                          Booktitle = book.Title,
                          // clientName = client.FirstName + " " + client.LastName,
                          //BuyingDate = buy.BuyingDate
                          BookId = book.Id,
                          BookPrice = (decimal)book.Price




                      };
            var y = sub.OrderByDescending(f => f.BookId)
               .Take(5)
               .ToList();




            return Json(y);

        }


        public IActionResult Top5teacher()
        {
            var sub = from Course in _context.Courses
                      join teacher in _context.Teachers on Course.Teacher equals teacher.Name
                      //join teacher in _context.Teachers on teacher.TeacherId equals Course.Teacher
                      group new { Course } by new { Course.CourseId }
            into v
                      select new
                      {
                          cId = v.Key.CourseId,
                         
                          //count = v.Count()

                      };
            var y = sub.ToList();
            var query = from course in _context.Courses
                    join vs in sub on course.CourseId equals vs.cId
                        join teachse in _context.Teachers on course.Teacher equals teachse.Name


                        select new
                        {
                            courseName = course.CourseName,
                            TeacherName = teachse.Name
                            //count2 = vs.count
                        }
                        ;
            var x = query
              .ToList();




            return Json(x);

        }

        public IActionResult Top5Course()
        {

            var sub = from StudentCourse in _context.StudentCourses
                      join course in _context.Courses on StudentCourse.CourseId equals course.CourseId
                      group new { StudentCourse } by new { StudentCourse.CourseId, StudentCourse .StudentId}
            into v
                      select new
                      {
                          cId = v.Key.CourseId,
                          SId = v.Key.StudentId,
                          count = v.Count()

                      };
            var y = sub.ToList();
            var query = from course in _context.Courses
                        join vs in sub on course.CourseId equals vs.cId
                        join student in _context.Students on vs.SId  equals student.StudentId
                        
                        
                        select new 
                        {
                            courseName = course.CourseName,
                            StudentName = student.Name ,
                            count2 = vs.count
                        }
                        ;
            var x = query.Take(5)
              .ToList();




            return Json(x);

        }
    }
}
