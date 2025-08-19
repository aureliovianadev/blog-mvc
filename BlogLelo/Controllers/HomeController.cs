using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogLelo.Models;
using System.Threading.Tasks.Dataflow;

namespace BlogLelo.Controllers;

public class HomeController : Controller // O HomeController pega a herança do Controller // todos tem acesso
{
    private readonly ILogger<HomeController> _logger; // privado apenas aqui tem acesso
    private List<Postagem> postagens;

    public HomeController(ILogger<HomeController> logger) 
    {
        _logger = logger;

        Categoria decoracao = new();
        decoracao.Id = 1;
        decoracao.Nome = "Item decorativo";

       

        postagens = [
        
            new() {
                Id = 1,
                Nome = "Espelhos",
                CategoriaId = 1,
                Categoria = decoracao,
                DataPostagem = DateTime.Parse("07/08/2025"),
                Descricao = "Espelho redondo decorativo, elegante e versátil, ideal para ampliar e iluminar qualquer ambiente.",
                Texto = "Os espelhos são uma ótima forma de adicionar o tom metalizado no espaço. O tipo de moldura pode ser variado, indo das mais simples até outras cheias de detalhes. No banheiro do nosso escritório, por exemplo, escolhemos molduras bem chamativas para se destacarem no ambiente preto.<br>No entanto, se você preferir algo mais discreto e, ainda assim, charmoso, opte pelos espelhos com bordas bem fininhas. Os redondos são os mais fofos e fazem toda a diferença no espaço, principalmente em um quarto ou no hall de entrada da sua casa/escritório.",
                Thumbnail = "/img/1espelho.jpg",
                Foto = "/img/1espelho.jpg"
            },
            new() {
                Id = 1,
                Nome = "Vasinhos",
                CategoriaId = 1,
                Categoria = decoracao,
                DataPostagem = DateTime.Parse("09/08/2025"),
                Descricao = "Vasinhos decorativos, charmosos e versáteis, perfeitos para plantas naturais ou artificiais em qualquer ambiente.",
                Texto = "Tem coisa melhor do que ver um ambiente cheio de plantinhas na decoração? Eu, pelo menos, acho uma graça! Vasinhos dourados, além de transformarem o local, valorizam a própria planta.Os vasos em formatos geométricos são os mais diferentes, principalmente quando ficam pendurados ou pregados na parede. Quando colocados em um fundo neutro, o resultado fica ainda mais lindo. ",
                Thumbnail = "/img/2vasinhos.jpg",
                Foto = "/img/2vasinhos.jpg"
            },
            new() {
                Id = 1,
                Nome = "Mesinhas",
                CategoriaId = 1,
                Categoria = decoracao,
                DataPostagem = DateTime.Parse("10/08/2025"),
                Descricao = "Mesinhas funcionais e elegantes, ideais para decorar e organizar qualquer ambiente com estilo.",
                Texto = "Uma maneira um pouco menos discreta, mas ainda assim super delicada, são as mesinhas e aparadores dourados. Elas podem ser inteiras metalizadas ou apenas com a base em tons da cor. Pode não parecer, mas esse tipo de tom dá um resultado super interessante na composição total do ambiente.",
                Thumbnail = "/img/3mesinhas.jpg",
                Foto = "/img/3mesinhas.jpg"
            },

        ];

    }

    public IActionResult Index()
    {
       
        return View(postagens);
    }

   public IActionResult Postagem(int id)
    {
        var postagem = postagens
        .Where(p => p.Id == id)
        .SingleOrDefault();
        if(postagem == null)
            return NotFound();
            return View(postagem);
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
