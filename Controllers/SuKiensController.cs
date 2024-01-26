using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLB_HTSV.Data;
using CLB_HTSV.Models;

namespace CLB_HTSV.Controllers
{
    public class SuKiensController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuKiensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuKiens
        public async Task<IActionResult> Index()
        {
            var suKiens = await _context.SuKien.Include(s => s.ThanhVien).ToListAsync();
            return View(suKiens);
        }

        // GET: SuKiens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suKien = await _context.SuKien
                .Include(s => s.ThanhVien)
                .FirstOrDefaultAsync(m => m.MaSuKien == id);
            if (suKien == null)
            {
                return NotFound();
            }

            return View(suKien);
        }

        // GET: SuKiens/Create
        public IActionResult Create()
        {
            ViewData["ToChucBoi"] = new SelectList(_context.ThanhVien, "MaThanhVien", "HoTen");
            return View();
        }

        // POST: SuKiens/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSuKien,TieuDe,MoTa,ThoiGian,DiaDiem,ToChucBoi")] SuKien suKien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suKien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ToChucBoi"] = new SelectList(_context.ThanhVien, "MaThanhVien", "HoTen", suKien.ToChucBoi);
            return View(suKien);
        }

        // GET: SuKiens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suKien = await _context.SuKien.FindAsync(id);
            if (suKien == null)
            {
                return NotFound();
            }
            ViewData["ToChucBoi"] = new SelectList(_context.ThanhVien, "MaThanhVien", "HoTen", suKien.ToChucBoi);
            return View(suKien);
        }

        // POST: SuKiens/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSuKien,TieuDe,MoTa,ThoiGian,DiaDiem,ToChucBoi")] SuKien suKien)
        {
            if (id != suKien.MaSuKien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suKien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuKienExists(suKien.MaSuKien))
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
            ViewData["ToChucBoi"] = new SelectList(_context.ThanhVien, "MaThanhVien", "HoTen", suKien.ToChucBoi);
            return View(suKien);
        }

        // GET: SuKiens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suKien = await _context.SuKien
                .Include(s => s.ThanhVien)
                .FirstOrDefaultAsync(m => m.MaSuKien == id);
            if (suKien == null)
            {
                return NotFound();
            }

            ViewData["ToChucBoi"] = suKien.ThanhVien?.HoTen;
            return View(suKien);
        }

        // POST: SuKiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var suKien = await _context.SuKien.FindAsync(id);
            if (suKien != null)
            {
                _context.SuKien.Remove(suKien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuKienExists(string id)
        {
            return (_context.SuKien?.Any(e => e.MaSuKien == id)).GetValueOrDefault();
        }
    }
}
