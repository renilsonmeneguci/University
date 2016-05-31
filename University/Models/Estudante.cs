using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace University.Models
{
    [Table("Estudantes")]//Define o nome da tabela no banco de dados
    public class Estudante
    {
        [Key]
        public int EstudanteId { get; set; }
        [DisplayName("Nome")]//Nome que será mostrado nas telas
        public string Nome { get; set; }
        [DisplayName("Enredeço")]//Nome que será mostrado nas telas
        public string Endereco { get; set; }

        public virtual ICollection<Inscricao> Inscricoes { get; set; }
    }
}