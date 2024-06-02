using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using NotataSub.Helpers;
using System.Collections.Generic;
using System.Linq;
using NotataSub.Models;
using System.Threading.Tasks;
using System.IO;
using AutoMapper;


namespace NotataSub.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class mobileController : ControllerBase
    {
        private StudyHubContext context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public mobileController(StudyHubContext context, IWebHostEnvironment _env, IMapper mapper)
        {
            this.context = context;
            this._env = _env;

            _mapper = mapper;

        }


        [HttpPost("addClient")]
        public IActionResult addClient( string password, string email, string phone)
        {
                      var client=context.Clients.Where(c=>c.Phone==phone).FirstOrDefault();
            if (client!=null)
                    {
                return BadRequest("يوجد حساب بهذا الرقم الرجاء استخدام رقم آخر");
            }
            else
            {
                Client c = new Client();
                c.FirstName = "_";
                c.LastName = "_";      
                c.Password = password;
                c.Email = email;
                c.Phone = phone;
                c.balance = 0;
                
                context.Clients.Add(c);
                context.SaveChanges();
                return Ok(c);
            }
        }


       

        [HttpGet("getAllCateg")]
        public IActionResult getAllCateg()
        {
            Catogary[] catogaries = null;
            try
            {
                catogaries = context.Catogaries.ToArray();

                return Ok(new { catogaries = catogaries });
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return Ok(new { catogaries = "hello" });
            }



        }


        [HttpGet("GetSubCat")]
        //https://localhost:44342/api/mobile/GetSubCat?id=2
        public IActionResult GetSubCat(int id)
        {
            SubCatogary[] subCatogaries = context.SubCatogaries.Where(sub => sub.CatogaryId == id).ToArray();

            return Ok(new { subCatogaries =subCatogaries });
        }
        [HttpGet("GetBookByCat")]
        //https://localhost:44342/api/mobile/GetBookByCat?id=1
        public IActionResult GetBookByCat(int id)
        {
          


            var query = (from p in context.Books
                        // join v in context.Writers on p.WritreId equals v.Id
                         where p.subId == id
                         select new
                         {
                             Id = p.Id,
                             CatId = p.CatId,
                             WritreId = p.WriterName,
                             Year = p.Year,
                             Price = p.Price,
                             Pages = p.Pages,
                             Title = p.Title,
                            sub=p.subId,
                             image=p.Image,
                             otherwriter=p.OtherWriter

                         });
            var res = query.ToArray();

            return Ok(new { books = res });
        }

        [HttpGet("GetBookById")]
        //https://localhost:44342/api/mobile/GetBookById?id=1
        public async Task<ActionResult<Book>> GetBookByIdAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var book = (from p in context.Books
                       // join v in context.Writers on p.WritreId equals v.Id
                        where p.Id == id
                        select new
                        {
                            Id = p.Id,
                            CatId = p.CatId,
                            WritreId = p.WriterName,
                            Year = p.Year,
                            Price = p.Price,
                            Pages = p.Pages,
                            Title = p.Title,
                            
                            image=p.Image,
                            otherwriter = p.OtherWriter

                        });

            return Ok(book);
        }


        [HttpGet("GetFirst20Page")]
        // https://localhost:44342/api/mobile/GetFirst20Page?id=24
        public async Task<ActionResult<Book>> GetFirst20Page(int? id)
        {
            byte[] buff = null;
            Book lecture = context.Books.Where(p => p.Id == id).First();
            string dirName = Path.Combine(_env.WebRootPath, Helper.lecturesPath + lecture.Id.ToString());
            String[] files = Directory.GetFiles(dirName);
            List<Helpers.LectureData> pages = new List<LectureData>();
            for (int i = 0; i <=20; i++)
            {
                FileStream fs = new FileStream(files[i], FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                long numBytes = new FileInfo(files[i]).Length;
                buff = br.ReadBytes((int)numBytes);
                string finalName = files[i].Split("-")[files[i].Split("-").Length - 1];
                if (!finalName.EndsWith('p'))
                {
                    int pagenum = int.Parse(finalName.Substring(0, finalName.Length - 4));
                    pages.Add(new LectureData(pagenum, finalName, buff));

                }
            }
            return Ok(new { pages = pages });
        }


        [HttpGet("GetBookDescreption")]
       // https://localhost:44342/api/mobile/GetBookDescreption?id=24
        public async Task<ActionResult<Book>> GetBookDescreption(int? id)
        {
            byte[] buff = null;
            Book lecture = context.Books.Where(p => p.Id == id).First();
            string dirName = Path.Combine(_env.WebRootPath, Helper.lecturesPath + lecture.Id.ToString(),"des");
            String[] files = Directory.GetFiles(dirName);
            List<Helpers.LectureData> pages = new List<LectureData>();
            for (int i = 0; i < files.Length; i++)
            {
                FileStream fs = new FileStream(files[i], FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                long numBytes = new FileInfo(files[i]).Length;
                buff = br.ReadBytes((int)numBytes);
                string finalName = files[i].Split("-")[files[i].Split("-").Length - 1];
                if (!finalName.EndsWith('p'))
                {
                    int pagenum = int.Parse(finalName.Substring(0, finalName.Length - 4));
                    pages.Add(new LectureData(pagenum, finalName, buff));

                }
            }
            return Ok(new { pages = pages });
        }



        [HttpGet("GetLastBooks")]
        //https://localhost:44342/api/mobile/GetLastBooks
        public IActionResult GetLastBooks()
        {
            var query = (from p in context.Books
                        // join v in context.Writers on p.WritreId equals v.Id
                         where p.Year.Value.Year == DateTime.Now.Year
                         select new
                         {
                             Id = p.Id,
                             CatId = p.CatId,
                             WritreId = p.WriterName,
                             Year = p.Year,
                             Price = p.Price,
                             Pages = p.Pages,
                             Title = p.Title,
                            
                             image=p.Image,
                             otherwriter = p.OtherWriter

                         }) ;
            var res = query.ToArray();

            return Ok(new { books = res });
        }

        [HttpGet("logIn")]
        public IActionResult logIn(string phone,string password)
        {
            Client[] clients = context.Clients.Where(c => c.Password == password && c.Phone == phone).ToArray();
            if (clients.Length > 0)
                return Ok(new { client = clients[0] });
            else
                return Ok(new { client ="Not Exist"});
        }

        [HttpGet("GetBookFirstById")]
        //https://localhost:44342/api/mobile/GetBookFirstById?bookId=8
        public IActionResult getLectureFirstPages(int bookId)
        {

            byte[] buff = null;
            Book lecture = context.Books.Where(p => p.Id == bookId).First();
            //string fileName = Path.Combine(_env.WebRootPath, Helper.lecturesPath + lecture.Id.ToString() + "/image-0001-01.jpg");
            string fileName = Path.Combine(_env.WebRootPath, Helper.lecturesPath + lecture.Id.ToString() + "/" + lecture.Linkurl + "_page-0001" + ".jpg");
            Console.WriteLine(fileName);
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);

            return Ok(new { page = buff });
        }
        //https://localhost:44342/api/mobile/GetBookPage?lectureId=7&pageId=image-0001-06
        //http://tadcenter2022-001-site1.itempurl.com/api/mobile/GetBookPage?lectureId=6&pageId=image-0001-06
        [HttpGet("GetBookPage")]
        //https://localhost:44342/api/mobile/GetBookPage?lectureId=7&pageId=_page-0006
        public IActionResult getLecturePage(int lectureId, string pageId)
        {
            byte[] buff = null;
            Book lecture = context.Books.Where(p => p.Id == lectureId).First();
            //string fileName = Path.Combine(_env.WebRootPath, Helper.lecturesPath + lecture.Id.ToString() + "/" + pageId.ToString() + ".jpg");
            string fileName = Path.Combine(_env.WebRootPath, Helper.lecturesPath + lecture.Id.ToString() + "/" + lecture.Linkurl + pageId.ToString() + ".jpg");
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return Ok(new { page = buff });

        }




        [HttpGet("GetAllPages")]
        //http://tadcenter2022-001-site1.itempurl.com/api/mobile/GetAllPages?lectureId=6
        //https://localhost:44342/api/mobile/GetAllPages?lectureId=7
        public IActionResult getLecturePages(int lectureId)
        {
            byte[] buff = null;
            Book lecture = context.Books.Where(p => p.Id == lectureId).First();
            string dirName = Path.Combine(_env.WebRootPath, Helper.lecturesPath + lecture.Id.ToString());
            String[] files = Directory.GetFiles(dirName);
            List<Helpers.LectureData> pages = new List<LectureData>();
            for (int i = 0; i < files.Length; i++)
            {
                FileStream fs = new FileStream(files[i], FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                long numBytes = new FileInfo(files[i]).Length;
                buff = br.ReadBytes((int)numBytes);
                string finalName = files[i].Split("-")[files[i].Split("-").Length - 1];
                if (!finalName.EndsWith('p'))
                {
                    int pagenum = int.Parse(finalName.Substring(0, finalName.Length - 4));
                    pages.Add(new LectureData(pagenum, finalName, buff));

                }
            }
            return Ok(new { pages = pages });

        }


        [HttpPost("buyBook")]
        //https://localhost:44342/api/mobile/buyBook?bookid=5&clientid=3
        //http://tadcenter2022-001-site3.atempurl.com/api/mobile/buyBook?bookid=5&clientid=3
        public IActionResult buyBook(int bookid,int clientid)
        {
            var book1 = context.Books.Find(bookid);
            var client = context.Clients.Find(clientid);
            var buy = context.Buyings.Where(b=>b.bookID==book1.Id&&b.clientId==client.Id).FirstOrDefault();
            if (buy !=null)
            {
                              return Ok("لقد قمت بشرلء هذا الكتاب مسبقاَ");
            }
            else if (client.balance != 0 && client.balance >= book1.Price )
            {
               
                Buying buying = new Buying();
                buying.bookID = bookid;
                buying.clientId = clientid;
                buying.BuyingDate = DateTime.Now;
               
                client.balance = client.balance - book1.Price;
                context.Update(client);

                 buying = context.Buyings.Add(buying).Entity;
                context.SaveChanges();
                return Ok( "تمت عملية الشراء بنجاح");
            }
            else if (client.balance == 0)
                return BadRequest("you can not buying your balance is empty");
            else return BadRequest("you can not buy");
            
        }



        [HttpPost("BuyCobon")]
        //https://localhost:44342/api/mobile/BuyCobon?cobonId=1&clientId=3
        //http://tadcenter2022-001-site3.atempurl.com/api/mobile/BuyCobon?cobonId=2&clientId=3
        public IActionResult BuyCobon(string CobonNumber, int clientId)
        {
            var client = context.Clients.Find(clientId);
            var cobon = context.Cobons.Where(i=>i.CobonNumber== CobonNumber && i.IsValid==true).FirstOrDefault();


            ClientCobon clientCobon = new ClientCobon();
            clientCobon.ClientId = clientId;
            clientCobon.CobonId = cobon.CobonId;
            clientCobon.CobonDate = System.DateTime.Now;
            client.balance = client.balance + cobon.CobonValue;
            context.Update(client);
            cobon.IsValid = false;
            context.Update(cobon);
            clientCobon = context.ClientCobons.Add(clientCobon).Entity;
            context.SaveChanges();

            return Ok(new { clientCobon = clientCobon,client.balance });

            


        }
        [HttpGet("GetAllValidCobon")]
        //
        public IActionResult GetAllValidCobon()
        {
            var sub = from cobons in context.Cobons
                      where cobons.IsValid == true

                      group new { cobons } by new { cobons.CobonValue, cobons.ReleaseDate }
                       into v

                      select new selectModel
                      {

                          cobonvalue = (decimal)v.Key.CobonValue,
                          ReleaseDate = v.Key.ReleaseDate,


                          coboncount = v.Count(),


                      };
            return Ok(sub.ToList());
        }
        [HttpGet("GetClient")]
        public IActionResult GetClient(int id)
        {
            var client =context.Clients.Find(id);
            if (client != null)
                    {
                return Ok(client);
                    }
        else
                return NotFound();      
        
        }

        [HttpGet("getLecturePagesByCount")]
        public IActionResult getLecturePagesByCount(int lectureId , int start,int count)
        {
            byte[] buff = null;
            Book lecture = context.Books.Where(p => p.Id == lectureId).First();
            string dirName = Path.Combine(_env.WebRootPath, Helper.lecturesPath + lecture.Id.ToString());
            String[] files = Directory.GetFiles(dirName);
            List<Helpers.LectureData> pages = new List<LectureData>();
            for (int i = start; i <= count; i++)
            {
                FileStream fs = new FileStream(files[i], FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                long numBytes = new FileInfo(files[i]).Length;
                buff = br.ReadBytes((int)numBytes);
                string finalName = files[i].Split("-")[files[i].Split("-").Length - 1];
                if (!finalName.EndsWith('p'))
                {
                    int pagenum = int.Parse(finalName.Substring(0, finalName.Length - 4));
                    pages.Add(new LectureData(pagenum, finalName, buff));

                }
            }
            return Ok(new { pages = pages });

        }

        [HttpGet("FreeBooks")]
        public IActionResult FreeBooks()
        {
            var freebook = context.Books.Where(b => b.Price == 0);
            return Ok(freebook.ToList());
        }

        [HttpGet("ClientBook")]
        public IActionResult ClientBook( int clientId)
        {

            var query = (from client in context.Clients
                             join buy in context.Buyings on client.Id equals buy.clientId
                             join book in context.Books on buy.bookID equals book.Id
                         where client.Id==clientId
                         select new
                         {
                             Id = book.Id,
                            
                             Title = book.Title,

                             otherwriter = book.OtherWriter
                         });
            var res = query.ToList();

            return Ok(new { books = res });

        }

        [HttpGet("BookSemeters")]
        public IActionResult BookSemeters(string BookName)
        {

            var semesters = context.BookSemeters.Where(s => s.bookTitle == BookName).ToList();

            return Ok(new { books = semesters });

        }

    }
}



