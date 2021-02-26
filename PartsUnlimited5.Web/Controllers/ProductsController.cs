using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PartsUnlimited5.Web.Data;
using PartsUnlimited5.Web.Models;

namespace PartsUnlimited5.Web.Controllers
{
    [Authorize(Roles = "SystemAdmin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products.Include(p => p.CreatedByUser).Include(p => p.LastModifiedByUser).Include(p => p.Manufacturer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.CreatedByUser)
                .Include(p => p.LastModifiedByUser)
                .Include(p => p.Manufacturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CreatedByUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["LastModifiedByUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "CreatedByUserId");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkuNumber,Title,Price,SalePrice,ProductArtUrl,Description,ProductDetails,LeadTime,ManufacturerId,Id,IsActive,CreatedDate,CreatedByUserId,LastModifiedDate,LastModifiedByUserId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedByUserId"] = new SelectList(_context.Users, "Id", "Id", product.CreatedByUserId);
            ViewData["LastModifiedByUserId"] = new SelectList(_context.Users, "Id", "Id", product.LastModifiedByUserId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "CreatedByUserId", product.ManufacturerId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CreatedByUserId"] = new SelectList(_context.Users, "Id", "Id", product.CreatedByUserId);
            ViewData["LastModifiedByUserId"] = new SelectList(_context.Users, "Id", "Id", product.LastModifiedByUserId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "CreatedByUserId", product.ManufacturerId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SkuNumber,Title,Price,SalePrice,ProductArtUrl,Description,ProductDetails,LeadTime,ManufacturerId,Id,IsActive,CreatedDate,CreatedByUserId,LastModifiedDate,LastModifiedByUserId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["CreatedByUserId"] = new SelectList(_context.Users, "Id", "Id", product.CreatedByUserId);
            ViewData["LastModifiedByUserId"] = new SelectList(_context.Users, "Id", "Id", product.LastModifiedByUserId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "CreatedByUserId", product.ManufacturerId);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.CreatedByUser)
                .Include(p => p.LastModifiedByUser)
                .Include(p => p.Manufacturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
