using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Models
{
    public class CadastroPessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "Nome obrigatório")]
        [StringLength(50)]
        [Display(Name = "Nome:")]
        public string? NomePessoa { get; set; }

        
        [Required(ErrorMessage = "Endereço obrigatório")]
        [StringLength(50)]
        public string EnderecoPessoa { get; set; }
        

        [Required(ErrorMessage = "E-mail obrigatório")]
        [StringLength(50)]
        public string EmailPessoa { get; set; }
        
    }
}
