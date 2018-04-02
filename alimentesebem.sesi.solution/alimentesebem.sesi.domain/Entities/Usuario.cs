using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace alimentesebem.sesi.domain.Entities
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter no minimo 5 caracteres e no maximo 100.")]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Favor insira um email valido.")]
        public string Email { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 8, ErrorMessage = "A senha deve ter no minimo 8 caracteres.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        // public ICollection<Permissao> Permissao { get; set;}  


    }
}