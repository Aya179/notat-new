using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using NotataSub.Helpers;
using NotataSub.Models;
using NotataSub.ViewModels;

namespace NotataSub.Controllers
{
    public class LecturesController : Controller
    {
        private readonly StudyHubContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public LecturesController(StudyHubContext context , IWebHostEnvironment env , IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;
        }

        // GET: Lectures
        public async Task<IActionResult> Index()
        {
            var studyHubContext = _context.Lectures.Include(l => l.Course).Include(l => l.Year);
            return View(await studyHubContext.ToListAsync());
        }

        // GET: Lectures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lectures
                .Include(l => l.Course)
                .Include(l => l.Year)
                .FirstOrDefaultAsync(m => m.LectureId == id);
            if (lecture == null)
            {
                return NotFound();
            }

            var provider = new PhysicalFileProvider(_env.WebRootPath);
            var contents = provider.GetDirectoryContents(Path.Combine(Helper.lecturesPath , lecture.LectureId.ToString() , lecture.Linkurl));
            var objFiles = contents.OrderBy(m => m.LastModified);

            List<string> ImageList = new List<string>();
            foreach (var item in objFiles.ToList())
            {
                ImageList.Add(Path.Combine("/" , Helper.lecturesPath, Path.Combine(lecture.LectureId.ToString(), lecture.Linkurl , item.Name)));
            }

            ViewBag.ImageList = ImageList;

            return View(lecture);
        }

        // GET: Lectures/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            ViewData["Yearid"] = new SelectList(_context.Studyyears, "Id", "Yearname");


            return View();
        }

        // POST: Lectures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LectureCreate lectureCreate)
        {
            if (ModelState.IsValid)
            {
                Lecture lecture = new Lecture();

                lecture = _mapper.Map<Lecture>(lectureCreate);
                int fileExtPos = lectureCreate.LectureFile.FileName.LastIndexOf(".");
                if (fileExtPos >= 0)
                    lecture.Linkurl = lectureCreate.LectureFile.FileName.Substring(0, fileExtPos);
                else
                    lecture.Linkurl = "";

                _context.Add(lecture);

        

                await _context.SaveChangesAsync();

                var uploadsFolderPath = Path.Combine(_env.WebRootPath, Helper.lecturesPath);



                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }


                var uploadsFolderPath2 = Path.Combine(_env.WebRootPath, Helper.lecturesPath + lecture.LectureId);
                if (!Directory.Exists(uploadsFolderPath2))
                {
                    Directory.CreateDirectory(uploadsFolderPath2);
                }


                string filePath = Path.Combine(uploadsFolderPath2, lectureCreate.LectureFile.FileName);

                using (var imageFile = new FileStream(filePath, FileMode.Create))
                {

                    await lectureCreate.LectureFile.CopyToAsync(imageFile);
                }

                 ZipFile.ExtractToDirectory(filePath, Path.Combine(_env.WebRootPath, Helper.lecturesPath + lecture.LectureId));



                _context.Update(lecture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(lectureCreate);
        }

        // GET: Lectures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lectures.FindAsync(id);
            if (lecture == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", lecture.CourseId);
            ViewData["Yearid"] = new SelectList(_context.Studyyears, "Id", "Yearname", lecture.Yearid);
            return View(lecture);
        }

        // POST: Lectures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LectureNum,Title,PublishDate,CourseId,Pages,LectureId,IsDeleted,Price,Yearid,Linkurl")] Lecture lecture)
        {
            if (id != lecture.LectureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lecture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LectureExists(lecture.LectureId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", lecture.CourseId);
            ViewData["Yearid"] = new SelectList(_context.Studyyears, "Id", "Yearname", lecture.Yearid);
            return View(lecture);
        }

        // GET: Lectures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lectures
                .Include(l => l.Course)
                .Include(l => l.Year)
                .FirstOrDefaultAsync(m => m.LectureId == id);
            if (lecture == null)
            {
                return NotFound();
            }

            return View(lecture);
        }

        // POST: Lectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lecture = await _context.Lectures.FindAsync(id);
            _context.Lectures.Remove(lecture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LectureExists(int id)
        {
            return _context.Lectures.Any(e => e.LectureId == id);
        }
    }
}
