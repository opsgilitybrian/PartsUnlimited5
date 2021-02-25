using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PartsUnlimited5.Web.Data;
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
            var categories = _context.Categories.AsNoTracking().ToList();
            
            int categoryId = 0;
            switch (category)
            {
                case "Brakes":
                    categoryId = categories.SingleOrDefault(x => x.Name.ToLower().Equals("brakes"))?.Id ?? 0;
                    break;
                case "Lighting":
                    categoryId = categories.SingleOrDefault(x => x.Name.ToLower().Equals("lighting"))?.Id ?? 0;
                    break;
                case "WheelsAndTires":
                    categoryId = categories.SingleOrDefault(x => x.Name.ToLower().Equals("wheelsandtires"))?.Id ?? 0;
                    break;
                case "Batteries":
                    categoryId = categories.SingleOrDefault(x => x.Name.ToLower().Equals("batteries"))?.Id ?? 0;
                    break;
                case "Oil":
                    categoryId = categories.SingleOrDefault(x => x.Name.ToLower().Equals("oil"))?.Id ?? 0;
                    break;
                case "More":
                    categoryId = -1;
                    break;
                default:
                    break;
            }

            return View(categoryId);
        }
    }
}
