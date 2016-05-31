using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace University.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    [Table("Inscricoes")]
    public class Inscricao
    {
        [Key]//Fala que é Foreing Key
        public int InscricaoId { get; set; }
        [DisplayName("Curso")]//Nome que será mostrado nas telas
        public int CursoId { get; set; }
        [DisplayName("Estudante")]//Nome que será mostrado nas telas
        public int EstudanteId { get; set; }
        public Grade? Grau { get; set; }
        [DisplayName("Data de Inscrição")]
        [DataType(DataType.Date)]//Tipo Data
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] // Formato Dia/Mes/Ano (dd/MM/yyyy)
        public DateTime DataInscricao { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual Estudante Estudante { get; set; }
    }
}