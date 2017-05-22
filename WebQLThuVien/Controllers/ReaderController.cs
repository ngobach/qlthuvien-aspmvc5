using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebQLThuVien.Filters;
using WebQLThuVien.Models;

namespace WebQLThuVien.Controllers
{
    [AuthFilter]
    public class ReaderController : Controller
    {
        private readonly ThuVienDb db = new ThuVienDb();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Readers.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Reader reader)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(reader.Password))
                {
                    ModelState.AddModelError("", "Không được bỏ trống mật khẩu");
                }
                db.Readers.Add(reader);
                db.SaveChanges();
                Session["message"] = "Tạo mới độc giả thành công";
                return RedirectToAction("Index");
            }
            return View(reader);
        }

        [HttpPost]
        public ActionResult Edit(Reader reader)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(reader.Password))
                {
                    reader.Password = db.Readers.Single(x => x.Id == reader.Id).Password;
                }
                db.Readers.Attach(reader);
                db.Entry(reader).State = EntityState.Modified;
                db.SaveChanges();
                Session["message"] = "Cập nhật độc giả thành công";
                return RedirectToAction("Index");
            }
            return View(reader);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var reader = db.Readers.First(x => x.Id == id);
                return View(reader);
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
                var reader = db.Readers.First(x => x.Id == id);
                db.Readers.Remove(reader);
                db.SaveChanges();
                Session["message"] = "Xóa độc giả thành công";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }
    }
}