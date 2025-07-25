using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskItemController : Controller
    {
        private readonly TaskManagerDbContext _context;
        private int? _userId;

        public TaskItemController(TaskManagerDbContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userIdString = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId)) // Si no hay sesión o no se puede parsear, pal login
			{
                
                context.Result = RedirectToAction("Login", "Account");
                return;
            }

            _userId = userId;

            base.OnActionExecuting(context);
        }


        public async Task<IActionResult> Index()
        {
            var taskItems = await _context.TaskItems
                .Where(t => t.UserId == _userId)
                .Include(b => b.Category)
                .ToListAsync();

            return View(taskItems);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskItem taskItem) 
        {
            if (ModelState.IsValid)
            {
                _context.TaskItems.Add(taskItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", taskItem.CategoryId);
            return View(taskItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _context.TaskItems.Find(id);
            if (task != null)
            {
                _context.TaskItems.Remove(task);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            var taskItem = _context.TaskItems.FirstOrDefault(t => t.Id == id);
            if (taskItem == null)
                return NotFound();

            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", taskItem.CategoryId);
            return View(taskItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                _context.TaskItems.Update(taskItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", taskItem.CategoryId);
            return View(taskItem);
        }
    }
}