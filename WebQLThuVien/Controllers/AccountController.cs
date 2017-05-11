using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebQLThuVien.Models;

namespace WebQLThuVien.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Session["uid"] != null ? RedirectToAction("Index", "Dashboard") : RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Sample = new ThuVienDb().Users.First();
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var db = new ThuVienDb();
            try
            {
                user = db.Users.First(x => x.Username == user.Username && x.Password == user.Password);
                Session["uid"] = user.Id;
                return RedirectToAction("Index", "Dashboard");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("uid");
            return RedirectToAction("Login");
        }
    }
}