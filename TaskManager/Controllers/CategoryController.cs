using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Controllers
{
    public class CategoryController : Controller
    {
        private readonly TaskManagerDbContext _context;

        public CategoryController(TaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }
    }
}
