using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebQLThuVien.Filters;
using WebQLThuVien.Models;

namespace WebQLThuVien.Controllers
{
    [AuthFilter]
    public class DashboardController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new ThuVienDb();
            ViewBag.BookCount = db.Books.Count();
            ViewBag.RentBookCount = db.Tickets.Where(t => t.DateReturned == null).SelectMany(x => x.Books).Distinct().Count();
            ViewBag.OpenTicketCount = db.Tickets.Count(t => t.DateReturned == null);
            var tmpDate = DateTime.Now.Subtract(new TimeSpan(14, 0, 0, 0));
            var rentBookData = new Dictionary<DateTime, int>();
            foreach (var ticket in db.Tickets.Where(t => t.DateCreated >= tmpDate))
            {
                if (!rentBookData.ContainsKey(ticket.DateCreated)) rentBookData[ticket.DateCreated] = 0;
                rentBookData[ticket.DateCreated] += ticket.Books.Count;
            }
            var returnBookData = new Dictionary<DateTime, int>();
            foreach (var ticket in db.Tickets.Where(t => t.DateReturned >= tmpDate))
            {
                if (!returnBookData.ContainsKey(ticket.DateReturned.Value))
                    returnBookData[ticket.DateReturned.Value] = 0;
                returnBookData[ticket.DateReturned.Value] += ticket.Books.Count;
            }
            ViewBag.RentData = rentBookData.Select(x => new KeyValuePair<string, int>(x.Key.ToString("d"), x.Value)).Reverse();
            ViewBag.ReturnData = returnBookData.Select(x => new KeyValuePair<string, int>(x.Key.ToString("d"), x.Value)).Reverse();
            return View();
        }
    }
}