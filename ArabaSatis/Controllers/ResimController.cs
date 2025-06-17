using ArabaSatis.Data;
using ArabaSatis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArabaSatis.Controllers
{
    public class ResimController : Controller
    {
        private readonly ArabamDbContext _context;

        public ResimController(ArabamDbContext context)
        {
            _context = context;
        }

        // GET: ResimController
        public async Task<ActionResult> Index()
        {
            //var veri = _context.ArabaResim.ToList();
            //select * from ArabaResim
            var veri = await _context.ArabaResim.ToListAsync();

            return View(veri);
        }

        // GET: ResimController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ResimController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResimController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArabaResim gelen)
        {
            try
            {
                _context.ArabaResim.Add(gelen);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ResimController/Edit/5
        public ActionResult Edit(int id)
        {
            var bul = _context.ArabaResim.Find(id);
            return View(bul);
        }

        // POST: ResimController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArabaResim gelen)
        {
            try
            {
                _context.ArabaResim.Update(gelen);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ResimController/Delete/5
        public ActionResult Delete(int id)
        {
            var bul=_context.ArabaResim.Where(x=>x.ArabaResimId== id).FirstOrDefault();
            return View(bul);
        }

        // POST: ResimController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ArabaResim gelen)
        {
            try
            {
                _context.ArabaResim.Remove(gelen);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
