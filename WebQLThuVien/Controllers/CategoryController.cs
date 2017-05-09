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
    public class CategoryController : Controller
    {
        ThuVienDb db = new ThuVienDb();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            var category = new Category { Name = "Tên thể loại" };
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Edit", new { id = category.Id });
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Attach(category);
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                Session["message"] = "Cập nhật danh mục thành công";
                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var category = db.Categories.First(x => x.Id == id);
                return View(category);
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
                var category = db.Categories.First(x => x.Id == id);
                db.Categories.Remove(category);
                db.SaveChanges();
                Session["message"] = "Xóa danh mục thành công";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }
    }
}