using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Controllers
{
    public class CategoryController : Controller
    {
        private readonly TaskManagerContext _context;

        public CategoryController(TaskManagerContext context)
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
