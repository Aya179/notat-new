using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotataSub.Helpers;
using NotataSub.Models;
using NotataSub.ViewModels;

namespace NotataSub.Controllers
{

    public class BooksController : Controller
    {
        private readonly StudyHubContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public BooksController(StudyHubContext context, IWebHostEnvironment env, IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;
        }


        // GET: Books

        public IActionResult Index()
        {
            var studyHubContext = _context.Books.Include(b => b.Cat);
            return View( studyHubContext.ToList());
        }

        public IActionResult FreeBooks()
        {
            var studyHubContext = _context.Books.Include(b => b.Cat).Where(c=>c.Price==0);
            return View(studyHubContext.ToList());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Cat)
              
                .FirstOrDefaultAsync(m => m.Id == id);


            if (book.Image != null)
            {

                string imageBase64Data =
                Convert.ToBase64String(book.Image);
                string imageDataURL =
                string.Format("data:image/jpg;base64,{0}",
                   imageBase64Data);
                //ViewBag.ImageTitle = img.ImageTitle;
                ViewBag.ImageDataUrl = imageDataURL;
            }
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["CatId"] = new SelectList(_context.Catogaries, "Id", "Name");
            ViewData["WritreId"] = new SelectList(_context.Writers, "Id", "Name");
            ViewData["subId"] = new SelectList(_context.SubCatogaries, "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookCreate bookCreate, IFormFile Image ,string free)
        {
            if (ModelState.IsValid)
            {
                Book book = new Book();
               
                book = _mapper.Map<Book>(bookCreate);
               // foreach (var file in Request.Form.Files)
                //{


                    MemoryStream ms = new MemoryStream();
                // file.CopyTo(ms);
                Image.CopyTo(ms);
                    book.Image = ms.ToArray();

                    ms.Close();
                    ms.Dispose();

                //}

                int fileExtPos = bookCreate.BookFile.FileName.LastIndexOf(".");
                if (fileExtPos >= 0)
                    book.Linkurl = bookCreate.BookFile.FileName.Substring(0, fileExtPos);
                else
                    book.Linkurl = "";

                if (free == "free")
                    book.Price = 0;
                _context.Add(book);
                _context.SaveChanges();


                var uploadsFolderPath = Path.Combine(_env.WebRootPath, Helper.lecturesPath);



                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }


                var uploadsFolderPath2 = Path.Combine(_env.WebRootPath, Helper.lecturesPath + book.Id);
                if (!Directory.Exists(uploadsFolderPath2))
                {
                    Directory.CreateDirectory(uploadsFolderPath2);
                }
                var uploadsFolderPath3 = Path.Combine(uploadsFolderPath2, "des");
                if (!Directory.Exists(uploadsFolderPath3))
                {
                    Directory.CreateDirectory(uploadsFolderPath3);
                }

                string filePath = Path.Combine(uploadsFolderPath2, bookCreate.BookFile.FileName);

                using (var imageFile = new FileStream(filePath, FileMode.Create))
                {
                    
                    bookCreate.BookFile.CopyTo(imageFile);
                }
                var zipFile = ZipFile.OpenRead(filePath);

                var objFiles = zipFile.Entries.FirstOrDefault();
                int lastindex = objFiles.Name.LastIndexOf("_");
                string newlinkurl = objFiles.Name.Substring(0, lastindex);
                book.Linkurl = newlinkurl;
                ZipFile.ExtractToDirectory(filePath, Path.Combine(_env.WebRootPath, Helper.lecturesPath + book.Id));

                string filePathdes = Path.Combine(uploadsFolderPath3, bookCreate.BookDescreption.FileName);

                using (var imageFile = new FileStream(filePathdes, FileMode.Create))
                {
                   
                    bookCreate.BookDescreption.CopyTo(imageFile);
                }

                ZipFile.ExtractToDirectory(filePathdes, uploadsFolderPath3);
               

                _context.Update(book);
                _context.SaveChanges();
                //return RedirectToAction("Create","Books");
                ViewBag.Message = String.Format("Hello{0}.\\ncurrent Date and time:{1}", "world", DateTime.Now.ToString());
                ViewData["CatId"] = new SelectList(_context.Catogaries, "Id", "Name");
                ViewData["WritreId"] = new SelectList(_context.Writers, "Id", "Name");

                return View();
            }
            ViewData["CatId"] = new SelectList(_context.Catogaries, "Id", "Name");
            ViewData["WritreId"] = new SelectList(_context.Writers, "Id", "Name");

            return View();
        }
        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["CatId"] = new SelectList(_context.Catogaries, "Id", "Name", book.CatId);
            ViewData["subId"] = new SelectList(_context.SubCatogaries, "Id", "Name");
            // ViewData["WritreId"] = new SelectList(_context.Writers, "Id", "Name", book.WritreId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CatId,Title,Pages,Price,Year,OtherWriter,WriterName")] Book book, IFormFile BookFile, IFormFile? CancelImage)
        {
            if (id != book.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (CancelImage != null)
                {
                    MemoryStream ms = new MemoryStream();
                    CancelImage.CopyTo(ms);
                    book.Image = ms.ToArray();

                    ms.Close();
                    ms.Dispose();

                    _context.Update(book);
                    _context.SaveChanges();

                }
                else
                {
                    //CatId,Title,Pages,Price,Year,OtherWriter,WriterName
                    var existing = _context.Books.Find(id);
                    existing.CatId = book.CatId;
                    existing.Title = book.Title;
                    existing.Price = book.Price;
                    existing.OtherWriter = book.OtherWriter;
                    existing.WriterName = book.WriterName;
                    _context.Update(existing);
                    _context.SaveChanges();


                }
                if (BookFile == null)
                {
                    //_context.Update(book);
                    //_context.SaveChanges();
                    
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    

                    var uploadsFolderPath = Path.Combine(_env.WebRootPath, Helper.lecturesPath);



                    if (!Directory.Exists(uploadsFolderPath))
                    {
                        Directory.CreateDirectory(uploadsFolderPath);
                    }


                    var uploadsFolderPath2 = Path.Combine(_env.WebRootPath, Helper.lecturesPath + book.Id);
                    var uploadsFolderPath3 = Path.Combine(uploadsFolderPath2, "des");
                    if (Directory.Exists(uploadsFolderPath3))
                    {
                        Directory.Delete(uploadsFolderPath3, true);

                        Directory.CreateDirectory(uploadsFolderPath3);
                    }

                    

                    string filePath = Path.Combine(uploadsFolderPath3, BookFile.FileName);

                    using (var imageFile = new FileStream(filePath, FileMode.Create))
                    {

                        BookFile.CopyTo(imageFile);
                    }
                    var zipFile = ZipFile.OpenRead(filePath);

                    
                    ZipFile.ExtractToDirectory(filePath,uploadsFolderPath3);

                    
                    //_context.Update(book);
                   // _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

            }
            /// ViewData["CatId"] = new SelectList(_context.Catogaries, "Id", "Id", book.CatId);
            //ViewData["WritreId"] = new SelectList(_context.Writers, "Id", "Id", book.WritreId);


            ViewData["CatId"] = new SelectList(_context.Catogaries, "Id", "Name", book.CatId);
            return View(book);



        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Cat)
               
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
        public async Task<IActionResult> ByingBook()
        {
            var sub = from buy in _context.Buyings
                      join book in _context.Books on buy.bookID equals book.Id
                      join client in _context.Clients on buy.clientId equals client.Id

                      select new selectModel
                      {
                          Booktitle = book.Title,
                          clientName=client.FirstName+" "+ client.LastName,
                          BuyingDate=buy.BuyingDate




                          };
                var y = sub.ToList();
            

                return Json(y);


            
        }

        public async Task<IActionResult> ByingBookView()
        {
            return View();
           


        }

        public IActionResult TOp5Books()
        {

                      var sub = from buy in _context.Buyings
                      join book in _context.Books on buy.bookID equals book.Id
                      group new { buy } by new { buy.bookID}
                      into v
                      select new
                      {
                          cId = v.Key.bookID,
                          count=v.Count()

                      };
            var y = sub.ToList();
            var query = from Book in _context.Books
                        join vs in sub on Book.Id equals vs.cId
                        select new selectModel
                        {
                            Booktitle = Book.Title,
                            BookPrice = (decimal)Book.Price,
                            count = vs.count
                        }
                        ;
            var x = query.Take(5)
              .ToList();




            return Json(x);

        }

        public IActionResult ClientBooks()
        {
            var sub = from buy in _context.Buyings
                      join book in _context.Books on buy.bookID equals book.Id
                      join client in _context.Clients on buy.clientId equals client.Id

                      select new selectModel
                      {
                          Booktitle = book.Title,

                         clientName=client.FirstName+" "+client.LastName

                         


                      };
            var y = sub.ToList();







            return Json(y);
        }

        public IActionResult SubCatogary(int id)
        {
            var list = _context.SubCatogaries.Where(s => s.CatogaryId == id).ToList();
            return Json(list);
        }
       
    }
    

}

