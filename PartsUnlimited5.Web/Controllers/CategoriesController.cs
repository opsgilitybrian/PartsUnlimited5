using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PartsUnlimited5.Web.Data;
using PartsUnlimited5.Web.Models;

namespace PartsUnlimited5.Web.Controllers
{
    [Authorize(Roles = "SystemAdmin")]
    public class CategoriesController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ILogger<CategoriesController> logger, ApplicationDbContext context)
            :base(logger, context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Categories.Include(c => c.CreatedByUser).Include(c => c.LastModifiedByUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.CreatedByUser)
                .Include(c => c.LastModifiedByUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            ViewData["CreatedByUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["LastModifiedByUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,ImageUrl,Id,IsActive,CreatedDate,CreatedByUserId,LastModifiedDate,LastModifiedByUserId")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedByUserId"] = new SelectList(_context.Users, "Id", "Id", category.CreatedByUserId);
            ViewData["LastModifiedByUserId"] = new SelectList(_context.Users, "Id", "Id", category.LastModifiedByUserId);
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            ViewData["CreatedByUserId"] = new SelectList(_context.Users, "Id", "Id", category.CreatedByUserId);
            ViewData["LastModifiedByUserId"] = new SelectList(_context.Users, "Id", "Id", category.LastModifiedByUserId);
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,ImageUrl,Id,IsActive,CreatedDate,CreatedByUserId,LastModifiedDate,LastModifiedByUserId")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            ViewData["CreatedByUserId"] = new SelectList(_context.Users, "Id", "Id", category.CreatedByUserId);
            ViewData["LastModifiedByUserId"] = new SelectList(_context.Users, "Id", "Id", category.LastModifiedByUserId);
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .Include(c => c.CreatedByUser)
                .Include(c => c.LastModifiedByUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
