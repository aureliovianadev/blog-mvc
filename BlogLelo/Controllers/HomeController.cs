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
        ViewData["Mensagem"] = "Olá Mundo";
        // Criar objetos
        Categoria categoria = new();
        categoria.Id = 1;
        categoria.Nome = "Tecnologia";

        Categoria categoria2 = new()
        {
            Id = 2,
            Nome = "IA"
        };

        List<Postagem> postagens = [
            new() {
                Id = 1,
                Nome = "Saiu o ChatGPT 5!!!",
                CategoriaId = 2,
                Categoria = categoria2,
                DataPostagem = DateTime.Parse("07/08/2025"),
                Descricao = "Estou com preguiça de pensar nisso",
                Texto = "Loren ipsum"
            }
        ];
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
