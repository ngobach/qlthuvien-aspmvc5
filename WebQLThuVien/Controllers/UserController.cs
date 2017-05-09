using System;
using System.Linq;
using System.Web.Mvc;
using WebQLThuVien.Filters;
using WebQLThuVien.Models;
using WebQLThuVien.ViewModels;

namespace WebQLThuVien.Controllers
{
    [AuthFilter]
    public class UserController : Controller
    {
        private readonly ThuVienDb db = new ThuVienDb();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Edit", new {id = ViewBag.User.Id});
            try
            {
                var user = db.Users.First(x => x.Id == id.Value);
                return View(new EditUserViewModel
                {
                    Email = user.Email,
                    Id = user.Id,
                    Fullname = user.Fullname
                });
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if ((model.Password != null || model.RePassword != null) && model.Password != model.RePassword)
            {
                ModelState.AddModelError("", "Nhập lại mật khẩu không chính xác");
            }
            if (ModelState.IsValid)
            {
                var user = db.Users.First(x => x.Id == model.Id);
                user.Email = model.Email;
                user.Fullname = model.Fullname;
                if (model.Password != null)
                    user.Password = model.Password;
                db.SaveChanges();
                Session["message"] = "Cập nhật người dùng thành công";
                return View(model);
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateUserViewModel());
        }

        [HttpPost]
        public ActionResult Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { Email = model.Email, Fullname = model.Fullname, Username = model.Username, Password = model.Password};
                db.Users.Add(user);
                db.SaveChanges();
                Session["message"] = "Tạo mới người dùng thành công";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == ViewBag.User.Id)
            {
                Session["message"] = "Bạn không thể xóa chính bạn";
                Session["type"] = "danger";
                return RedirectToAction("Index");
            }
            db.Users.RemoveRange(db.Users.Where(user => user.Id == id));
            db.SaveChanges();
            Session["message"] = "Xóa người dùng thành công";
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}