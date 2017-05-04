using System.Web.Mvc;
using WebQLThuVien.Filters;

namespace WebQLThuVien.Controllers
{
    [AuthFilter]
    public class DashboardController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}