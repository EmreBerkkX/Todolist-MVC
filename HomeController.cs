using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _1.Models;
using _1.Models.Entities;

namespace _1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    MydatabaseContext db = new MydatabaseContext();

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }
    public IActionResult Todolist()
    {
        var model = new TodoViewModel() { Todos = db.Todos.ToList(), };
        return View(model);
    }
    [IgnoreAntiforgeryToken]
    [Route("/add/todo")]

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult AddTodo(Todo postedData)
    {
        Todo toAdd=new Todo();

        toAdd.Title=postedData.Title;
        toAdd.Iscomplated=0;
        db.Add(toAdd);
        db.SaveChanges();        
        return Redirect("/todolist");
    }
}
