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
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        // GET: Account
        public ActionResult Index()
        {
            return Session["uid"] != null ? RedirectToAction("Index", "User") : RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult Login()
        {
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
                return RedirectToAction("Index", "User");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Tài khoảng hoặc mật khẩu không chính xác");
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