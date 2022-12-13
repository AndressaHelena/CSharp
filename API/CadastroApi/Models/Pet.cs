using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CadastroApi.Models
{
    public class Pet
    {
        public int IdPet { get; set; }
        public string? NomePet { get; set; }
        public int IdadePet { get; set; }
    }
}
