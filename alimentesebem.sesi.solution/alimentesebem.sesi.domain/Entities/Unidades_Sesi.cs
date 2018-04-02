using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace alimentesebem.sesi.domain.Entities
{
    public class Unidades_Sesi : Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "O campo Nome deve ter no minimo 5 caracteres e no maximo 200.")]
        public string Nome { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "O campo Codigo_Unidade é de preenchimento obrigatório")]
        public string Codigo_Unidade { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "O campo Telefone é de preenchimento Obrigatório.")]
        public string Telefone { get; set; }


    }
}