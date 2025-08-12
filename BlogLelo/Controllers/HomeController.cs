using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogLelo.Models;
using System.Threading.Tasks.Dataflow;

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
       
        // Criar objetos
        Categoria confeitaria = new();
        confeitaria.Id = 1;
        confeitaria.Nome = "Bolo ópera: passo a passo completo | Gâteau Opéra";

        Categoria decoracao = new()
        {
            Id = 2,
            Nome = "Toque Dourado no Décor!"
        };

        Categoria categoria3 = new(3, "Eletrônicos");


        List<Postagem> postagens = [
            new() {
                Id = 2,
                Nome = "Toque Dourado no Décor!",
                CategoriaId = 2,
                Categoria = decoracao,
                DataPostagem = DateTime.Parse("07/08/2025"),
                Descricao = "",
                Texto = "",
                Thumbnail = "",
                Foto = ""
            },
            new() {
                Id = 1,
                Nome = "Bolo ópera: passo a passo completo | Gâteau Opéra",
                CategoriaId = 1,
                Categoria = confeitaria,
                DataPostagem = DateTime.Parse("07/08/2025"),
                Descricao = "O Gâteau Opéra ou, de uma forma abrasileirada, Bolo Ópera, é uma sobremesa deliciosa com muitas camadas e uma das receitas mais clássicas da confeitaria francesa. É feito com biscuit amande, que é quase um pão de ló de farinha de amêndoas. Além disso, muitas camadas intercaladas com creme de manteiga e ganache.<br>Uma das coisas mais importantes dessa receita é o sabor de café. O ingrediente, combinado ao chocolate na medida perfeita, trás o melhor dos mundos para o seu paladar. A sobremesa já foi eleita no MasterChef como o bolo mais difícil do mundo, mas se você já viu o bolo de 23 camadas ou o chocolate quente com marshmallow, vai concordar comigo que não é tãããão difícil assim. Vamos tentar? Segue o passo a passo completo que você vai conseguir.",
                Texto = "<ul><li><strong>Ingredientes: Biscuit Amande (massa)</strong><ul><li>70 gramas de manteiga sem sal</li><li>340 gramas de farinha de amêndoas</li><li>340 gramas de açúcar impalpável</li><li>90 gramas de farinha de trigo</li><li>8 ovos</li><li>9 claras</li><li>50 gramas de açúcar</li></ul></li><li><strong>Ingredientes: Calda</strong><ul><li>1 xícara de água</li><li>½ xícara de açúcar</li><li>2 colheres de sopa de café solúvel</li></ul></li><li><strong>Ingredientes: Creme de manteiga</strong><ul><li>300 ml de leite</li><li>3 colheres de sopa de café solúvel</li><li>5 gemas</li><li>50 gramas de açúcar refinado</li><li>500 gramas de manteiga sem sal</li><li>3 claras</li><li>90 gramas de açúcar refinado</li></ul></li><li><strong>Ingredientes: Ganache</strong><ul><li>220 ml de leite</li><li>300 gramas de chocolate amargo</li><li>100 gramas de manteiga</li></ul></li><li><strong>Ingredientes: Glaçagem</strong><ul><li>100 gramas de açúcar refinado</li><li>45 ml de água</li><li>75 ml de creme de leite fresco ou nata</li><li>35 gramas de cacau em pó 100%</li><li>1 colher de sopa de glicose</li><li>1 folha de gelatina</li></ul></li></ul><br><br><ul><li><strong>Modo de preparo: Biscuit Amande (massa)</strong><ul><li>Derreta a manteiga em fogo baixo, desligue e deixe esfriar.</li><li>Em um recipiente misture a farinha de amêndoas, o açúcar impalpável e a farinha de trigo, todos peneirados.</li><li>Acrescente os ovos e misture com a batedeira até ficar completamente homogêneo.</li><li>Na sequência, coloque a manteiga derretida e misture.</li><li>Em outro recipiente, bata as claras até espumar. Acrescente ⅓ de açúcar, bata até ficar branquinho.</li><li>Coloque o restante das claras e bata mais um pouco até criar ondinhas.</li><li>Misture delicadamente as claras na massa com a ajuda de um fuê, colocando primeiro a metade e depois o restante.</li><li>Distribua a massa em três partes iguais em formas também iguais de 40x30 cm, com papel manteiga.</li><li>Passe o dedo polegar nas laterais, apertando o papel manteiga e homogeneizando as bordas.</li><li>Leve para assar em forno preaquecido a 220ºC por 7 a 10 minutos ou até que esteja levemente dourada.</li><li><em>Dica:</em> asse todas as massas ao mesmo tempo para não perder a aeração das claras. Caso não tenha espaço, divida a receita em 3 partes e prepare a massa logo antes de assar.</li><li>Ao tirar do forno, envolva as massas com plástico filme e espere esfriar assim, para não perder a umidade.</li></ul></li><li><strong>Modo de preparo: Calda</strong><ul><li>Misture a água, o açúcar e o café solúvel em uma panela e deixe esquentar.</li><li>Coloque em um potinho fechado e deixe esfriar.</li></ul></li><li><strong>Modo de preparo: Creme de manteiga</strong><ul><li><strong>Creme de gemas:</strong> coloque o leite e o café solúvel em uma panela, misture e deixe ferver.</li><li>Em outro recipiente, bata as gemas e o açúcar.</li><li>Coloque o leite fervido aos poucos por cima das gemas e mexa bem.</li><li>Leve de volta para o fogo até cozinhar e ficar um pouco cremoso (ponto napê).</li><li>Leve para a batedeira para misturar bem e amornar.</li><li>Ao amornar, coloque a manteiga gelada picada e continue batendo até ficar cremosa.</li><li>Reserve e faça o merengue suíço.</li><li><strong>Merengue suíço:</strong> misture as claras com o açúcar e leve ao fogo em banho-maria até ficar morno e o açúcar dissolver.</li><li>Tire do banho-maria e bata na batedeira até ficar cremoso e com ondinhas.</li><li>Misture o merengue ao creme de gemas colocando primeiro a metade e depois o restante.</li><li>Reserve.</li></ul></li><li><strong>Modo de preparo: Ganache</strong><ul><li>Ferva o leite e coloque sobre o chocolate picado. Deixe parado por 3 minutos antes de mexer.</li><li>Misture bem até ficar homogêneo e acrescente a manteiga gelada picada.</li><li>Mexa até se dissolver completamente.</li><li>Reserve.</li></ul></li></ul><ul><li><strong>Modo de preparo: Montagem</strong><ul><li>Tire os plásticos filme que estão envolvidos nas massas.</li><li>Use o fundo da forma para cortar as massas no formato ideal e tirar as bordas.</li><li>Vire do outro lado e retire o papel manteiga.</li><li><em>Dica:</em> utilize um utensílio mais duro, como um levantador de bolo, para auxiliar na retirada do papel manteiga.</li><li>Coloque o primeiro biscuit amande na forma de montagem, deixando para cima a parte contrária da que estava em contato com o papel manteiga.</li><li>Molhe bem com a calda utilizando um pincel.</li><li>Coloque metade do creme de manteiga e espalhe bem.</li><li>Leve para o congelador por 15 minutos.</li><li>Coloque o outro biscuit amande, molhe com a calda de café e distribua toda a ganache de chocolate, espalhando bem.</li><li>Leve para o congelador por 15 minutos.</li><li>Adicione mais uma camada de creme de manteiga, alise bem e deixe bem reto.</li><li>Leve para o congelador por 30 minutos.</li></ul></li><li><strong>Modo de preparo: Glaçagem e finalização</strong><ul><li>Coloque em uma panela o açúcar, a água, o creme de leite, o cacau e a glucose. Misture bem e deixe até ferver.</li><li>Tire a mistura do fogo e deixe amornar, até ficar de morno para quente (em 55ºC) e acrescente a gelatina já hidratada. Mexa bem até dissolver.</li><li>Com a ajuda de um mixer, coloque dentro da panela e deixe por um minuto para incorporar bem.</li><li>Deixe esfriar um pouco, até ficar morno (35ºC).</li><li>Tire o Ópera do congelador e coloque a cobertura de glaçagem por cima passando por uma peneira.</li><li>Levante a forma de um lado para o outro para espalhar bem a glaçagem sem usar uma espátula.</li><li>Deixe voltar à temperatura ambiente fora da geladeira por 20 minutos.</li><li>Passe uma faca nas laterais e desenforme.</li><li>Esquente uma faca colocando em água quente e corte as laterais para melhorar a apresentação das camadas.</li><li>Sirva em temperatura de geladeira, em fatias finas e aproveite!</li></ul></li></ul>",
                Thumbnail = "/img/1opera.jpg",
                Foto = "/img/1opera.jpg"
            },
        ];
        return View(postagens);
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
