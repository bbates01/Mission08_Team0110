using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Mission08_Team0110.Models;

=======
// using Mission08_Team0110.Models;
using Mission08_Team0110.Models;
>>>>>>> 0e1120f5c562bd8e56d103829b5f6379f3e7aaeb
namespace Mission08_Team0110.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.Name)
            .ToList();
        
        return View(new TaskItem());
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Tasks
            .Single(x => x.TaskId == id);

        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.Name)
            .ToList();
        
        return View("Create", recordToEdit);
    }
    public IActionResult Quadrants()
    {
        return View(new List<TaskItem>());
    }
}