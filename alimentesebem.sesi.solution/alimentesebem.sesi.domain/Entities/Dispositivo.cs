using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace alimentesebem.sesi.domain.Entities
{
    public class Dispositivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo Marca deve ter no minimo 3 caracteres e no maximo 50.")]
        public string Marca { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo Modelo deve ter no minimo 3 caracteres e no maximo 50.")]
        public string Modelo { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O campo Serial deve ter no minimo 5 caracteres e no maximo 100.")]
        public string Serial { get; set; }

        [ForeignKey("Id_Restaurante")]
        public Restaurante Restaurante { get; set; }
        public int Id_Restaurante { get; set; }

        public ICollection<Perguntas> Perguntas { get; set;}         


    }
}