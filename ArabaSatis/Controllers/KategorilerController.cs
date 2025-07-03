using ArabaSatis.Data;
using Microsoft.AspNetCore.Mvc;

namespace ArabaSatis.Controllers
{
    public class KategorilerController : Controller
    {
        private readonly ArabamDbContext _context;

        public KategorilerController(ArabamDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult KategoriListesi(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kategori = _context.Markalars.Where(x => x.MarkaId == id).ToList();


            return View(kategori);
        }
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
