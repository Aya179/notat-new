using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NotataSub.Models;


namespace NotataSub.Controllers
{
    public class ReportsController : Controller
    {
        private readonly StudyHubContext _context;

        public ReportsController(StudyHubContext context)
        {
            _context = context;
         }

        public IActionResult DailyReport()
        {
            var query = from buy in _context.Buyings
                        join book in _context.Books on buy.bookID equals book.Id
                        join auther in _context.Writers on book.WriterName equals auther.Name
                        join client in _context.Clients on buy.clientId equals client.Id
                        where buy.BuyingDate == System.DateTime.Now.Date
                        select new selectModel
                        {
                            Booktitle = book.Title,
                            //clientName = client.FirstName + " " + client.LastName,
                            auther = auther.Name,
                            BuyingDate = buy.BuyingDate,
                            BookPrice = (decimal)book.Price

                        };
            return View(query.ToList());
        }


        public IActionResult AutherReport(int id)
        {

            var query = from buy in _context.Buyings
                        join book in _context.Books on buy.bookID equals book.Id
                        join auther in _context.Writers on book.WriterName equals auther.Name
                        // join client in _context.Clients on buy.clientId equals client.Id
                        where auther.Id == id
                        group new { book } by new { buy.bookID }
                        into v
                        select new
                        {
                            BookId = v.Key.bookID,

                            totalPrice = v.Sum(x => x.book.Price)


                        };
            var qList = query.ToList();
            var result = from book in _context.Books
                         join vs in query on book.Id equals vs.BookId
                         join auther2 in _context.Writers on book.WriterName equals auther2.Name



                         select new selectModel
                         {
                             Booktitle = book.Title,
                             auther = auther2.Name,
                             Total = (float)vs.totalPrice

                         };
            return Json(result.ToList());
        }

        public IActionResult AutherReportView()
        {
            ViewData["WritreId"] = new SelectList(_context.Writers, "Name", "Name");
            return View();

        }


        public IActionResult ReportByDateView()
        {
            return View();
        }
        public IActionResult ReportByDate(DateTime startDate, DateTime EndDate)
        {

            var query = from buy in _context.Buyings
                        join book in _context.Books on buy.bookID equals book.Id
                        join auther in _context.Writers on book.WriterName equals auther.Name
                        //join client in _context.Clients on buy.clientId equals client.Id
                        where buy.BuyingDate >= startDate && buy.BuyingDate <= EndDate
                        group new { book, buy } by new { buy.bookID, buy.clientId }
                    into v
                        select new
                        {
                            BookId = v.Key.bookID,

                            totalPrice = v.Sum(x => x.book.Price),
                            clientid = v.Key.clientId,




                        };
            var qList = query.ToList();
            var result = from book in _context.Books
                         join vs in query on book.Id equals vs.BookId
                         join auther2 in _context.Writers on book.WriterName equals auther2.Name

                         join client2 in _context.Clients on vs.clientid equals client2.Id


                         select new
                         {
                             Booktitle = book.Title,
                             auther = auther2.Name,
                             //clientName = client2.FirstName + " " + client2.LastName,
                             Total = (float)vs.totalPrice

                         };
            return Json(result.ToList());

        }




        public IActionResult CobonReportView()
        {
            return View();
        }
        public IActionResult CobonReport(DateTime startDate, DateTime EndDate)
        {

            var query = from Clientcobon in _context.ClientCobons
                        
                        join client in _context.Clients on Clientcobon.ClientId equals client.Id
                        join cobon in _context.Cobons on Clientcobon.CobonId equals cobon.CobonId
                        where Clientcobon.CobonDate>= startDate && Clientcobon.CobonDate <= EndDate
                        group new {client,cobon } by new { Clientcobon.ClientId,Clientcobon.CobonId }
                    into v
                        select new
                        {
                            clientId = v.Key.ClientId,

                           
                            cobonId = v.Key.CobonId




                        };
            var qList = query.ToList();
            var result = from cobon in _context.Cobons
                         join vs in query on cobon.CobonId equals vs.cobonId
                         
                         join client2 in _context.Clients on vs.clientId equals client2.Id


                         select new
                         {
                             cobonValue=cobon.CobonValue,
                             clientName=client2.Phone,
                             cobonDate=cobon.ReleaseDate
                         };
            return Json(result.ToList());

        }

       
        public IActionResult MonthlyReport()
        {

            var query = from buy in _context.Buyings
                       join book in _context.Books on buy.bookID equals book.Id
                       join auther in _context.Writers on book.WriterName equals auther.Name
                       join client in _context.Clients on buy.clientId equals client.Id
                       where buy.BuyingDate.Month == System.DateTime.Now.Month && buy.BuyingDate.Year == System.DateTime.Now.Year
                        select new selectModel
                       {
                           Booktitle = book.Title,
                           //clientName = client.FirstName + " " + client.LastName,
                           auther = auther.Name,
                           BuyingDate=buy.BuyingDate,
                           BookPrice= (decimal)book.Price

                       };
            return View(query.ToList());
        }

        public IActionResult YearReport()
        {

            var query = from buy in _context.Buyings
                        join book in _context.Books on buy.bookID equals book.Id
                        join auther in _context.Writers on book.WriterName equals auther.Name
                        join client in _context.Clients on buy.clientId equals client.Id
                        where  buy.BuyingDate.Year == System.DateTime.Now.Year
                        select new selectModel
                        {
                            Booktitle = book.Title,
                            //clientName = client.FirstName + " " + client.LastName,
                            auther = auther.Name,
                            BuyingDate = buy.BuyingDate,
                            BookPrice = (decimal)book.Price

                        };




          
            return View(query.ToList());
        }
    }
}

