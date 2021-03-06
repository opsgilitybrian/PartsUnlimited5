﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PartsUnlimited5.Web.Data;
using PartsUnlimited5.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartsUnlimited5.Web.Controllers
{
    public class InventoryController : Controller
    {
        private ILogger<InventoryController> _logger;
        private ApplicationDbContext _context;

        public InventoryController(ILogger<InventoryController> logger, ApplicationDbContext context) 
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Browse(string category)
        {
            var categories = _context.Categories.Include(y => y.Products).AsNoTracking().ToList();
            var products = new List<Product>();
            Category cat = new Category();
            switch (category)
            {
                case "Brakes":
                    cat = categories.SingleOrDefault(x => x.Name.ToLower().Equals("brakes"));
                    break;
                case "Lighting":
                    cat = categories.SingleOrDefault(x => x.Name.ToLower().Equals("lighting"));
                    break;
                case "WheelsAndTires":
                    cat = categories.SingleOrDefault(x => x.Name.ToLower().Equals("wheelsandtires"));
                    break;
                case "Batteries":
                    cat = categories.SingleOrDefault(x => x.Name.ToLower().Equals("batteries"));
                    break;
                case "Oil":
                    cat = categories.SingleOrDefault(x => x.Name.ToLower().Equals("oil"));
                    break;
                case "All":
                    cat = null;
                    foreach (var c in categories)
                    {
                        if (c.Products != null && c.Products.Any())
                        {
                            products.AddRange(c.Products);
                        }
                    }
                    break;
                default:
                    break;
            }

            if (cat != null && cat.Products != null && cat.Products.Any())
            {
                products = cat.Products;
            }

            return View(products);
        }

        public async Task<IActionResult> Stores(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var store = await _context.Stores
                .Include(s => s.CreatedByUser)
                .Include(s => s.LastModifiedByUser)
                .Include(s => s.Inventory).ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }


        public async Task<IActionResult> Products(int id)
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
    }
}
