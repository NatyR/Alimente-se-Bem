using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace alimentesebem.sesi.domain.Entities
{
    public class Permissao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo Descricao deve ter no minimo 3 caracteres e no maximo 50.")]
        public string Descricao { get; set; }

        // [ForeignKey("Id_Usuario")]
        // public Usuario Usuario { get; set; }
        // public int Id_Usuario{ get; set; }  

    }
}