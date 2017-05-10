using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using WebQLThuVien.Filters;
using WebQLThuVien.Models;
using WebQLThuVien.ViewModels;

namespace WebQLThuVien.Controllers
{
    [AuthFilter]
    public class BookController : Controller
    {
        private readonly ThuVienDb db = new ThuVienDb();

        protected override void Initialize(RequestContext requestContext)
        {
            ViewBag.Authors = db.Authors.ToList();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Publishers = db.Publishers.ToList();
            base.Initialize(requestContext);
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new BookViewModel());
        }

        [HttpPost]
        public ActionResult Create(BookViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var book = new Book
                {
                    Name = vm.Name,
                    Description = vm.Description,
                    AuthorId = vm.AuthorId,
                    CategoryId = vm.CategoryId,
                    PublisherId = vm.PublisherId,
                    Count = vm.Count,
                    NumberOfPage = vm.NumberOfPage,
                    Price = vm.Price,
                    PublishYear = vm.PublishYear,
                    ThumbnailUrl = vm.ThumbnailUrl
                };
                db.Books.Add(book);
                db.SaveChanges();
                Session["message"] = "Tạo mới sách thành công";
                return RedirectToAction("Detail", new {id = book.Id});
            }
            return View(vm);
        }


        [HttpPost]
        public ActionResult Edit(int id, BookViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var book = new Book
                {
                    Id = id,
                    Name = vm.Name,
                    Description = vm.Description,
                    AuthorId = vm.AuthorId,
                    CategoryId = vm.CategoryId,
                    PublisherId = vm.PublisherId,
                    Count = vm.Count,
                    NumberOfPage = vm.NumberOfPage,
                    Price = vm.Price,
                    PublishYear = vm.PublishYear,
                    ThumbnailUrl = vm.ThumbnailUrl
                };
                db.Books.Attach(book);
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                Session["message"] = "Cập nhật sách thành công";
                return RedirectToAction("Detail", new { id = book.Id });
            }
            return View(vm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var book = db.Books.First(x => x.Id == id);
                return View(new BookViewModel
                {
                    Name = book.Name,
                    AuthorId = book.Author.Id,
                    CategoryId = book.Category.Id,
                    PublisherId = book.Publisher.Id,
                    Count = book.Count,
                    PublishYear = book.PublishYear,
                    NumberOfPage = book.NumberOfPage,
                    Description = book.Description,
                    Price = book.Price,
                    ThumbnailUrl = book.ThumbnailUrl
                });
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var book = db.Books.First(x => x.Id == id);
                db.Books.Remove(book);
                db.SaveChanges();
                Session["message"] = "Xóa sách thành công";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var book = db.Books.SingleOrDefault(x => x.Id == id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }
    }
}