using ArabaSatis.Data;
using ArabaSatis.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArabaSatis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ArabamDbContext _context;
        public HomeController(ArabamDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ilanDetay(int ? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Burada id'ye g�re ilan detaylar�n� veritaban�ndan �ekip model olu�turabilirsiniz.
            // �rnek olarak basit bir model d�nd�r�yoruz.
            var result=_context.Ilanlars.FirstOrDefault(i => i.IlanId == id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
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
