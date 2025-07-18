using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arabaapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecureController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSecureData()
        {
            var username = User.Identity.Name;
            return Ok(new { message = "Bu veriye sadece yetkili kullanıcılar erişebilir", username });
        }
    }
}
