using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArabaSatis.Data;
using ArabaSatis.Models;

namespace ArabaSatis.Controllers
{
    public class IlanlarsController : Controller
    {
        private readonly ArabamDbContext _context;

        public IlanlarsController(ArabamDbContext context)
        {
            _context = context;
        }

        // GET: Ilanlars
        public async Task<IActionResult> Index()
        {
            var arabamDbContext = _context.Ilanlars.Include(i => i.Yakit);
            return View(await arabamDbContext.ToListAsync());
        }

        // GET: Ilanlars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilanlar = await _context.Ilanlars
                .Include(i => i.Yakit)
                .FirstOrDefaultAsync(m => m.IlanId == id);
            if (ilanlar == null)
            {
                return NotFound();
            }

            return View(ilanlar);
        }

        // GET: Ilanlars/Create
        public IActionResult Create()
        {

            // ViewData["YakitId"] = new SelectList(_context.Yakits, "YakitId", "YakitId");
            ViewBag.Yakitliste = new SelectList(_context.Yakits, "YakitId", "YakitAdi");
            ViewBag.Markaliste = new SelectList(_context.Markalars, "MarkaId", "MarkaAd");
            return View();
        }

        // POST: Ilanlars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IlanId,IlanAdi,Yil,AracDurumu,Kilometre,YakitId,MarkaId")] Ilanlar ilanlar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ilanlar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Yakitliste = new SelectList(_context.Yakits, "YakitId", "YakitAdi");
            ViewBag.Markaliste = new SelectList(_context.Markalars, "MarkaId", "MarkaAd");
            return View(ilanlar);
        }

        // GET: Ilanlars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilanlar = await _context.Ilanlars.FindAsync(id);
            if (ilanlar == null)
            {
                return NotFound();
            }
            ViewBag.Yakitliste = new SelectList(_context.Yakits, "YakitId", "YakitAdi");
            ViewBag.Markaliste = new SelectList(_context.Markalars, "MarkaId", "MarkaAd");
            return View(ilanlar);
        }

        // POST: Ilanlars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IlanId,IlanAdi,Yil,AracDurumu,Kilometre,YakitId,MarkaId")] Ilanlar ilanlar)
        {
            if (id != ilanlar.IlanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ilanlar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IlanlarExists(ilanlar.IlanId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Yakitliste = new SelectList(_context.Yakits, "YakitId", "YakitAdi");
            ViewBag.Markaliste = new SelectList(_context.Markalars, "MarkaId", "MarkaAd");
            return View(ilanlar);
        }

        // GET: Ilanlars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ilanlar = await _context.Ilanlars
                .Include(i => i.Yakit)
                .FirstOrDefaultAsync(m => m.IlanId == id);
            if (ilanlar == null)
            {
                return NotFound();
            }
            ViewBag.Yakitliste = new SelectList(_context.Yakits, "YakitId", "YakitAdi");
            ViewBag.Markaliste = new SelectList(_context.Markalars, "MarkaId", "MarkaAd");
            return View(ilanlar);
        }

        // POST: Ilanlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ilanlar = await _context.Ilanlars.FindAsync(id);
            if (ilanlar != null)
            {
                _context.Ilanlars.Remove(ilanlar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IlanlarExists(int id)
        {
            return _context.Ilanlars.Any(e => e.IlanId == id);
        }
    }
}
