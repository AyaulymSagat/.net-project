﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentCar.Data;
using RentCar.Models;

namespace RentCar.Controllers
{
    public class HistoriesController : Controller
    {
        private readonly RentContext _context;

        public HistoriesController(RentContext context)
        {
            _context = context;
        }

        // GET: Histories
        public async Task<IActionResult> Index()
        {
            return View(await _context.History.ToListAsync());
        }

        // GET: Histories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.History
                .FirstOrDefaultAsync(m => m.Id == id);
            if (history == null)
            {
                return NotFound();
            }

            return View(history);
        }

        // GET: Histories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Histories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartTime,EndTime,EmployeeId,CarId,Descr")] History history)
        {
            if (ModelState.IsValid)
            {
                _context.Add(history);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(history);
        }

        // GET: Histories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.History.FindAsync(id);
            if (history == null)
            {
                return NotFound();
            }
            return View(history);
        }

        // POST: Histories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartTime,EndTime,EmployeeId,CarId,Descr")] History history)
        {
            if (id != history.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(history);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoryExists(history.Id))
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
            return View(history);
        }

        // GET: Histories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.History
                .FirstOrDefaultAsync(m => m.Id == id);
            if (history == null)
            {
                return NotFound();
            }

            return View(history);
        }

        // POST: Histories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var history = await _context.History.FindAsync(id);
            _context.History.Remove(history);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoryExists(int id)
        {
            return _context.History.Any(e => e.Id == id);
        }
    }
}
