using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace alimentesebem.sesi.domain.Entities
{
    public class Perguntas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "O campo Descrição deve ter no minimo 10 caracteres e no maximo 200 caracteres.")]
        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Data_Inicio { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Data_Fim { get; set; }

        [Required]
        [StringLength(1, ErrorMessage = "O campo Ordem deve ter o número da posição da pergunta.")]
        public string Ordem { get; set; }

        [ForeignKey("Id_Dispositivo")]
        public Dispositivo Dispositivo { get; set; }
        public int Id_Dispositivo { get; set; }


        [ForeignKey("Id_Alternativa")]
        public Alternativas Alternativas { get; set; }
        public int Id_Alternativa { get; set; }

        public ICollection<Respostas> Respostas { get; set; }

    }
}