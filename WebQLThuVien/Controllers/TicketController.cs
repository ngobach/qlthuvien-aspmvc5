using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebQLThuVien.Filters;
using WebQLThuVien.Models;

namespace WebQLThuVien.Controllers
{
    [AuthFilter]
    public class TicketController : Controller
    {
        private readonly ThuVienDb db = new ThuVienDb();

        protected override void Initialize(RequestContext requestContext)
        {
            ViewBag.Readers = db.Readers.ToList();
            ViewBag.Books = db.Books.ToList();
            base.Initialize(requestContext);
        }

        [HttpGet]
        public ActionResult Index(int? readerId)
        {
            IQueryable<Ticket> items = db.Tickets;
            if (readerId.HasValue)
            {
                items = items.Where(x => x.ReaderId == readerId.Value);
            }
            return View(items);
        }

        [HttpPost]
        public ActionResult Create(int ReaderId)
        {
            var ticket = new Ticket
            {
                ReaderId = ReaderId,
                DateCreated = DateTime.Today
            };
            db.Tickets.Add(ticket);
            db.SaveChanges();
            return RedirectToAction("Edit", new {id = ticket.Id});
        }

        public ActionResult Delete(int id)
        {
            db.Tickets.Remove(db.Tickets.Single(x => x.Id == id));
            db.SaveChanges();
            Session["message"] = "Xóa thành công!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ticket = db.Tickets.Single(x => x.Id == id);
            var tmp = ticket.Books.Select(x => x.Id);
            ViewBag.Books = db.Books
                .Where(x => !tmp.Contains(x.Id))
                .Where(book => book.Count - book.Tickets.Count(t => t.DateReturned == null) > 0)
                .ToList();
            return View(ticket);
        }

        [HttpPost]
        public ActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Single(x => x.Id == ticket.Id).ReaderId = ticket.ReaderId;
                db.SaveChanges();
                Session["message"] = "Cập nhật phiếu mượn thành công";
                return RedirectToAction("Edit", new {id = ticket.Id});
            }
            return View(ticket);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Book(int id, int BookId, string act)
        {
            var book = db.Books.Single(x => x.Id == BookId);
            var ticket = db.Tickets.Single(x => x.Id == id);
            if (act == "add")
            {
                ticket.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Edit", new {id});
            }
            if (act == "remove")
            {
                ticket.Books.Remove(book);
                db.SaveChanges();
                return RedirectToAction("Edit", new {id});
            }
            return HttpNotFound();
        }

        [HttpGet]
        public ActionResult Return(int id)
        {
            db.Tickets.Single(t => t.Id == id).DateReturned = DateTime.Today;
            db.SaveChanges();
            return RedirectToAction("Detail", new {id});
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var ticket = db.Tickets.Single(x => x.Id == id);
            return View(ticket);
        }

        [HttpGet]
        public ActionResult Print(int id)
        {
            var ticket = db.Tickets.Single(x => x.Id == id);
            return View(ticket);
        }
    }
}