using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace alimentesebem.sesi.domain.Entities
{
    public class Respostas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Resposta { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Data_Resposta { get; set; }

        [ForeignKey("Id_Pergunta")]
        public Perguntas Perguntas { get; set; }
        public int Id_Pergunta { get; set; }
    }
}