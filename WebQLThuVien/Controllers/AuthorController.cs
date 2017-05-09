using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLThuVien.Filters;
using WebQLThuVien.Models;

namespace WebQLThuVien.Controllers
{
    [AuthFilter]
    public class AuthorController : Controller
    {
        ThuVienDb db = new ThuVienDb();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Authors.Include(x => x.Books).ToList());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = db.Authors.First(x => x.Id == id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Attach(author);
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                Session["message"] = "Cập nhật tác giả thành công";
                return RedirectToAction("Index");
            }
            return View(author);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            db.Authors.Remove(db.Authors.First(x => x.Id == id));
            db.SaveChanges();
            Session["message"] = "Xóa tác giả thành công";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            var item = new Author {Name = "Họ tên", Description = "Giới thiệu"};
            db.Authors.Add(item);
            db.SaveChanges();
            return RedirectToAction("Edit", new {id = item.Id});
        }
    }
}