using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace alimentesebem.sesi.domain.Entities
{
    public abstract class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo Endereço deve ter no minimo 3 caracteres e no maximo 200.")]
        public string Local { get; set; }

        [Required]
        [StringLength(9, ErrorMessage = "O campo CEP deve conter o formato 00000-000")]
        public string CEP { get; set; }


        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo Cidade deve ter no minimo 3 caracteres e no maximo 200.")]
        public string Cidade { get; set; }


        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O campo Estado deve ser no formato de 2 caracteres (ex: SP)")]
        public string Estado { get; set; }





    }
}