using Microsoft.AspNetCore.Mvc;
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
    public class BaseController : Controller
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;

        public BaseController(ILogger logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        protected List<Category> GetCategories()
        {
            return _context.Categories.AsNoTracking().ToList();
        }
    }
}
