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
    public class YakitsController : Controller
    {
        private readonly ArabamDbContext _context;

        public YakitsController(ArabamDbContext context)
        {
            _context = context;
        }

        // GET: Yakits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yakits.ToListAsync());
        }

        // GET: Yakits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yakit = await _context.Yakits
                .FirstOrDefaultAsync(m => m.YakitId == id);
            if (yakit == null)
            {
                return NotFound();
            }

            return View(yakit);
        }

        // GET: Yakits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yakits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YakitId,YakitAdi")] Yakit yakit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yakit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yakit);
        }

        // GET: Yakits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yakit = await _context.Yakits.FindAsync(id);
            if (yakit == null)
            {
                return NotFound();
            }
            return View(yakit);
        }

        // POST: Yakits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YakitId,YakitAdi")] Yakit yakit)
        {
            if (id != yakit.YakitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yakit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YakitExists(yakit.YakitId))
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
            return View(yakit);
        }

        // GET: Yakits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yakit = await _context.Yakits
                .FirstOrDefaultAsync(m => m.YakitId == id);
            if (yakit == null)
            {
                return NotFound();
            }

            return View(yakit);
        }

        // POST: Yakits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yakit = await _context.Yakits.FindAsync(id);
            if (yakit != null)
            {
                _context.Yakits.Remove(yakit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YakitExists(int id)
        {
            return _context.Yakits.Any(e => e.YakitId == id);
        }
    }
}
