using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebLaptop.Models;

namespace WebLaptop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTaiKhoansController : Controller
    {
        private readonly DbShopLaptopContext _context;

        public AdminTaiKhoansController(DbShopLaptopContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminTaiKhoans
        public async Task<IActionResult> Index()
        {
            ViewData["QuyenTruyCap"] = new SelectList(_context.Roles, "Id", "Desciption");
            List<SelectListItem> IsTrangThai = new List<SelectListItem>();
            IsTrangThai.Add(new SelectListItem() { Text = "Active", Value = "1" });
            IsTrangThai.Add(new SelectListItem() { Text = "Block", Value = "0" });
            ViewData["IsTrangThai"] = IsTrangThai;
            var dbShopLaptopContext = _context.TaiKhoans.Include(t => t.Role);
            return View(await dbShopLaptopContext.ToListAsync());
        }

        // GET: Admin/AdminTaiKhoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoan = await _context.TaiKhoans
                .Include(t => t.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            return View(taiKhoan);
        }

        // GET: Admin/AdminTaiKhoans/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id");
            return View();
        }

        // POST: Admin/AdminTaiKhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sdt,Email,Matkhau,Trangthai,Ten,RoleId,Lastlogin,Createlogin,Salt")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taiKhoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", taiKhoan.RoleId);
            return View(taiKhoan);
        }

        // GET: Admin/AdminTaiKhoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoan = await _context.TaiKhoans.FindAsync(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", taiKhoan.RoleId);
            return View(taiKhoan);
        }

        // POST: Admin/AdminTaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sdt,Email,Matkhau,Trangthai,Ten,RoleId,Lastlogin,Createlogin,Salt")] TaiKhoan taiKhoan)
        {
            if (id != taiKhoan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taiKhoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaiKhoanExists(taiKhoan.Id))
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", taiKhoan.RoleId);
            return View(taiKhoan);
        }

        // GET: Admin/AdminTaiKhoans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoan = await _context.TaiKhoans
                .Include(t => t.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            return View(taiKhoan);
        }

        // POST: Admin/AdminTaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taiKhoan = await _context.TaiKhoans.FindAsync(id);
            _context.TaiKhoans.Remove(taiKhoan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaiKhoanExists(int id)
        {
            return _context.TaiKhoans.Any(e => e.Id == id);
        }
    }
}
