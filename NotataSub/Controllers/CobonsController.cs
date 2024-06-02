using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BarcodeLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotataSub.Models;
using QRCoder;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NotataSub.Controllers
{
    public class CobonsController : Controller
    {
        private readonly StudyHubContext _context;

        public CobonsController(StudyHubContext context)
        {
            _context = context;
        }

      
        public async Task<IActionResult> Index()
        {
            var sub = from cobons in _context.Cobons
                      where cobons.IsValid == true

                      group new { cobons } by new { cobons.CobonValue, cobons.ReleaseDate}
                       into v

                      select new selectModel
                      {

                          cobonvalue = v.Key.CobonValue,
                          ReleaseDate = v.Key.ReleaseDate,
                          coboncount = v.Count(),
                         // CobonNumber=v.CobonNumber


                      };
           

            return View(sub);
        }

        public IActionResult QRCodeIndex()
        {
            return View();
        }




        public async Task<IActionResult> InvalidCobobn()
        {
            var sub = from cobons in _context.Cobons
                      where cobons.IsValid == false

                      group new { cobons } by new { cobons.CobonValue, cobons.ReleaseDate }
                       into v

                      select new selectModel
                      {

                          cobonvalue = v.Key.CobonValue,
                          ReleaseDate = v.Key.ReleaseDate,


                          coboncount = v.Count(),


                      };


            return Json(sub);
        }

        // GET: Cobons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobon = await _context.Cobons
                .FirstOrDefaultAsync(m => m.CobonId == id);
            if (cobon == null)
            {
                return NotFound();
            }

            return View(cobon);
        }

        // GET: Cobons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cobons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CobonId,CobonValue,CobonNumber,IsValid,ReleaseDate,IsDeleted")] Cobon cobon,int number)
        {
            if (ModelState.IsValid)
            {


                for (int i = 1; i <= number; i++)
                {
                    Cobon cobon1 = new Cobon();
                    var date = DateTime.Now;
                    cobon1.CobonValue = cobon.CobonValue;
                    cobon1.IsDeleted = false;
                    cobon1.CobonNumber = generateCobonNumber(); //(date.Year + date.Month + date.Day).ToString();
                    cobon1.ReleaseDate = date;
                    cobon1.IsValid = true;
                    _context.Add(cobon1);
                    await _context.SaveChangesAsync();
                }
                // _context.Add(cobon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cobon);
        }

        // GET: Cobons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobon = await _context.Cobons.FindAsync(id);
            if (cobon == null)
            {
                return NotFound();
            }
            return View(cobon);
        }

        // POST: Cobons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CobonId,CobonValue,CobonNumber,IsValid,ReleaseDate,IsDeleted")] Cobon cobon)
        {
            if (id != cobon.CobonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cobon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CobonExists(cobon.CobonId))
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
            return View(cobon);
        }

        // GET: Cobons/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobon = await _context.Cobons.Where(c=>c.IsValid==false)
                .FirstOrDefaultAsync(m => m.CobonValue == id);
            var cobons =  _context.Cobons.Where(c => c.IsValid == false && c.CobonValue == id).Count();
            ViewBag.count = cobons;

            if (cobon == null)
            {
                return NotFound();
            }

            return View(cobon);
           
        }

        // POST: Cobons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            //var cobon = await _context.Cobons.FindAsync(id);
            //_context.Cobons.Remove(cobon);
            //await _context.SaveChangesAsync();
            var cobon = _context.Cobons.Where(c => c.CobonValue == id && c.IsValid == false);
            foreach (var item in cobon)
            { 
                 
                _context.Cobons.Remove(item);

            }
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool CobonExists(int id)
        {
            return _context.Cobons.Any(e => e.CobonId == id);
        }

        public String generateCobonNumber()
        {
            Cobon cobon=_context.Cobons.FirstOrDefault();
            
            int max = _context.Cobons.Max(c => c.CobonId);
            string date = DateTime.Now.ToString("yyyyMMdd")+"0000" +max;
            return date;

           
        }

        public IActionResult GenerateBarCode(string code = "112233")
        {
            Barcode barcode = new Barcode();
            Image img = barcode.Encode(TYPE.CODE39, code, Color.Black, Color.White, 250, 100);
            var data = ConvertImageToByte(img);
            return File(data, "image/jpeg");
        }
        private byte[] ConvertImageToByte(Image img)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                img.Save(memoryStream, ImageFormat.Png);
                return memoryStream.ToArray();
            }

        }


        public IActionResult GenerateQR(string code = "hello")
        {
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qRCodeData);
            Bitmap bitmap = qRCode.GetGraphic(15);
            var bitmapBytes = ConvertBitmapToByte(bitmap);
            return File(bitmapBytes, "image/jpeg", code + ".jpeg");
        }

        private byte[] ConvertBitmapToByte(Bitmap bitmap)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Png);
                return memoryStream.ToArray();

            }

        }


        public IActionResult Cobondetails(int id)

        {
            var list = _context.Cobons.Where(c => c.CobonValue == id && c.IsValid == true).ToList();
            return View(list);
        }
    }
}
