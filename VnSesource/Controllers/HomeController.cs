using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VnSesource.Models;

namespace VnSesource.Controllers
{
    public class HomeController : Controller
    {
        private readonly VnResourse_DBContext _db;

        public HomeController(VnResourse_DBContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            if (_db.KhoaHoc == null)
            {
                return NotFound();
            }

            ViewBag.KhoaHoc = await _db.KhoaHoc.ToListAsync();

            return View();
        }

        public async Task<IActionResult> Subject(int ID)
        {
            if (ID == null)
            {
                return BadRequest();
            }

            var sb = _db.MonHoc.Where(mh => mh.KhoaHocID == ID);
            var cr = _db.KhoaHoc.Where(kh => kh.ID == ID);

            if (sb == null)
            {
                return BadRequest();
            }

            ViewBag.KhoaHoc = cr;
            ViewBag.MonHoc = sb;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
