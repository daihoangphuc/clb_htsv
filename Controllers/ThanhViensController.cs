using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CLB_HTSV.Data;
using CLB_HTSV.Models;

namespace CLB_HTSV.Controllers
{
    public class ThanhViensController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThanhViensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ThanhViens
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ThanhVien.Include(t => t.ChucVu).Include(t => t.LopHoc);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ThanhViens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ThanhVien == null)
            {
                return NotFound();
            }

            var thanhVien = await _context.ThanhVien
                .Include(t => t.ChucVu)
                .Include(t => t.LopHoc)
                .FirstOrDefaultAsync(m => m.MaThanhVien == id);
            if (thanhVien == null)
            {
                return NotFound();
            }

            return View(thanhVien);
        }

        // GET: ThanhViens/Create
        public IActionResult Create()
        {
            ViewData["MaChucVu"] = new SelectList(_context.Set<ChucVu>(), "MaChucVu", "TenChucVu");
            ViewData["MaLop"] = new SelectList(_context.LopHoc, "MaLop", "MaLop");
            return View();
        }

        // POST: ThanhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaThanhVien,HoTen,MaSinhVien,Email,NgayGiaNhap,MaChucVu,MaLop")] ThanhVien thanhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thanhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaChucVu"] = new SelectList(_context.Set<ChucVu>(), "MaChucVu", "TenChucVu", thanhVien.MaChucVu);
            ViewData["MaLop"] = new SelectList(_context.LopHoc, "MaLop", "MaLop", thanhVien.MaLop);
            return View(thanhVien);
        }

        // GET: ThanhViens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ThanhVien == null)
            {
                return NotFound();
            }

            var thanhVien = await _context.ThanhVien.FindAsync(id);
            if (thanhVien == null)
            {
                return NotFound();
            }
            ViewData["MaChucVu"] = new SelectList(_context.Set<ChucVu>(), "MaChucVu", "TenChucVu", thanhVien.MaChucVu);
            ViewData["MaLop"] = new SelectList(_context.LopHoc, "MaLop", "MaLop", thanhVien.MaLop);
            return View(thanhVien);
        }

        // POST: ThanhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaThanhVien,HoTen,MaSinhVien,Email,NgayGiaNhap,MaChucVu,MaLop")] ThanhVien thanhVien)
        {
            if (id != thanhVien.MaThanhVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thanhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThanhVienExists(thanhVien.MaThanhVien))
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
            ViewData["MaChucVu"] = new SelectList(_context.Set<ChucVu>(), "MaChucVu", "TenChucVu", thanhVien.MaChucVu);
            ViewData["MaLop"] = new SelectList(_context.LopHoc, "MaLop", "MaLop", thanhVien.MaLop);
            return View(thanhVien);
        }

        // GET: ThanhViens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ThanhVien == null)
            {
                return NotFound();
            }

            var thanhVien = await _context.ThanhVien
                .Include(t => t.ChucVu)
                .Include(t => t.LopHoc)
                .FirstOrDefaultAsync(m => m.MaThanhVien == id);
            if (thanhVien == null)
            {
                return NotFound();
            }

            return View(thanhVien);
        }

        // POST: ThanhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ThanhVien == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ThanhVien'  is null.");
            }
            var thanhVien = await _context.ThanhVien.FindAsync(id);
            if (thanhVien != null)
            {
                _context.ThanhVien.Remove(thanhVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThanhVienExists(string id)
        {
          return (_context.ThanhVien?.Any(e => e.MaThanhVien == id)).GetValueOrDefault();
        }
    }
}
