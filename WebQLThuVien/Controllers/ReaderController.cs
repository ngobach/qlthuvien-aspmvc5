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
    public class ReaderController : Controller
    {
        ThuVienDb db = new ThuVienDb();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Readers.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var reader = new Reader {Fullname = "Họ tên"};
            db.Readers.Add(reader);
            db.SaveChanges();
            return RedirectToAction("Edit", new { id = reader.Id });
        }

        [HttpPost]
        public ActionResult Edit(Reader reader)
        {
            if (ModelState.IsValid)
            {
                db.Readers.Attach(reader);
                db.Entry(reader).State = EntityState.Modified;
                db.SaveChanges();
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
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }
    }
}