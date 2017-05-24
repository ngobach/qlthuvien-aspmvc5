using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI.WebControls;
using WebQLThuVien.Filters;
using WebQLThuVien.Models;

namespace WebQLThuVien.Controllers
{
    public class HomeController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["readerId"] != null)
            {
                var db = new ThuVienDb();
                var id = (int) Session["readerId"];
                ViewBag.Username = db.Readers.Single(x => x.Id == id).Username;
            }
        }

        [HttpGet]
        public ActionResult Index(int page = 1, string book = null)
        {
            var db = new ThuVienDb();
            IQueryable<Book> src = db.Books;
            if (book != null) src = src.Where(b => b.Name.Contains(book));
            ViewBag.PageCount = (src.Count()+19) / 20;
            ViewBag.CurrentPage = page;
            ViewBag.Books = src.SortBy("Id").Skip((page-1)*20).Take(20);
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            var db = new ThuVienDb();
            var reader = db.Readers.SingleOrDefault(x => x.Username == Username && x.Password == Password);
            if (reader == null)
            {
                ModelState.AddModelError("", "Lỗi đăng nhập!");
                return View();
            }
            else
            {
                Session["readerId"] = reader.Id;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult AddBook(int id)
        {
            var userList = (List<int>) Session["userList"] ?? (List<int>) (Session["userList"] = new List<int>());
            if (!userList.Contains(id))
            {
                userList.Add(id);
            }
            return Json(new
            {
                Code = 0,
                Message = "Thêm sách vào thành công"
            });
        }

        [HttpPost]
        public ActionResult RemoveBook(int id)
        {
            var userList = (List<int>)Session["userList"] ?? (List<int>)(Session["userList"] = new List<int>());
            if (userList.Contains(id))
            {
                userList.Remove(id);
            }
            return Json(new
            {
                Code = 0,
                Message = "Xóa sách thành công"
            });
        }

        [HttpGet]
        public ActionResult HasBook(int id)
        {
            var userList = (List<int>)Session["userList"] ?? (List<int>)(Session["userList"] = new List<int>());
            return Json(userList.Contains(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("readerId");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Book(int id)
        {
            var db = new ThuVienDb();
            ViewBag.Book = db.Books.Single(x => x.Id == id);
            return View();
        }

        [HttpGet]
        public ActionResult Cart()
        {
            var db = new ThuVienDb();
            var userList = (List<int>)Session["userList"] ?? (List<int>)(Session["userList"] = new List<int>());
            ViewBag.Books = db.Books.Where(x => userList.Contains(x.Id)).ToList();
            return View();
        }

        [HttpPost]
        [ActionName("Cart")]
        public ActionResult CartPost()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult CreateTicket()
        {
            if (Session["readerId"] == null)
            {
                return RedirectToAction("Login");
            }
            var db = new ThuVienDb();
            var userList = (List<int>)Session["userList"] ?? (List<int>)(Session["userList"] = new List<int>());
            var ticket = new Ticket
            {
                DateCreated = DateTime.Now,
                ReaderId = (int)Session["readerId"]
            };
            foreach (var bookId in userList)
            {
                ticket.Books.Add(db.Books.Single(x => x.Id == bookId));
            }
            db.Tickets.Add(ticket);
            db.SaveChanges();
            Session.Remove("userList");
            ViewBag.Ticket = ticket;
            return View();
        }
    }
}