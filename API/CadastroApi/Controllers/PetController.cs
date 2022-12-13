using CadastroApi.Models;
using CadastroApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CadastroApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : Controller
    {
        private readonly PetRepository petRepository;

        public PetController()
        {
            petRepository = new PetRepository();
        }

        // CADASTRAR PET
        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(Models.Pet pet)
        {
            try
            {
                petRepository.Inserir(pet);
                return Ok(pet);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // EDITAR PET
        [HttpPost("Editar")]
        public ActionResult Editar(Pet pet)
        {
            try
            {
                petRepository.Alterar(pet);
                return Ok(pet);
            }
            catch (KeyNotFoundException)
            {

                return BadRequest();
            }
        }

        [HttpPost("Consultar/Id")]//consultar Pessoa por id ok
       
        public ActionResult Consultar(int Id)
        {
            try
            {
                var pet = petRepository.Consultar(Id);
                if (pet.IdPet != 0)
                {
                    return Ok(pet);
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

        // EXCLUIR PET
        [HttpDelete]
        public ActionResult Excluir(int Id)
        {
            try
            {
                petRepository.Excluir(Id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return BadRequest();
            }
        }
    }
}

