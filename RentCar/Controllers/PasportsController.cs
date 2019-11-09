using System;
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
    public class PasportsController : Controller
    {
        private readonly RentContext _context;

        public PasportsController(RentContext context)
        {
            _context = context;
        }

        // GET: Pasports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pasport.ToListAsync());
        }

        // GET: Pasports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasport = await _context.Pasport
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pasport == null)
            {
                return NotFound();
            }

            return View(pasport);
        }

        // GET: Pasports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pasports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegistationDate,Skill")] Pasport pasport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pasport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pasport);
        }

        // GET: Pasports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasport = await _context.Pasport.FindAsync(id);
            if (pasport == null)
            {
                return NotFound();
            }
            return View(pasport);
        }

        // POST: Pasports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegistationDate,Skill")] Pasport pasport)
        {
            if (id != pasport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pasport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasportExists(pasport.Id))
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
            return View(pasport);
        }

        // GET: Pasports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasport = await _context.Pasport
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pasport == null)
            {
                return NotFound();
            }

            return View(pasport);
        }

        // POST: Pasports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pasport = await _context.Pasport.FindAsync(id);
            _context.Pasport.Remove(pasport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasportExists(int id)
        {
            return _context.Pasport.Any(e => e.Id == id);
        }
    }
}
