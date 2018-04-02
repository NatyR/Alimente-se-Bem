using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace alimentesebem.sesi.domain.Entities
{
    public class Nutricionista : Endereco
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter no minimo 3 caracteres e no maximo 100.")]
        public string Nome { get; set; }


        [Required]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Favor insira um email valido.")]
        public string Email { get; set; }


        [Required]
       // [StringLength(10, MinimumLength = 3, ErrorMessage = "O campo NIF é de preenchimento obrigatório.")]
        public int NIF { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O campo Cargo deve ter no minimo 5 caracteres e no maximo 100.")]
        public string Cargo { get; set; }

    }
}