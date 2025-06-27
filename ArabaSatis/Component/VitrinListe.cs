using ArabaSatis.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArabaSatis.Component
{
    
    public class VitrinListe:ViewComponent
    {
        private readonly ArabamDbContext _context;

        public VitrinListe(ArabamDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var sorgu = _context.Ilanlars.ToList();
            return View(sorgu);
        }
    }
}
