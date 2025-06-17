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
    public class SeriModelsController : Controller
    {
        private readonly ArabamDbContext _context;

        public SeriModelsController(ArabamDbContext context)
        {
            _context = context;
        }

        // GET: SeriModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.SeriModels.ToListAsync());
        }

        // GET: SeriModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seriModel = await _context.SeriModels
                .FirstOrDefaultAsync(m => m.SeriId == id);
            if (seriModel == null)
            {
                return NotFound();
            }

            return View(seriModel);
        }

        // GET: SeriModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SeriModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeriId,SeriAdi,Model,MarkaId")] SeriModel seriModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seriModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seriModel);
        }

        // GET: SeriModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seriModel = await _context.SeriModels.FindAsync(id);
            if (seriModel == null)
            {
                return NotFound();
            }
            return View(seriModel);
        }

        // POST: SeriModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeriId,SeriAdi,Model,MarkaId")] SeriModel seriModel)
        {
            if (id != seriModel.SeriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seriModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeriModelExists(seriModel.SeriId))
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
            return View(seriModel);
        }

        // GET: SeriModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seriModel = await _context.SeriModels
                .FirstOrDefaultAsync(m => m.SeriId == id);
            if (seriModel == null)
            {
                return NotFound();
            }

            return View(seriModel);
        }

        // POST: SeriModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seriModel = await _context.SeriModels.FindAsync(id);
            if (seriModel != null)
            {
                _context.SeriModels.Remove(seriModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeriModelExists(int id)
        {
            return _context.SeriModels.Any(e => e.SeriId == id);
        }
    }
}
