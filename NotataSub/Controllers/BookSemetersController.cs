using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotataSub.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NotataSub.Controllers
{
    public class BookSemetersController : Controller
    {
        private readonly StudyHubContext _context;

        public BookSemetersController(StudyHubContext context)
        {
            _context = context;
        }

        // GET: BookSemeters
        public IActionResult Index()
        {
           var result = _context.BookSemeters.ToList()
                .GroupBy(i => i.bookTitle)
                .Select(g => g.FirstOrDefault());
            return View(result);
        }

        // GET: BookSemeters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookSemeter = await _context.BookSemeters
                
                .FirstOrDefaultAsync(m => m.id == id);
            if (bookSemeter == null)
            {
                return NotFound();
            }

            return View(bookSemeter);
        }

        // GET: BookSemeters/Create
        public IActionResult Create()
        {
            ViewData["bookId"] = new SelectList(_context.Books, "Title", "Title");
            return View();
        }

        // POST: BookSemeters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,semeternum,pagenum,bookTitle")] BookSemeter bookSemeter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookSemeter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["bookId"] = new SelectList(_context.Books, "Title", "Title", bookSemeter.bookTitle);
            return View(bookSemeter);
        }

        // GET: BookSemeters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookSemeter = await _context.BookSemeters.FindAsync(id);
            if (bookSemeter == null)
            {
                return NotFound();
            }
            ViewData["bookId"] = new SelectList(_context.Books, "Title", "Title", bookSemeter.bookTitle);
            return View(bookSemeter);
        }

        // POST: BookSemeters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,semeternum,pagenum,bookTitle")] BookSemeter bookSemeter)
        {
            if (id != bookSemeter.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookSemeter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookSemeterExists(bookSemeter.id))
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
            ViewData["bookId"] = new SelectList(_context.Books, "Title", "Title", bookSemeter.bookTitle);
            return View(bookSemeter);
        }

        // GET: BookSemeters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookSemeter = await _context.BookSemeters
                
                .FirstOrDefaultAsync(m => m.id == id);
            if (bookSemeter == null)
            {
                return NotFound();
            }

            return View(bookSemeter);
        }

        // POST: BookSemeters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookSemeter = await _context.BookSemeters.FindAsync(id);
            _context.BookSemeters.Remove(bookSemeter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookSemeterExists(int id)
        {
            return _context.BookSemeters.Any(e => e.id == id);
        }

        public async Task<IActionResult> Semesterdatails(string title)
        {
            var studyHubContext = _context.BookSemeters.Where(s => s.bookTitle== title);

            return View(await studyHubContext.ToListAsync());


        }
    }
}
