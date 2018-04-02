using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace alimentesebem.sesi.domain.Entities
{
    public class Restaurante : Endereco
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter no minimo 3 caracteres e no maximo 100.")]
        public string Nome { get; set; }
    }
}