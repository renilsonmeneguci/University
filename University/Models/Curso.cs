using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace University.Models
{
    [Table("Cursos")]
    public class Curso
    {
        [Key]//Fala que é Foreing Key
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CursoId { get; set; }

        [DisplayName("Título")]//Nome que será mostrado nas telas
        public string Titulo { get; set; }
        [DisplayName("Créditos")]//Nome que será mostrado nas telas
        public int Creditos { get; set; }

        public virtual ICollection<Inscricao> Inscricoes { get; set; }
    }
}