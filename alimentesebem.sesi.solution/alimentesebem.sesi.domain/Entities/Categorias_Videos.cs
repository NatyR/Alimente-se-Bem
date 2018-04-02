using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace alimentesebem.sesi.domain.Entities
{
    public class Categorias_Videos
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O campo Nome de usuario deve ter no minimo 3 caracteres e no maximo 200.")]
        public string Nome { get; set; }


        public ICollection<Videos> Videos { get; set; }


    }
}