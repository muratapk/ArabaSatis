﻿using System;
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
    public class MarkalarsController : Controller
    {
        private readonly ArabamDbContext _context;

        public MarkalarsController(ArabamDbContext context)
        {
            _context = context;
        }

        // GET: Markalars
        public async Task<IActionResult> Index()
        {
            return View(await _context.Markalars.ToListAsync());
        }

        // GET: Markalars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markalar = await _context.Markalars
                .FirstOrDefaultAsync(m => m.MarkaId == id);
            if (markalar == null)
            {
                return NotFound();
            }

            return View(markalar);
        }

        // GET: Markalars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Markalars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MarkaId,MarkaAd")] Markalar markalar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(markalar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(markalar);
        }

        // GET: Markalars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markalar = await _context.Markalars.FindAsync(id);
            if (markalar == null)
            {
                return NotFound();
            }
            return View(markalar);
        }

        // POST: Markalars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarkaId,MarkaAd")] Markalar markalar)
        {
            if (id != markalar.MarkaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(markalar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkalarExists(markalar.MarkaId))
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
            return View(markalar);
        }

        // GET: Markalars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markalar = await _context.Markalars
                .FirstOrDefaultAsync(m => m.MarkaId == id);
            if (markalar == null)
            {
                return NotFound();
            }

            return View(markalar);
        }

        // POST: Markalars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var markalar = await _context.Markalars.FindAsync(id);
            if (markalar != null)
            {
                _context.Markalars.Remove(markalar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkalarExists(int id)
        {
            return _context.Markalars.Any(e => e.MarkaId == id);
        }
    }
}
