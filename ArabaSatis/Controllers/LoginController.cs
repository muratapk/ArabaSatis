using Microsoft.AspNetCore.Mvc;

namespace ArabaSatis.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
