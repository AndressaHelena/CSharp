using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapSmartCity.Models
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        [Required(ErrorMessage = "Campo obrigatória!")]
        [StringLength(50, ErrorMessage = "O nome deve ter, no máximo, 50 caracteres")]
        [Display(Name = "Nome")]
        
        public string? NomePessoa { get; set; }
        public string? AddressPessoa { get; set; }

        public Pet? IdPet { get; set; }

    }
    
}
