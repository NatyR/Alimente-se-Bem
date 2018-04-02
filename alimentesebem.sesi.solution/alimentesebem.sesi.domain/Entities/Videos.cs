using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace alimentesebem.sesi.domain.Entities
{
    public class Videos
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "O campo Titulo deve ter no minimo 10 caracteres e no maximo 200.")]
        public string Titulo { get; set; }


        [Required]
        [StringLength(800, MinimumLength = 10, ErrorMessage = "O campo Descricao deve ter no minimo 10 caracteres.")]
        public string Descricao { get; set; }


        [Required]
        [StringLength(400, MinimumLength = 3, ErrorMessage = "O campo URL do vídeo é de preenchimento obrigatório.")]
        public string URL { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Data_Publicacao { get; set; }


        public string Link_Externo { get; set; }


        [ForeignKey("Id_Cat_Videos")]
        public Categorias_Videos Categorias_Videos { get; set; }
        public int Id_Cat_Videos { get; set; }



    }
}