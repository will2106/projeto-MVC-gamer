using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Gamer_MVC.Infra;
using Gamer_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gamer_MVC.Controllers
{
    [Route("[controller]")]
    public class EquipeController : Controller
    {
        private readonly ILogger<EquipeController> _logger;

        public EquipeController(ILogger<EquipeController> logger)
        {
            _logger = logger;
        }


        Context c = new Context();// instacia do contexto para acessar o banco de dados


        [Route("Listar")] //http:localhost//Equipe/Listar
        public IActionResult Index()
        {
            // variavel que armazena as equipes listadas  do banco
            ViewBag.Equipe = c.Equipe.ToList();


            // retorna a view da equipe (TELA)
            return View();
        }

        [Route("Cadastrar")]

        public IActionResult Cadastrar(IFormCollection form)
        {

            Equipe novaEquipe = new Equipe();


            novaEquipe.Nome = form["Nome"].ToString();


            if (form.Files.Count > 0)
            {


                var file = form.Files[0];


                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");


                if (!Directory.Exists(folder))
                {

                    Directory.CreateDirectory(folder);

                }


                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))

                {

                    file.CopyTo(stream);


                }


                novaEquipe.Imagem = file.FileName;



            }


            else
            {

                novaEquipe.Imagem = "padrão.png";

            }


            c.Equipe.Add(novaEquipe);


            c.SaveChanges();


            return LocalRedirect("~/Equipe/Listar");


        }


[Route("Excluir/{id}")]

public IActionResult Excluir(int id) 

{
 Equipe equipeBuscada = c.Equipe.First(e => e.IdEquipe == id);

c.Remove(equipeBuscada);

c.SaveChanges();

return LocalRedirect("~/Equipe/Listar");



}
























        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }



    }
}