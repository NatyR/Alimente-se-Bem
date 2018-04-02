using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace alimentesebem.sesi.domain.Entities
{

    public class Noticias
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "O campo Tiyulo deve ter no minimo 10 caracteres e no maximo 300.")]
        public string Titulo { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 50, ErrorMessage = "O campo Headline deve ter no minimo 50 caracteres e no maximo 500.")]
        public string Headline { get; set; }

        [Required]
        [StringLength(10000, MinimumLength = 100, ErrorMessage = "O campo Descricao deve ter no minimo 100 caracteres.")]
        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Data_Criacao { get; set; }

        [Required]
        public string Imagem { get; set; }

        public string Link_Externo { get; set; }


        [ForeignKey("Id_Cat_Noticias")]
        public Categorias_Noticias Categorias_Noticias { get; set; }
        public int Id_Cat_Noticias { get; set; }

    }
}

