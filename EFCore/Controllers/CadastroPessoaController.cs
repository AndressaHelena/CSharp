using Microsoft.AspNetCore.Mvc;
using EFCore.Models;
using EFCore.Repository;

namespace EFCore.Controllers
{
    public class CadastroPessoaController : Controller
    {
        private readonly CadastroPessoaRepositoryEF CadastroPessoaRepositoryEF;

        public CadastroPessoaController()
        {
            CadastroPessoaRepositoryEF = new CadastroPessoaRepositoryEF();
        }

        // GET: CadrastroPessoas
        public IActionResult Index()

        {
            var listaPessoa = CadastroPessoaRepositoryEF.Listar();
            return View(listaPessoa);
        }
        
        // GET: CadastroPessoa/Create-OK
        public ActionResult Create()
        {
            return View(new CadastroPessoa());
        }

        // POST: CadastroPessoa/Create-OK
        public ActionResult Create(Models.CadastroPessoa cadastroPessoa)
        {
            if (ModelState.IsValid)
            {
               CadastroPessoaRepositoryEF.Inserir(cadastroPessoa);
                return RedirectToAction("Index" , "CadastroPessoa");
            }
            return View(cadastroPessoa);
        }

        // GET: CadastroPessoa/Edit/5-OK
       
        public ActionResult Edit(int Id)
        {
            var cadastroPessoa = CadastroPessoaRepositoryEF.Consultar(Id);
            return View(cadastroPessoa);
        }

        // POST: CadastroPessoa/Edit/5-OK
       
        public ActionResult Edit(Models.CadastroPessoa cadastroPessoa)
        {
            if (ModelState.IsValid)
            {
                CadastroPessoaRepositoryEF.Alterar(cadastroPessoa);
                @TempData["mensagem"] = "Cadastro alterado com sucesso!";
                return RedirectToAction("Index", "CadastroPessoa");
            }
            else
            {
                return View(cadastroPessoa);
            }
        }

        // GET: CadastroPessoa/Delete/5
        
        public ActionResult Delete(int Id)
        {
            CadastroPessoaRepositoryEF.Excluir(Id);

            TempData["mensagem"] = "Cadastro removido com sucesso!";

            return RedirectToAction("Index", "CadastroPessoa");
        }

    }
}
