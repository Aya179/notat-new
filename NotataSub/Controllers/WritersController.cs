using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotataSub.Models;

namespace NotataSub.Controllers
{
    public class WritersController : Controller
    {
        private readonly StudyHubContext _context;

        public WritersController(StudyHubContext context)
        {
            _context = context;
        }

        // GET: Writers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Writers.ToListAsync());
        }

        // GET: Writers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writer = await _context.Writers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (writer.Image != null)
            {

                string imageBase64Data =
    Convert.ToBase64String(writer.Image);
                string imageDataURL =
            string.Format("data:image/jpg;base64,{0}",
            imageBase64Data);
                //ViewBag.ImageTitle = img.ImageTitle;
                ViewBag.ImageDataUrl = imageDataURL;
            }
            if (writer == null)
            {
                return NotFound();
            }

            return View(writer);
        }

        // GET: Writers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Writers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Information,Image")] Writer writer)
        {
            if (ModelState.IsValid)
            {


                foreach (var file in Request.Form.Files)
                {


                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    writer.Image = ms.ToArray();

                    ms.Close();
                    ms.Dispose();



                }
                _context.Add(writer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(writer);
        }

        // GET: Writers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writer = await _context.Writers.FindAsync(id);
            if (writer == null)
            {
                return NotFound();
            }
            return View(writer);
        }

        // POST: Writers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Information,Image")] Writer writer)
        {
            if (id != writer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(writer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WriterExists(writer.Id))
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
            return View(writer);
        }

        // GET: Writers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var writer = await _context.Writers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (writer == null)
            {
                return NotFound();
            }

            return View(writer);
        }

        // POST: Writers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var writer = await _context.Writers.FindAsync(id);
            _context.Writers.Remove(writer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WriterExists(int id)
        {
            return _context.Writers.Any(e => e.Id == id);
        }
    }
}
