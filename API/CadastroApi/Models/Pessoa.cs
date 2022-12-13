using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CadastroApi.Models
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        
        public string? NomePessoa { get; set; }
        public string? AddressPessoa { get; set; }

        public int IdPet { get; set; }
    }
}
