using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotataSub.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NotataSub.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class mobileController : ControllerBase
    {
        private StudyHubContext context;
        public mobileController(StudyHubContext context)
        {
            this.context = context;
        }


        [HttpPost("addClient")]
        public IActionResult addClient(string firstName, string lastName, string Number,string email,string phone, byte[] Image)
        {
            Client fac = new Client();
            fac.FirstName = firstName;
            fac.LastName = lastName;
            
            fac.Email = email;
            fac.Phone = phone;
            fac.Image = Image;
            
            fac = context.Clients.Add(fac).Entity;
            context.SaveChanges();
            return Ok(new { Client = fac });
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
            Book[] books = context.Books.Where(sub => sub.CatId == id).ToArray();

            return Ok(new { books = books });
        }

        [HttpGet("GetBookById")]
        //https://localhost:44342/api/mobile/GetBookById?id=1
        public async Task<ActionResult<Book>> GetBookByIdAsync(int id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var book = await context.Books.FindAsync(id);
            return book;
        }
        [HttpGet("GetLastBooks")]
        //https://localhost:44342/api/mobile/GetLastBooks
        public IActionResult GetLastBooks()
        {
            Book[] books = context.Books.Where(b => b.Year.Value.Year == DateTime.Now.Year).ToArray();

            return Ok(new { books = books });
        }





    }
}
