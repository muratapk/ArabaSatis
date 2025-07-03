using ArabaSatis.Data;
using Microsoft.AspNetCore.Mvc;

namespace ArabaSatis.Component
{
    public class SolMenuListe:ViewComponent
    {
        private readonly ArabamDbContext _context;

        public SolMenuListe(ArabamDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var result = _context.Markalars.ToList();
            return View(result);
        }
    }
}
