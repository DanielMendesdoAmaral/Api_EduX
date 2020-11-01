using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Edux_Api_EFcore.Domains
{
    public class Turma : BaseDomains
    {
        //Atributo
        public string Descricao { get; set; }

        //Foreign Keys
        public Guid IdCurso { get; set; }
        [ForeignKey("IdCurso")]
        public Curso Curso { get; set; }


        public List<ProfessorTurma> ProfessoresTurmas { get; set; }

        public List<AlunoTurma> AlunosTurmas { get; set; }

        public Turma()
        {
            ProfessoresTurmas = new List<ProfessorTurma>();
            AlunosTurmas = new List<AlunoTurma>();
        }
    }
}