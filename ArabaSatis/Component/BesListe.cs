using ArabaSatis.Data;
using Microsoft.AspNetCore.Mvc;

namespace ArabaSatis.Component
{
    public class BesListe:ViewComponent
    {
        private readonly ArabamDbContext _context;
        public BesListe(ArabamDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var result = _context.Ilanlars.OrderByDescending(x=>x.IlanId).Take(5).ToList();
            return View(result);
        }
    }
}
