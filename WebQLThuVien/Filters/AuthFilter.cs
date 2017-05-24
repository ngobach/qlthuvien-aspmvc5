using System.Linq;
using System.Web.Mvc;
using WebQLThuVien.Models;

namespace WebQLThuVien.Filters
{
    /// <summary>
    ///     Accept only guest users
    /// </summary>
    public class AuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Auto login first user
            //if (filterContext.HttpContext.IsDebuggingEnabled)
            //    using (var db = new ThuVienDb())
            //    {
            //        filterContext.HttpContext.Session["uid"] = db.Users.First().Id;
            //    }

            if (filterContext.HttpContext.Session["uid"] == null)
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
                return;
            }
            using (var db = new ThuVienDb())
            {
                var uid = (int) filterContext.HttpContext.Session["uid"];
                filterContext.Controller.ViewBag.User = db.Users.First(x => x.Id == uid);
            }
        }
    }
}