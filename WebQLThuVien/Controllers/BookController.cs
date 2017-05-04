using System.Linq;
using System.Web.Mvc;
using WebQLThuVien.Filters;
using WebQLThuVien.Models;

namespace WebQLThuVien.Controllers
{
    [AuthFilter]
    public class BookController : Controller
    {
        ThuVienDb db = new ThuVienDb();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }
    }
}