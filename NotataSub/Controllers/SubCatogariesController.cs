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
    public class SubCatogariesController : Controller
    {
        private readonly StudyHubContext _context;

        public SubCatogariesController(StudyHubContext context)
        {
            _context = context;
        }

        // GET: SubCatogaries
        public async Task<IActionResult> Index()
        {
            var studyHubContext = _context.SubCatogaries.Include(s => s.Catogary);
            return View(await studyHubContext.ToListAsync());
        }

        // GET: SubCatogaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCatogary = await _context.SubCatogaries
                .Include(s => s.Catogary)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCatogary == null)
            {
                return NotFound();
            }

            return View(subCatogary);
        }

        // GET: SubCatogaries/Create
        public IActionResult Create()
        {
            ViewData["CatogaryId"] = new SelectList(_context.Catogaries, "Id", "Name");
            return View();
        }

        // POST: SubCatogaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CatogaryId,Name")] SubCatogary subCatogary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subCatogary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatogaryId"] = new SelectList(_context.Catogaries, "Id", "Name", subCatogary.CatogaryId);
            return View(subCatogary);
        }

        // GET: SubCatogaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCatogary = await _context.SubCatogaries.FindAsync(id);
            if (subCatogary == null)
            {
                return NotFound();
            }
            ViewData["CatogaryId"] = new SelectList(_context.Catogaries, "Id", "Name", subCatogary.CatogaryId);
            return View(subCatogary);
        }

        // POST: SubCatogaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CatogaryId,Name")] SubCatogary subCatogary)
        {
            if (id != subCatogary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subCatogary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubCatogaryExists(subCatogary.Id))
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
            ViewData["CatogaryId"] = new SelectList(_context.Catogaries, "Id", "Name", subCatogary.CatogaryId);
            return View(subCatogary);
        }

        // GET: SubCatogaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCatogary = await _context.SubCatogaries
                .Include(s => s.Catogary)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCatogary == null)
            {
                return NotFound();
            }

            return View(subCatogary);
        }

        // POST: SubCatogaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCatogary = await _context.SubCatogaries.FindAsync(id);
            _context.SubCatogaries.Remove(subCatogary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubCatogaryExists(int id)
        {
            return _context.SubCatogaries.Any(e => e.Id == id);
        }
    }
}
