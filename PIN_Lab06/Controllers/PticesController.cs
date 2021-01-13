using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PIN_Lab06.Data;
using PIN_Lab06.Models;

namespace PIN_Lab06.Controllers
{
    public class PticesController : Controller
    {
        private readonly PticeContext _context;

        public PticesController(PticeContext context)
        {
            _context = context;
        }

        // GET: Ptice
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ptice.ToListAsync());
        }

        // GET: Ptices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ptice = await _context.Ptice
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ptice == null)
            {
                return NotFound();
            }

            return View(ptice);
        }

        // GET: Ptice/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ptice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Naziv,Vrsta,DatSnimanja")] Ptice ptice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ptice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ptice);
        }

        // GET: Ptices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ptice = await _context.Ptice.FindAsync(id);
            if (ptice == null)
            {
                return NotFound();
            }
            return View(ptice);
        }

        // POST: Ptices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Naziv,Vrsta,DatSnimanja")] Ptice ptice)
        {
            if (id != ptice.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ptice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PticeExists(ptice.ID))
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
            return View(ptice);
        }

        // GET: Ptices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ptice = await _context.Ptice
                .FirstOrDefaultAsync(m => m.ID == id);
            if (ptice == null)
            {
                return NotFound();
            }

            return View(ptice);
        }

        // POST: Ptices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ptice = await _context.Ptice.FindAsync(id);
            _context.Ptice.Remove(ptice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PticeExists(int id)
        {
            return _context.Ptice.Any(e => e.ID == id);
        }
    }
}
