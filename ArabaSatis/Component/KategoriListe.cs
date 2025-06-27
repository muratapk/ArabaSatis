using ArabaSatis.Data;
using Microsoft.AspNetCore.Mvc;

namespace ArabaSatis.Component
{
    public class KategoriListe:ViewComponent
    {
        private readonly ArabamDbContext _context;
        public KategoriListe(ArabamDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            
            return View();  
        }

    }
}
