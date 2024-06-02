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
    public class CatogariesController : Controller
    {
        private readonly StudyHubContext _context;

        public CatogariesController(StudyHubContext context)
        {
            _context = context;
        }

        // GET: Catogaries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Catogaries.ToListAsync());
        }

        // GET: Catogaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catogary = await _context.Catogaries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catogary == null)
            {
                return NotFound();
            }

            return View(catogary);
        }

        // GET: Catogaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catogaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Image")] Catogary catogary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catogary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catogary);
        }

        // GET: Catogaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catogary = await _context.Catogaries.FindAsync(id);
            if (catogary == null)
            {
                return NotFound();
            }
            return View(catogary);
        }

        // POST: Catogaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image")] Catogary catogary)
        {
            if (id != catogary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catogary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatogaryExists(catogary.Id))
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
            return View(catogary);
        }

        // GET: Catogaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catogary = await _context.Catogaries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catogary == null)
            {
                return NotFound();
            }

            return View(catogary);
        }

        // POST: Catogaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catogary = await _context.Catogaries.FindAsync(id);
            _context.Catogaries.Remove(catogary);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatogaryExists(int id)
        {
            return _context.Catogaries.Any(e => e.Id == id);
        }
    }
}
