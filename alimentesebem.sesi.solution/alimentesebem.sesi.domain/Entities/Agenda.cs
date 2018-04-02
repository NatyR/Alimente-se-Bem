using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace alimentesebem.sesi.domain.Entities
{
    public class Agenda
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O campo Titulo deve ter no minimo 3 caracteres e no maximo 200.")]
        public string Titulo { get; set; }


        [Required]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "O campo Descricao deve ter no minimo 10 caracteres")]
        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Data_Evento { get; set; }

        [Required]
        public string Valor { get; set; }


        [StringLength(300, MinimumLength = 2, ErrorMessage = "O campo TAG deve ter no minimo 2 carateres e no máximo 300 caracteres")]
        public string Tag { get; set; }


        [ForeignKey("Id_Unidade")]
        public Unidades_Sesi Unidades_Sesi { get; set; }
        public int Id_Unidade { get; set; }

        //public ICollection<Unidades_Sesi> Unidades_Sesi { get; set;}                    

    }
}