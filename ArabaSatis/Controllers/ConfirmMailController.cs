using Microsoft.AspNetCore.Mvc;

namespace ArabaSatis.Controllers
{
    public class ConfirmMailController : Controller
    {
        public IActionResult Index()
        {
            var veri = TempData["Mail"];
            ViewBag.Email = veri;
            return View();
        }
    }
}
