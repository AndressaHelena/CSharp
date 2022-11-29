using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapSmartCity.Models
{
    public class Pet
    {
        public int IdPet { get; set; }
        [Required(ErrorMessage = "Nome obrigatória!")]
        [StringLength(50, ErrorMessage = "O nome deve ter, no máximo, 50 caracteres")]
        [Display(Name = "Nome:")]

        public string? NomePet { get; set; }
    }
}
