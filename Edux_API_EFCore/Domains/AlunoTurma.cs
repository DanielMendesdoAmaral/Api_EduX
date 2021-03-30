using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Domains
{
    public class AlunoTurma : BaseDomains
    {
        //Atributos
        public string Matricula { get; set; }

        //Foreign Keys
        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public Guid IdTurma { get; set; }
        [ForeignKey("IdTurma")]
        public Turma Turma { get; set; }

        public List<ObjetivoAluno> ObjetivosAlunos { get; set; }
    }
}