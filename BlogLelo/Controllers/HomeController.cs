using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogLelo.Models;

namespace BlogLelo.Controllers;

public class HomeController : Controller // O HomeController pega a herança do Controller // todos tem acesso
{
    private readonly ILogger<HomeController> _logger; // privado apenas aqui tem acesso

    public HomeController(ILogger<HomeController> logger) 
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
