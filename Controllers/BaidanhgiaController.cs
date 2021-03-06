using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DL.Models;

namespace DL.Controllers
{
    public class BaidanhgiaController : Controller
    {
        private readonly acomptec_dulichTHContext _context;

        public BaidanhgiaController(acomptec_dulichTHContext context)
        {
            _context = context;
        }

        // GET: Baidanhgia
        public async Task<IActionResult> Index()
        {
            var acomptec_dulichTHContext = _context.Baidanhgia.Include(b => b.TkBdgNavigation);
            return View(await acomptec_dulichTHContext.ToListAsync());
        }

        // GET: Baidanhgia/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baidanhgia = await _context.Baidanhgia
                .Include(b => b.TkBdgNavigation)
                .FirstOrDefaultAsync(m => m.BdgMa == id);
            if (baidanhgia == null)
            {
                return NotFound();
            }

            return View(baidanhgia);
        }

        // GET: Baidanhgia/Create
        public IActionResult Create()
        {
            ViewData["TkBdg"] = new SelectList(_context.Taikhoan, "TkMa", "TkMa");
            return View();
        }

        // POST: Baidanhgia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BdgMa,BdgNoidung,TkBdg")] Baidanhgia baidanhgia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baidanhgia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TkBdg"] = new SelectList(_context.Taikhoan, "TkMa", "TkMa", baidanhgia.TkBdg);
            return View(baidanhgia);
        }

        // GET: Baidanhgia/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baidanhgia = await _context.Baidanhgia.FindAsync(id);
            if (baidanhgia == null)
            {
                return NotFound();
            }
            ViewData["TkBdg"] = new SelectList(_context.Taikhoan, "TkMa", "TkMa", baidanhgia.TkBdg);
            return View(baidanhgia);
        }

        // POST: Baidanhgia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BdgMa,BdgNoidung,TkBdg")] Baidanhgia baidanhgia)
        {
            if (id != baidanhgia.BdgMa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baidanhgia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaidanhgiaExists(baidanhgia.BdgMa))
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
            ViewData["TkBdg"] = new SelectList(_context.Taikhoan, "TkMa", "TkMa", baidanhgia.TkBdg);
            return View(baidanhgia);
        }

        // GET: Baidanhgia/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baidanhgia = await _context.Baidanhgia
                .Include(b => b.TkBdgNavigation)
                .FirstOrDefaultAsync(m => m.BdgMa == id);
            if (baidanhgia == null)
            {
                return NotFound();
            }

            return View(baidanhgia);
        }

        // POST: Baidanhgia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var baidanhgia = await _context.Baidanhgia.FindAsync(id);
            _context.Baidanhgia.Remove(baidanhgia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaidanhgiaExists(string id)
        {
            return _context.Baidanhgia.Any(e => e.BdgMa == id);
        }
    }
}
