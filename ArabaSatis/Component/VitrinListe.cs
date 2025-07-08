using ArabaSatis.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArabaSatis.Component
{
    
    public class VitrinListe: ViewComponent
    {
        private readonly ArabamDbContext _context;

        public VitrinListe(ArabamDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {

            var sorgu = _context.Ilanlars
     .Include(x => x.ArabaResimler) // Bu çok önemli!
     .Include(x => x.Yakit)
     .Include(x => x.Markalar)
     .ToList();
            return View(sorgu);
        }
    }
}
