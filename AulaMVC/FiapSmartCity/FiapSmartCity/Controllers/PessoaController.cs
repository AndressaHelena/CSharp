using FiapSmartCity.Models;
using FiapSmartCity.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace FiapSmartCity.Controllers
{
    public class PessoaController : Controller
    {

        private readonly PessoaRepository pessoaRepository;

        public PessoaController()
        {
            pessoaRepository = new PessoaRepository();
        }

        [Filtros.LogFilter]
        [HttpGet]
        public IActionResult Index()
        {
            var listaPessoa = pessoaRepository.Listar();
            return View(listaPessoa);
        }

        // Anotação de uso do Verb HTTP Get
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View(new Pessoa());
        }

        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public ActionResult Cadastrar(Models.Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoaRepository.Inserir(pessoa);

                @TempData["mensagem"] = "Cadastro efetuado com sucesso!";
                return RedirectToAction("Index", "Pessoa");

            }
            else
            {
                return View(pessoa);
            }
        }

        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var pessoa = pessoaRepository.Consultar(Id);
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Editar(Models.Pessoa pessoa)
        {

            if (ModelState.IsValid)
            {
                pessoaRepository.Alterar(pessoa);

                @TempData["mensagem"] = "Cadastro alterado com sucesso!";
                return RedirectToAction("Index", "Pessoa");
            }
            else
            {
                return View(pessoa);
            }

        }


        [HttpGet]
        public ActionResult Consultar(int Id)
        {
            var pessoa = pessoaRepository.Consultar(Id);
            return View(pessoa);
        }


        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            pessoaRepository.Excluir(Id);

            @TempData["mensagem"] = "Pessoa removido com sucesso!";

            return RedirectToAction("Index", "Pessoa");
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
}