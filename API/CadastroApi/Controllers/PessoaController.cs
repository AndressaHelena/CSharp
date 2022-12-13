using CadastroApi.Models;
using CadastroApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CadastroApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : Controller
    {
        private readonly PessoaRepository pessoaRepository;

        public PessoaController()
        {
            pessoaRepository = new PessoaRepository();
        }


        // Anotação de uso do Verb HTTP Get
        [HttpPost]
        [Route("Cadastrar")]
        public ActionResult Cadastrar(Models.Pessoa pessoa)
        {
            try
            {
                pessoaRepository.Inserir(pessoa);
                return Ok(pessoa);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]//consultar lista
        [Route("Listar")]
        public IActionResult Consultar()
        {
            try
            {
                var listaPessoa = pessoaRepository.Listar();
                return Ok(listaPessoa);
            }
            catch (NotFiniteNumberException)
            {
                return NotFound();
            }
        }

        [HttpGet]//consultar Pessoa por id ok
        [Route("Consultar/Id")]
        public ActionResult Consultar(int Id)
        {
            try
            {
                var pessoa = pessoaRepository.Consultar(Id);
                if (pessoa.IdPessoa != 0)
                {
                    return Ok(pessoa);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("Editar")]
        public ActionResult Editar(Models.Pessoa pessoa)
        {
            try
            {
                pessoaRepository.Alterar(pessoa);
                return Ok(pessoa);
            }
            catch (KeyNotFoundException)
            {

                return BadRequest();
            }
        }

        [HttpDelete]//Excluir ok
        [Route("Deletar")]
        public ActionResult Excluir(int Id)
        {
            try
            {
                pessoaRepository.Excluir(Id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }
    }
}
