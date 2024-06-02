using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotataSub.Models;


namespace NotataSub.Controllers
{
    public class NotatReportsController : Controller
    {
        private readonly StudyHubContext _context;

        public NotatReportsController(StudyHubContext context)
        {
            _context = context;
        }
        public IActionResult TeacherCourse(string name)
        {
            var teacher = _context.Courses.Where(t => t.Teacher == name).Include(t=>t.Department).Include(o=>o.Faculty)
                .ToList();
            return Json(teacher);
            
        }
        public IActionResult TeacherCourseView()
        {
            ViewData["teacher"] = new SelectList(_context.Teachers, "Name", "Name");
            return View();

        }

        public IActionResult StudentCourseView()
        {
            ViewData["Students"] = new SelectList(_context.Students, "StudentId", "Name");

            return View();
        }
        public IActionResult StudentCourse(int id)
        {
            var sub = from studentcourse in _context.StudentCourses//buy
                      join course in _context.Courses on studentcourse.CourseId equals course.CourseId
                      join student in _context.Students on studentcourse.StudentId equals student.StudentId

                      select new 
                      {
                          sudentname=student.Name,
                          coursename=course.CourseName,
                          courseprice=course.Price,
                          courseTeacher=course.Teacher,
                          coursesemestere=course.Semester




                      };
            var y = sub.ToList();


            return Json(y);



        }

        public IActionResult CourseView()
        {
            return View();
        }
        public IActionResult Course()
        {

            var sub = from course in _context.Courses
                      join lectuer in _context.Lectures on course.CourseId equals lectuer.CourseId
                      group new { course ,lectuer} by new { course.CourseId,lectuer.LectureId }
            into v
                      select new
                      {
                          lId = v.Key.LectureId,
                          cId = v.Key.CourseId,
                          count = v.Count()

                      };
            var y = sub.ToList();
            var query = from course2 in _context.Courses
                        join vs in sub on course2.CourseId  equals vs.cId
                        select new 
                        {
                            coursename=course2.CourseName,
                            courseTeacher=course2.Teacher,
                            count = vs.count
                        }
                        ;
            var x = query
              .ToList();




            return Json(x);

        }


    }
}
