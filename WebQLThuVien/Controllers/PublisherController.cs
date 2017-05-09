using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebQLThuVien.Filters;
using WebQLThuVien.Models;

namespace WebQLThuVien.Controllers
{
    [AuthFilter]
    public class PublisherController : Controller
    {
        private readonly ThuVienDb db = new ThuVienDb();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Publishers.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var pub = new Publisher {Name = "Tên nhà xuất bản", Description = "Giới thiệu"};
            db.Publishers.Add(pub);
            db.SaveChanges();
            return RedirectToAction("Edit", new {id = pub.Id});
        }

        [HttpPost]
        public ActionResult Edit(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Publishers.Attach(publisher);
                db.Entry(publisher).State = EntityState.Modified;
                db.SaveChanges();
                Session["message"] = "Cập nhật nhà xuất bản thành công";
                return RedirectToAction("Index");
            }

            return View(publisher);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var publisher = db.Publishers.First(pub => pub.Id == id);
                return View(publisher);
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
                var publisher = db.Publishers.First(pub => pub.Id == id);
                db.Publishers.Remove(publisher);
                db.SaveChanges();
                Session["message"] = "Xóa nhà xuất bản thành công";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }
    }
}