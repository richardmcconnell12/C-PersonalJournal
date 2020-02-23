﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalJournal.Data;
using PersonalJournal.Models;

namespace PersonalJournal.Controllers
{
    public class MoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Moods
        public async Task<IActionResult> Index()
        {
            return View(await _context.Feeling.ToListAsync());
        }

        // GET: Moods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mood = await _context.Feeling
                .FirstOrDefaultAsync(m => m.MoodId == id);
            if (mood == null)
            {
                return NotFound();
            }

            return View(mood);
        }

        // GET: Moods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MoodId,Feeling")] Mood mood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mood);
        }

        // GET: Moods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mood = await _context.Feeling.FindAsync(id);
            if (mood == null)
            {
                return NotFound();
            }
            return View(mood);
        }

        // POST: Moods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MoodId,Feeling")] Mood mood)
        {
            if (id != mood.MoodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoodExists(mood.MoodId))
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
            return View(mood);
        }

        // GET: Moods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mood = await _context.Feeling
                .FirstOrDefaultAsync(m => m.MoodId == id);
            if (mood == null)
            {
                return NotFound();
            }

            return View(mood);
        }

        // POST: Moods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mood = await _context.Feeling.FindAsync(id);
            _context.Feeling.Remove(mood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoodExists(int id)
        {
            return _context.Feeling.Any(e => e.MoodId == id);
        }
    }
}
