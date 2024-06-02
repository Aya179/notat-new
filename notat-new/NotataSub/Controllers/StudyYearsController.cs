using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotataSub.Models;

namespace NotataSub.Controllers
{
    public class StudyYearsController : Controller
    {
        private readonly StudyHubContext _context;

        public StudyYearsController(StudyHubContext context)
        {
            _context = context;
        }

        // GET: StudyYears
        public async Task<IActionResult> Index()
        {
            var studyHubContext = _context.Studyyears.Include(s => s.Dept);
            return View(await studyHubContext.ToListAsync());
        }

        // GET: StudyYears/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyyear = await _context.Studyyears
                .Include(s => s.Dept)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studyyear == null)
            {
                return NotFound();
            }

            return View(studyyear);
        }

        // GET: StudyYears/Create
        public IActionResult Create()
        {
            ViewData["Deptid"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: StudyYears/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Yearname,Deptid")] Studyyear studyyear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studyyear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Deptid"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", studyyear.Deptid);
            return View(studyyear);
        }

        // GET: StudyYears/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyyear = await _context.Studyyears.FindAsync(id);
            if (studyyear == null)
            {
                return NotFound();
            }
            ViewData["Deptid"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", studyyear.Deptid);
            return View(studyyear);
        }

        // POST: StudyYears/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Yearname,Deptid")] Studyyear studyyear)
        {
            if (id != studyyear.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studyyear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudyyearExists(studyyear.Id))
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
            ViewData["Deptid"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", studyyear.Deptid);
            return View(studyyear);
        }

        // GET: StudyYears/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyyear = await _context.Studyyears
                .Include(s => s.Dept)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studyyear == null)
            {
                return NotFound();
            }

            return View(studyyear);
        }

        // POST: StudyYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studyyear = await _context.Studyyears.FindAsync(id);
            _context.Studyyears.Remove(studyyear);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudyyearExists(int id)
        {
            return _context.Studyyears.Any(e => e.Id == id);
        }
    }
}
