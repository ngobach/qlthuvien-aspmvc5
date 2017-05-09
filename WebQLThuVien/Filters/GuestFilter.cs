using System.Web.Mvc;

namespace WebQLThuVien.Filters
{
    /// <summary>
    ///     Accept only guest users
    /// </summary>
    public class GuestFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["uid"] == null) return;
            filterContext.Result = new RedirectResult("~/");
        }
    }
}